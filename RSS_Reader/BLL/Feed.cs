using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Feed
    {
        public string PodcastName { get; set; }
        public string Category { get; set; }
        public string URL { get; set; }

        public Feed(string PodcastName, string Category, string URL)
        {
            this.PodcastName = PodcastName;
            this.Category = Category;
            this.URL = URL;
            
        }

    }
}
