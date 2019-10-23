using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace BLL
{
    public static class FeedManager
    {
        public static SyndicationFeed reader(string url)
        {
            XmlReader xr = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xr);
            xr.Close();
            return feed;
        }


        private static string getTitle(string url)
        {
            SyndicationFeed feed = reader(url);
            return feed.Title.Text;
        }

        private static int getNumberEpisodes(string url)
        {
            SyndicationFeed feed = reader(url);
            int counter = 0;
            foreach (var item in feed.Items.ToList())
            {
                counter++;
            }
            return counter;
        }

        public static Feed getFeed(string url)
        {
            int number = getNumberEpisodes(url);
            string name = getTitle(url);

            return new Feed(name, number);
        }
    }
}
