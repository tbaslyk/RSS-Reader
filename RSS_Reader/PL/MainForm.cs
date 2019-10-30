using BLL.Models;
using BLL.Services;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                lvCats.Items.Add(category.Name);
                cmbCat.Items.Add(category.Name);
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
                ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, feed.Frequency.Minutes.ToString(), feed.Category.Name });
                lvPodcasts.Items.Add(item);
            }
        }

        private void ClearEpisodes()
        {
            lvEpisodes.Items.Clear();
            lblTitle.Text = "";
            lblDesc.Text = "";
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

        private void btnAddPodcast_Click(object sender, EventArgs e)
        {
            if (Validator.CheckIfFeedExists(txtURL.Text, _FeedGroup.GetAll()))
            {
                string selectedCategory = (string)cmbCat.SelectedItem;

                if (Validator.AllFieldsFilled(txtURL.Text, cmbCat))
                {
                    var category = _CategoryGroup.GetAll().
                        Where((c) => c.Name.Equals(selectedCategory)).
                        First();

                    var feed = FeedManager.CreateFeed(txtURL.Text, category, new UpdateFrequency(int.Parse(cmbFreq.SelectedItem.ToString())));

                    if (Validator.IsNotNull(feed))
                    {
                        _FeedGroup.Add(feed);
                        ListViewItem item = new ListViewItem(new[] {
                            feed.NumberOfEpisodes.ToString(),
                            feed.Name,
                            feed.Frequency.Minutes.ToString(),
                            feed.Category.Name });
                        lvPodcasts.Items.Add(item);
                        FrequencyTimer.Start(feed);
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

        private void lvPodcasts_Click(object sender, MouseEventArgs e)
        {
            ClearEpisodes();

            Feed selectedFeed = _FeedGroup.GetSortedFeeds().
                Where((f) => f.Name.Equals(lvPodcasts.SelectedItems[0].SubItems[1].Text)).
                First();

            txtURL.Text = selectedFeed.Url;
            cmbCat.SelectedItem = selectedFeed.Category.Name;

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
                Feed selectedFeed = _FeedGroup.GetSortedFeeds().
                    Where((f) => f.Name.Equals(lvPodcasts.SelectedItems[0].SubItems[1].Text)).
                    First();

                Episode selectedEpisode = selectedFeed.Episodes.
                    Where((ep) => ep.EpisodeNumber.ToString().Equals(lvEpisodes.SelectedItems[0].Text)).
                    First();

                lblTitle.Text = selectedEpisode.Name;
                lblDesc.Text = selectedEpisode.Description;
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
                _FeedGroup.Remove(lvPodcasts.SelectedItems[0].SubItems[1].Text);
                lvPodcasts.SelectedItems[0].Remove();
                ClearEpisodes();
            }
        }

        private void btnRemoveCat_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvCats))
            {
                string text = lvCats.SelectedItems[0].Text;

                if (Validator.IsAlla(text))
                {
                    if (Validator.AllowedToDeleteCategory(text, _FeedGroup.GetAll()))
                    {
                        _CategoryGroup.Remove(text);
                        lvCats.SelectedItems[0].Remove();
                        cmbCat.Items.Remove(text);
                    }
                    else
                    {
                        MessageBox.Show("Det går inte att ta bort en kategori som används");
                    }
                }
            }
        }

        private void lvCats_Click(object sender, MouseEventArgs e)
        {
            string category = lvCats.SelectedItems[0].Text;
            ClearEpisodes();

            if (category.Equals("Alla"))
            {
                UpdateFeedListView();
                btnEditCat.Enabled = false;
                btnRemoveCat.Enabled = false;
            }
            else
            {
                btnEditCat.Enabled = true;
                btnRemoveCat.Enabled = true;
                txtCatName.Text = category;

                List<Feed> sortedFeeds = _FeedGroup.GetSortedFeeds().
                    Where((f) => f.Category.Name.Equals(category)).
                    ToList();

                lvPodcasts.Items.Clear();

                foreach (Feed feed in sortedFeeds)
                {
                    ListViewItem item = new ListViewItem(new[] {
                        feed.NumberOfEpisodes.ToString(),
                        feed.Name,
                        feed.Frequency.Minutes.ToString(),
                        feed.Category.Name });
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
                        var selectedCategory = lvCats.SelectedItems[0].Text;

                        Category categoryToReplace = _CategoryGroup.GetAll().
                        Where((c) => c.Name.Equals(selectedCategory)).
                        First();

                        categoryToReplace.Name = txtCatName.Text;
                        UpdateCategoryListView();

                        List<Category> categoriesToReplace = _FeedGroup.GetSortedFeeds().
                            Where((f) => f.Category.Name.Equals(selectedCategory)).
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
                        MessageBox.Show("Kategorin finns redan tillagd");
                    }
                }
                else
                {
                    MessageBox.Show("Kategorinamnet får inte vara tomt");
                }
            }
        }

        private void btnEditPodcast_Click(object sender, EventArgs e)
        {
            if (Validator.IsListViewItemSelected(lvPodcasts))
            {
                if (Validator.IsAlla(txtURL.Text))
                {
                    var selectedFeedName = lvPodcasts.SelectedItems[0].SubItems[1].Text;

                    Feed feedToChange = _FeedGroup.GetAll().
                        Where((f) => f.Name.Equals(selectedFeedName)).
                        First();

                    _FeedGroup.Remove(feedToChange);

                    Category selectedCategory = _CategoryGroup.GetAll().
                        Where((c) => c.Name.Equals((string)cmbCat.SelectedItem)).
                        First();

                    Feed newFeed = FeedManager.CreateFeed(txtURL.Text, selectedCategory, new UpdateFrequency(int.Parse(cmbFreq.SelectedItem.ToString())));
                    _FeedGroup.Add(newFeed);

                    ClearEpisodes();
                    UpdateFeedListView();
                }
                else
                {
                    MessageBox.Show("Fyll i alla fälten korrekt");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeedManager.SaveFeeds(_FeedGroup.GetAll());
            CategoryManager.SaveCategories(_CategoryGroup.GetAll());
        }
        #endregion
    }
}
