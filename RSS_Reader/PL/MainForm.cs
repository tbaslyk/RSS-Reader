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
        private FeedGroup _FeedGroup;
        private CategoryGroup _CategoryGroup;

        public MainForm()
        {
            InitializeComponent();
            IntializeColumns();

            _FeedGroup = new FeedGroup();
            _CategoryGroup = new CategoryGroup();
            LoadAllFeeds();
            LoadAllCategories();
        }

        private void LoadAllFeeds()
        {
            var feeds = FeedManager.LoadFeeds();

            if (feeds != null)
            {
                _FeedGroup.AddRange(feeds);

                foreach (Feed feed in _FeedGroup.GetSortedFeeds())
                {
                    ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, "temp", feed.Category.Name });
                    lvPodcasts.Items.Add(item);
                }
            }
        }

        private void LoadAllCategories()
        {
            var categories = CategoryManager.LoadCategories();

            if (categories != null)
            {
                _CategoryGroup.AddRange(categories);

                foreach (Category category in _CategoryGroup.GetAllCategories())
                {
                    lvCats.Items.Add(category.Name);
                    cmbCat.Items.Add(category.Name);

                }
            }
        }

        private void IntializeColumns()
        {
            lvPodcasts.Columns.Add("Antal");
            lvPodcasts.Columns.Add("Namn");
            lvPodcasts.Columns.Add("Frekvens");
            lvPodcasts.Columns.Add("Kategori");
            lvPodcasts.View = View.Details;
            lvPodcasts.FullRowSelect = true;

            lvEpisodes.Columns.Add("Avsnitt");
            lvEpisodes.Columns.Add("Namn");
            lvEpisodes.View = View.Details;
            lvEpisodes.FullRowSelect = true;

            lvCats.Columns.Add("Namn");
            lvCats.View = View.Details;
        }

        private void btnAddPodcast_Click(object sender, EventArgs e)
        {
            string selectedCategory = (string)cmbCat.SelectedItem;

            foreach (Category category in _CategoryGroup.GetAllCategories())
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

        private void lvPodcasts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lvEpisodes.Items.Clear();

            foreach (Feed feed in _FeedGroup.GetSortedFeeds())
            {
                if (feed.Name.Equals(lvPodcasts.SelectedItems[0].SubItems[1].Text))
                {
                    foreach (Episode episode in feed.GetEpisodesByNew())
                    {
                        ListViewItem item = new ListViewItem(new[] { episode.EpisodeNumber.ToString(), episode.Title });
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
                            lblTitle.Text = episode.Title;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeedManager.SaveFeeds(_FeedGroup.GetAllFeeds());
            CategoryManager.SaveCategories(_CategoryGroup.GetAllCategories());
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

        private void lvCats_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string category = lvCats.SelectedItems[0].Text;
            txtCatName.Text = category;
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            var selectedCat = lvCats.SelectedItems[0].Text;
            
            foreach(Category category in _CategoryGroup.GetAllCategories())
            {
                if(category.Name.Equals(selectedCat))
                {
                    category.Name = txtCatName.Text;
                    UpdateCategoryListView();
                }
            }

            foreach(Feed feed in _FeedGroup.GetAllFeeds())
            {
                if(feed.Category.Name.Equals(selectedCat))
                {
                    feed.Category.Name = txtCatName.Text;

                }
            }
            UpdateFeedListView();

        }

        private void UpdateCategoryListView()
        {
            lvCats.Items.Clear();

            foreach(Category category in _CategoryGroup.GetAllCategories())
            {
                lvCats.Items.Add(category.Name);
            }
        }

        private void UpdateFeedListView()
        {
            lvPodcasts.Items.Clear();

            foreach(Feed feed in _FeedGroup.GetAllFeeds())
            {
                ListViewItem item = new ListViewItem(new[] { feed.NumberOfEpisodes.ToString(), feed.Name, "temp", feed.Category.Name });

                lvPodcasts.Items.Add(item);

            }
        }
    }
}
