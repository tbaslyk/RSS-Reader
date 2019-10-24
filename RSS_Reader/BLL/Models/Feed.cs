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
        public int NumberOfEpisodes { get; set; }
        public List<Episode> Episodes { get; set; }

        public Feed(string podcastName, int numberOfEpisodes, List<Episode> episodes)
        {
            Name = podcastName;
            NumberOfEpisodes = numberOfEpisodes;
            Episodes = episodes;
            
        }

        public Feed()
        {

        }

    }
}
