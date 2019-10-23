using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FeedGroup
    {
        public List<Feed> Feeds { get; set; }

        public FeedGroup()
        {
            Feeds = new List<Feed>();
        }

        public void Add(Feed feed)
        {
            Feeds.Add(feed);
        } 

    }
}
