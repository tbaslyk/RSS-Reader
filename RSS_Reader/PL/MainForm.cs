using BLL.Models;
using BLL.Services;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class MainForm : Form
    {
        private readonly FeedGroup _FeedGroup;
        private readonly CategoryGroup _CategoryGroup;

        public MainForm()
        {
            InitializeComponent();
            IntializeColumns();
            PopulateComboboxes();

            _FeedGroup = new FeedGroup();
            _CategoryGroup = new CategoryGroup();

            LoadAllFeeds();
            LoadAllCategories();
        }

        #region Initialization methods
        private void IntializeColumns()
        {
            lvPodcasts.Columns.Add("Antal", -2);
            lvPodcasts.Columns.Add("Namn", -2);
            lvPodcasts.Columns.Add("Frekvens", -2);
            lvPodcasts.Columns.Add("Kategori", -2);
            lvPodcasts.View = View.Details;
            lvPodcasts.FullRowSelect = true;
            lvPodcasts.MultiSelect = false;

            lvEpisodes.Columns.Add("Avsnitt", -2);
            lvEpisodes.Columns.Add("Namn", -2);
            lvEpisodes.View = View.Details;
            lvEpisodes.FullRowSelect = true;
            lvEpisodes.MultiSelect = false;

            lvCats.Columns.Add("Namn");
            lvCats.View = View.Details;
            lvCats.MultiSelect = false;
        }

        private void LoadAllFeeds()
        {
            var feeds = FeedManager.LoadFeeds();

            if (Validator.IsNotNull(feeds))
            {
                _FeedGroup.AddRange(feeds);
                UpdateFeedListView();
                foreach (Feed feed in feeds)
                {
                    FrequencyTimer.Start(feed);
                }
            }
        }

        private void LoadAllCategories()
        {
            var categories = CategoryManager.LoadCategories();

            if (Validator.IsNotNull(categories))
            {
                _CategoryGroup.AddRange(categories);
            }
            UpdateCategoryListView();
        }

        private void PopulateComboboxes()
        {
            cmbFreq.Items.Add(new UpdateFrequency(1).Minutes);
            cmbFreq.Items.Add(new UpdateFrequency(5).Minutes);
            cmbFreq.Items.Add(new UpdateFrequency(10).Minutes);
            cmbFreq.Items.Add(new UpdateFrequency(15).Minutes);
            cmbFreq.SelectedIndex = 0;
            cmbFreq.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Update methods
        private void UpdateCategoryListView()
        {
            lvCats.Items.Clear();
            lvCats.Items.Add("Alla");
            cmbCat.Items.Clear();

            foreach (Category category in _CategoryGroup.GetSortedCategories())
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    category.Name })
                {
                    Tag = category
                };
                lvCats.Items.Add(item);
                cmbCat.Items.Add(category);
            }

            if (_CategoryGroup.GetAll().Any())
            {
                cmbCat.SelectedIndex = 0;
            }
        }

        private void UpdateFeedListView()
        {
            lvPodcasts.Items.Clear();

            foreach (Feed feed in _FeedGroup.GetSortedFeeds())
            {
                ListViewItem item = new ListViewItem(new[] {
                    feed.NumberOfEpisodes.ToString(),
                    feed.Name, feed.Frequency.Minutes.ToString(),
                    feed.Category.Name })
                {
                    Tag = feed
                };
                lvPodcasts.Items.Add(item);
            }
        }

        private void ClearEpisodes()
        {
            lvEpisodes.Items.Clear();
            wbDescription.Navigate("about:blank");
        }
        #endregion

        #region Event handlers
        private void LV_MouseUp(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;

            if (lv.FocusedItem != null)
            {
                if (lv.SelectedItems.Count == 0)
                    lv.FocusedItem.Selected = true;
            }
        }

        private async void btnAddPodcast_Click(object sender, EventArgs e)
        {
            if (Validator.TryParseComboBoxValue(cmbFreq, out string message))
            {
                if (Validator.CheckIfFeedExists(txtURL.Text, _FeedGroup.GetAll()))
                {
                    if (Validator.AllFieldsFilled(txtURL.Text, cmbCat))
                    {
                        Category category = (Category)cmbCat.SelectedItem;
                        var time = int.Parse(cmbFreq.SelectedItem.ToString());

                        Feed feed = null;

                        Task taskA = Task.Run(() => feed = FeedManager.CreateFeed(txtURL.Text, category, new UpdateFrequency(time)));
                        await taskA;

                        if (Validator.IsNotNull(feed))
                        {
                            _FeedGroup.Add(feed);
                            ListViewItem item = new ListViewItem(new[] {
                            feed.NumberOfEpisodes.ToString(),
                            feed.Name,
                            feed.Frequency.Minutes.ToString(),
                            feed.Category.Name })
                            {
                                Tag = feed
                            };
                            lvPodcasts.Items.Add(item);
                            FrequencyTimer.Start(feed);
                            txtURL.Clear();
                            UpdateFeedListView();
                        }
                        else
                        {
                            MessageBox.Show("Ogiltig URL");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fyll i alla fälten korrekt");
                    }
                }
                else
                {
                    MessageBox.Show("Feeden finns redan");
                }
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void lvPodcasts_Click(object sender, MouseEventArgs e)
        {
            ClearEpisodes();

            Feed selectedFeed = (Feed)lvPodcasts.SelectedItems[0].Tag;
            txtURL.Text = selectedFeed.Url;
            cmbCat.SelectedItem = selectedFeed.Category;

            foreach (Episode episode in selectedFeed.GetEpisodesByNew())
            {
                ListViewItem item = new ListViewItem(new[] {
                            episode.EpisodeNumber.ToString(),
                            episode.Name });
                lvEpisodes.Items.Add(item);
            }
        }

        private void lvEpisodes_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvPodcasts))
            {
                Feed selectedFeed = (Feed)lvPodcasts.SelectedItems[0].Tag;
                Episode selectedEpisode = selectedFeed.Episodes.
                    Where((ep) => ep.EpisodeNumber.ToString().Equals(lvEpisodes.SelectedItems[0].Text)).
                    First();

                wbDescription.Document.OpenNew(true);
                wbDescription.Document.Write("<b>" + selectedEpisode.Name + "</b>");
                wbDescription.Document.Write("<br>" + selectedEpisode.Description);
            }
        }

        private void btnCreateCat_Click(object sender, EventArgs e)
        {
            if (Validator.AllFieldsFilledCategory(txtCatName.Text))
            {
                if (Validator.CheckIfCategoryExists(txtCatName.Text, _CategoryGroup.GetAll()))
                {
                    Category newCategory = new Category(txtCatName.Text);
                    _CategoryGroup.Add(newCategory);
                    txtCatName.Clear();
                    UpdateCategoryListView();
                }
                else
                {
                    MessageBox.Show("En kategori med samma namn existerar redan");
                }
            }
        }

        private void btnRemovePodcast_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvPodcasts))
            {
                _FeedGroup.Remove((Feed)lvPodcasts.SelectedItems[0].Tag);
                lvPodcasts.SelectedItems[0].Remove();
                ClearEpisodes();
            }
            else
            {
                MessageBox.Show("Markera först en feed i listan för att ta bort den");
            }
        }

        private void btnRemoveCat_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvCats))
            {
                Category selectedCategory = (Category) lvCats.SelectedItems[0].Tag;

                if (Validator.AllowedToDeleteCategory(selectedCategory.Name, _FeedGroup.GetAll()))
                {
                    _CategoryGroup.Remove(selectedCategory.Name);
                    lvCats.SelectedItems[0].Remove();
                    cmbCat.Items.Remove(selectedCategory);
                    txtCatName.Clear();
                }
                else
                {
                    MessageBox.Show("Det går inte att ta bort en kategori som används av befinitliga feeds");
                }
            }
            else
            {
                MessageBox.Show("Markera först en kategori i listan för att ta bort den");
            }
        }

        private void lvCats_Click(object sender, MouseEventArgs e)
        {
            string categoryText = lvCats.SelectedItems[0].Text;
            ClearEpisodes();

            if (categoryText.Equals("Alla"))
            {
                UpdateFeedListView();
                btnEditCat.Enabled = false;
                btnRemoveCat.Enabled = false;
                txtCatName.Clear();
            }
            else
            {
                btnEditCat.Enabled = true;
                btnRemoveCat.Enabled = true;
                txtCatName.Text = categoryText;

                List<Feed> sortedFeeds = _FeedGroup.GetSortedFeeds().
                    Where((f) => f.Category.Name.Equals(categoryText)).
                    ToList();

                lvPodcasts.Items.Clear();

                foreach (Feed feed in sortedFeeds)
                {
                    ListViewItem item = new ListViewItem(new[] {
                        feed.NumberOfEpisodes.ToString(),
                        feed.Name,
                        feed.Frequency.Minutes.ToString(),
                        feed.Category.Name })
                    {
                        Tag = feed
                    };
                    lvPodcasts.Items.Add(item);
                }
            }
        }

        private void btnEditCat_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvCats))
            {
                if (Validator.AllFieldsFilledCategory(txtCatName.Text))
                {
                    if (Validator.CheckIfCategoryExists(txtCatName.Text, _CategoryGroup.GetAll()))
                    {
                        Category categoryToReplace = (Category)lvCats.SelectedItems[0].Tag;
                        categoryToReplace.Name = txtCatName.Text;
                        UpdateCategoryListView();

                        List<Category> categoriesToReplace = _FeedGroup.GetSortedFeeds().
                            Where((f) => f.Category.Name.Equals(categoryToReplace.Name)).
                            Select((f) => f.Category).
                            ToList();

                        foreach (Category category in categoriesToReplace)
                        {
                            category.Name = txtCatName.Text;
                        }
                        UpdateFeedListView();
                    }
                    else
                    {
                        MessageBox.Show("En kategori med samma namn finns redan");
                    }
                }
                else
                {
                    MessageBox.Show("Kategorinamnet får inte vara tomt");
                }
            }
            else
            {
                MessageBox.Show("Markera först en kategori i listan för att redigera den");
            }
        }

        private async void btnEditPodcast_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvPodcasts))
            {
                if (Validator.IsAlla(txtURL.Text))
                {
                    Feed feedToChange = (Feed)lvPodcasts.SelectedItems[0].Tag;
                    _FeedGroup.Remove(feedToChange);

                    Category selectedCategory = (Category)cmbCat.SelectedItem;
                    var time = int.Parse(cmbFreq.SelectedItem.ToString());

                    Feed newFeed = null;

                    Task taskA = Task.Run(() => newFeed = FeedManager.CreateFeed(txtURL.Text, selectedCategory, new UpdateFrequency(time)));
                    await taskA;

                    _FeedGroup.Add(newFeed);

                    ClearEpisodes();
                    UpdateFeedListView();
                }
                else
                {
                    MessageBox.Show("Fyll i alla fälten korrekt");
                }
            }
            else
            {
                MessageBox.Show("Markera först en feed i listan för att ändra den");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeedManager.SaveFeeds(_FeedGroup.GetAll());
            CategoryManager.SaveCategories(_CategoryGroup.GetAll());
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
