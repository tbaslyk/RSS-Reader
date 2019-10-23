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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem();

            item.Text = FeedManager.getFeed(txtURL.Text).NumberOfEpisodes.ToString();
            item.SubItems.Add(FeedManager.getFeed(txtURL.Text).Name);
            


            lvPodcasts.Items.Add(item);

        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
