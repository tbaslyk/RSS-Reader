using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel.Syndication;
using System.Xml;

namespace BLL
{
    public static class RSSReader
    {
        public static SyndicationFeed Reader(string url)
        {
            SyndicationFeed feed = null;

            using (XmlReader xr = XmlReader.Create(url))
            {
                feed = SyndicationFeed.Load(xr);
            }

            return feed;
        }

    }
}
