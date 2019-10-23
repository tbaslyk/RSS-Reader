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



namespace PL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IntializeColumns();
        }

        public void IntializeColumns()
        {
            lvPodcasts.Columns.Add("Antal");
            lvPodcasts.Columns.Add("Namn");
            lvPodcasts.Columns.Add("Frekvens");
            lvPodcasts.Columns.Add("Kategori");
            lvPodcasts.View = View.Details;
        }

        private void btnAddPodcast_Click(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem();
            var feed = FeedManager.CreateFeed(txtURL.Text);

            item.Text = feed.NumberOfEpisodes.ToString();
            item.SubItems.Add(feed.Name);
            

            lvPodcasts.Items.Add(item);

        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
