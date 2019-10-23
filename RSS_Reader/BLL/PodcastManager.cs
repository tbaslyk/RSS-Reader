using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;

namespace BLL
{
    public class PodcastManager
    {

        public string Url { get; set; }
        public List<SyndicationItem> SyndicationList { get; set; }
        
        public PodcastManager(string Url)
        {
            this.Url = Url;
            
            
        }

      
        public List<SyndicationItem> getList()
        {
            XmlReader xr = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(xr);
            xr.Close();
            SyndicationList = feed.Items.ToList();

            return SyndicationList;
        }
    }

}

