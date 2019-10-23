using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Feed
    {
        public string Name { get; set; }

        public Feed(string PodcastName)
        {
            Name = PodcastName;
            
        }

    }
}
