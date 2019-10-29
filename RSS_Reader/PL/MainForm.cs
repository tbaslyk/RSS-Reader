using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
using BLL.Models;
using BLL.Services;
using BLL.Validation;

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
            populateComboBox();

            _FeedGroup = new FeedGroup();
            _CategoryGroup = new CategoryGroup();

            LoadAllFeeds();
            LoadAllCategories();
        }

        private void IntializeColumns()
        {
            lvPodcasts.Columns.Add("Antal", -2);
            lvPodcasts.Columns.Add("Namn", -1);
            lvPodcasts.Columns.Add("Frekvens", -1);
            lvPodcasts.Columns.Add("Kategori", -1);
            lvPodcasts.View = View.Details;
            lvPodcasts.FullRowSelect = true;
            lvPodcasts.MultiSelect = false;

            lvEpisodes.Columns.Add("Avsnitt", -2);
            lvEpisodes.Columns.Add("Namn", -2);
            lvEpisodes.View = View.Details;
            lvEpisodes.FullRowSelect = true;
            lvEpisodes.MultiSelect = false;

            lvCats.Columns.Add("Namn", -1);
            lvCats.View = View.Details;
            lvCats.MultiSelect = false;
        }

        private void LoadAllFeeds()
        {
            var feeds = FeedManager.LoadFeeds();

            if (feeds != null)
            {
                _FeedGroup.AddRange(feeds);
                UpdateFeedListView();
                foreach (Feed item in feeds)
                {
                    UpdateFrequencyManager.start(item);
                }
            }

            
        }

        private void LoadAllCategories()
        {
            var categories = CategoryManager.LoadCategories();

            if (categories != null)
            {
                _CategoryGroup.AddRange(categories);
            }
            UpdateCategoryListView();
        }

        private void UpdateCategoryListView()
        {
            lvCats.Items.Clear();
            lvCats.Items.Add("Alla");

            foreach (Category category in _CategoryGroup.GetAll())
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
                ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, feed.Updatef.Minutes.ToString(), feed.Category.Name });

                lvPodcasts.Items.Add(item);
            }
        }

        private void lv_MouseUp(object sender, MouseEventArgs e)
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
            if (Validation.checkIfFeedExists(txtURL.Text, _FeedGroup.GetAll()))
            {


                
                string selectedCategory = (string)cmbCat.SelectedItem;
                if (Validation.allFieldsFilled(txtURL.Text))
                {



                    foreach (Category category in _CategoryGroup.GetAll())
                    {
                        if (category.Name.Equals(selectedCategory))
                        {


                            var feed = FeedManager.CreateFeed(txtURL.Text, category, new UpdateFrequency(Int32.Parse(comboBox2.SelectedItem.ToString())));
                            _FeedGroup.Add(feed);
                            ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, feed.Updatef.Minutes.ToString(), feed.Category.Name });
                            lvPodcasts.Items.Add(item);
                            UpdateFrequencyManager.start(feed);
                        }
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
            lvEpisodes.Items.Clear();
            lblTitle.Text = "";
            lblDesc.Text = "";

            foreach (Feed feed in _FeedGroup.GetSortedFeeds())
            {
                if (feed.Name.Equals(lvPodcasts.SelectedItems[0].SubItems[1].Text))
                {
                    txtURL.Text = feed.Url;
                    cmbCat.SelectedItem = feed.Category.Name;

                    foreach (Episode episode in feed.GetEpisodesByNew())
                    {
                        ListViewItem item = new ListViewItem(new[] { episode.EpisodeNumber.ToString(), episode.Name });
                        lvEpisodes.Items.Add(item);
                    }
                    break;
                }
            }
        }


        private void lvEpisodes_Click(object sender, EventArgs e)
        {
            foreach (Feed feed in _FeedGroup.GetSortedFeeds())
            {
                if (feed.Name.Equals(lvPodcasts.SelectedItems[0].SubItems[1].Text))
                {
                    foreach (Episode episode in feed.Episodes)
                    {
                        if (episode.EpisodeNumber.ToString().Equals(lvEpisodes.SelectedItems[0].Text))
                        {
                            lblTitle.Text = episode.Name;
                            lblDesc.Text = episode.Description;
                        }
                    }
                    break;
                }
            }
        }

        private void btnCreateCat_Click(object sender, EventArgs e)
        {
            
                       
            if(Validation.checkIfCategoryExists(txtCatName.Text, _CategoryGroup.GetAll()))
            {
                Category newCategory = new Category(txtCatName.Text);

                _CategoryGroup.Add(newCategory);
                cmbCat.Items.Add(newCategory.Name);

                lvCats.Items.Add(newCategory.Name);
            }

            else
            {
                MessageBox.Show("Kategorin finns redan");
            }
        }

        private void btnRemovePodcast_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count > 0)
            {


                _FeedGroup.Remove(lvPodcasts.SelectedItems[0].SubItems[1].Text);
                lvPodcasts.SelectedItems[0].Remove();
            }
        }

        private void btnRemoveCat_Click(object sender, EventArgs e)
        {
            if (lvCats.SelectedItems.Count > 0)
            {


                string text = lvCats.SelectedItems[0].Text;

                if (Validation.isAlla(text))
                {

                    if (Validation.allowedToDeleteCategory(text, _FeedGroup.GetAll()))
                    {
                        _CategoryGroup.Remove(lvCats.SelectedItems[0].Text);
                        lvCats.SelectedItems[0].Remove();
                        cmbCat.Items.Remove(text);

                    }

                    else
                    {
                        MessageBox.Show("Du kan inte ta bort en Kategori som används av en Feed");
                    }
                }

            }

            
            
        }

        private void lvCats_Click(object sender, MouseEventArgs e)
        {
            string category = lvCats.SelectedItems[0].Text;

            if (category.Equals("Alla"))
            {
                UpdateFeedListView();
            }
            else
            {
                txtCatName.Text = category;

                List<Feed> sortedFeeds = _FeedGroup.GetSortedFeeds().
                    Where((f) => f.Category.Name.Equals(category)).
                    ToList();

                lvPodcasts.Items.Clear();

                foreach (Feed feed in sortedFeeds)
                {
                    ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, feed.Updatef.Minutes.ToString(), feed.Category.Name });
                    lvPodcasts.Items.Add(item);
                }
            }
        }

        private void btnEditCat_Click(object sender, EventArgs e)
        {

            if (lvCats.SelectedItems.Count > 0)
            {


                if (Validation.allFieldsFilledCategory(txtCatName.Text))
                {
                    if (Validation.checkIfCategoryExists(txtCatName.Text, _CategoryGroup.GetAll()))
                    {
                        var selectedCat = lvCats.SelectedItems[0].Text;

                        Category catToChange = _CategoryGroup.GetAll().
                        Where((c) => c.Name.Equals(selectedCat)).
                        First();

                        catToChange.Name = txtCatName.Text;
                        UpdateCategoryListView();

                        List<Category> cat = _FeedGroup.GetSortedFeeds().
                            Where((f) => f.Category.Name.Equals(selectedCat)).
                            Select((f) => f.Category).
                            ToList();

                        foreach (Category category in cat)
                        {
                            category.Name = txtCatName.Text;
                        }

                        UpdateFeedListView();
                    }

                    else
                    {
                        MessageBox.Show("Kategorin finns redan");
                    }
                }

                else
                {
                    MessageBox.Show("Ange Kategorin på ett korrekt sätt");
                }

            }

        }

        private void btnEditPodcast_Click(object sender, EventArgs e)
        {
            if (lvPodcasts.SelectedItems.Count > 0)
            {
                if (Validation.isAlla(txtURL.Text))
                {


                    var selectedFeedName = lvPodcasts.SelectedItems[0].SubItems[1].Text;

                    Feed feedToChange = _FeedGroup.GetAll().
                        Where((f) => f.Name.Equals(selectedFeedName)).
                        First();

                    _FeedGroup.Remove(feedToChange);

                    Category selectedCategory = _CategoryGroup.GetAll().
                        Where((c) => c.Name.Equals((string)cmbCat.SelectedItem)).
                        First();

                    Feed newFeed = FeedManager.CreateFeed(txtURL.Text, selectedCategory, new UpdateFrequency(Int32.Parse(comboBox2.SelectedItem.ToString())));
                    _FeedGroup.Add(newFeed);

                    lblTitle.Text = "";
                    lblDesc.Text = "";
                    lvEpisodes.Items.Clear();
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

        private void populateComboBox()
        {
            
            comboBox2.Items.Add(new UpdateFrequency(1).Minutes);
            comboBox2.Items.Add(new UpdateFrequency(5).Minutes);
            comboBox2.Items.Add(new UpdateFrequency(10).Minutes);
            comboBox2.Items.Add(new UpdateFrequency(15).Minutes);
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCat.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
