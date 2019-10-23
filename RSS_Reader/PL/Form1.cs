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
        }

        private void button1_Click(object sender, EventArgs e)
        {
           PodcastManager pm = new PodcastManager(txtURL.Text);
            populateList(pm);
        }

        private void populateList(PodcastManager pm)
        {
            var list = pm.getList();

            foreach (var item in list)
            {
                string[] row = { item.Title.Text };
                var listViewItem = new ListViewItem(row);
                lvPodcasts.Items.Add(listViewItem);

            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
