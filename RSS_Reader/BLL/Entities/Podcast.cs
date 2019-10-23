using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Podcast
    {
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Podcast(int EpisodeNumber)
        {
            this.EpisodeNumber = EpisodeNumber;

        }

    }
}
