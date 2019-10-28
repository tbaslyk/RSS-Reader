using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FeedGroup : IGroup<Feed>
    {
        public List<Feed> Feeds { get; private set; }

        public FeedGroup()
        {
            Feeds = new List<Feed>();
        }

        public void Add(Feed feed)
        {
            if(!Feeds
                .Any((f) => f.Name == feed.Name))
            {
                Feeds.Add(feed);
            }
            
        }

        public void Remove(string feedName)
        {
            var result = Feeds
                .Where(x => x.Name == feedName)
                .ToList();

            foreach (var item in result)
            {
                Feeds.Remove(item);
            }
            
        }

        public void AddRange(List<Feed> feeds)
        {
            Feeds = feeds;
        }
        
        public List<Feed> GetSortedFeeds()
        {
            List<Feed> sortedFeeds = Feeds
                .OrderBy((f) => f.Name)
                .ToList();

            return sortedFeeds;
        }

        public List<Feed> GetAll()
        {
            return Feeds;
        }

    }
}
