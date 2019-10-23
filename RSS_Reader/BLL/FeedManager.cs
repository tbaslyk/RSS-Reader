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
        public static Feed getTitle(string url)
        {
            XmlReader xr = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xr);
            xr.Close();
            return new Feed(feed.Title.Text);
        }






    }
}
