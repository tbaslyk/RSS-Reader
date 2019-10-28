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
            }
        }

        private void LoadAllCategories()
        {
            var categories = CategoryManager.LoadCategories();

            if (categories != null)
            {
                _CategoryGroup.AddRange(categories);
                UpdateCategoryListView();
            }
        }

        private void UpdateCategoryListView()
        {
            lvCats.Items.Clear();

            foreach (Category category in _CategoryGroup.GetAll())
            {
                lvCats.Items.Add(category.Name);
                cmbCat.Items.Add(category.Name);
            }
        }

        private void UpdateFeedListView()
        {
            lvPodcasts.Items.Clear();

            foreach (Feed feed in _FeedGroup.GetAll())
            {
                ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, "temp", feed.Category.Name });

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
            string selectedCategory = (string) cmbCat.SelectedItem;

            foreach (Category category in _CategoryGroup.GetAll())
            {
                if (category.Name.Equals(selectedCategory))
                {
                    var feed = FeedManager.CreateFeed(txtURL.Text, category);
                    _FeedGroup.Add(feed);

                    ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, "temp", feed.Category.Name });
                    lvPodcasts.Items.Add(item);
                }
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
            Category newCategory = new Category(txtCatName.Text);

            _CategoryGroup.Add(newCategory);
            cmbCat.Items.Add(newCategory.Name);

            lvCats.Items.Add(newCategory.Name);
        }

        private void btnRemovePodcast_Click(object sender, EventArgs e)
        {
            _FeedGroup.Remove(lvPodcasts.SelectedItems[0].SubItems[1].Text);
            lvPodcasts.SelectedItems[0].Remove();
        }

        private void btnRemoveCat_Click(object sender, EventArgs e)
        {
            _CategoryGroup.Remove(lvCats.SelectedItems[0].Text);
            lvCats.SelectedItems[0].Remove();
        }

        private void lvCats_Click(object sender, MouseEventArgs e)
        {
            string category = lvCats.SelectedItems[0].Text;
            txtCatName.Text = category;

            List<Feed> sortedFeeds = _FeedGroup.GetAll().
                Where((f) => f.Category.Name.Equals(category)).
                ToList();

            lvPodcasts.Items.Clear();

            foreach(Feed feed in sortedFeeds)
            {
                ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, "temp", feed.Category.Name });
                lvPodcasts.Items.Add(item);
            }
        }

        private void btnEditCat_Click(object sender, EventArgs e)
        {
            var selectedCat = lvCats.SelectedItems[0].Text;

            Category catToChange = _CategoryGroup.GetAll().
                Where((c) => c.Name.Equals(selectedCat)).
                First();

            catToChange.Name = txtCatName.Text;
            UpdateCategoryListView();

            List<Category> cat = _FeedGroup.GetAll().
                Where((f) => f.Category.Name.Equals(selectedCat)).
                Select((f) => f.Category).
                ToList();

            foreach(Category category in cat)
            {
                category.Name = txtCatName.Text;
            }

            UpdateFeedListView();
        }

        private void btnEditPodcast_Click(object sender, EventArgs e)
        {
            var selectedFeedName = lvPodcasts.SelectedItems[0].SubItems[1].Text;

            Feed feedToChange = _FeedGroup.GetAll().
                Where((f) => f.Name.Equals(selectedFeedName)).
                First();

            _FeedGroup.Remove(feedToChange);

            Category selectedCategory = _CategoryGroup.GetAll().
                Where((c) => c.Name.Equals((string)cmbCat.SelectedItem)).
                First();

            Feed newFeed = FeedManager.CreateFeed(txtURL.Text, selectedCategory);
            _FeedGroup.Add(newFeed);

            lblTitle.Text = "";
            lblDesc.Text = "";
            lvEpisodes.Items.Clear();
            UpdateFeedListView();
        }        
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeedManager.SaveFeeds(_FeedGroup.GetAll());
            CategoryManager.SaveCategories(_CategoryGroup.GetAll());
        }
    }
}
