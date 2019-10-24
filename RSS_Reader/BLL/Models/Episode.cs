using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Episode
    {
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Episode(int episodeNumber, string title, string description)
        {
            EpisodeNumber = episodeNumber;
            Title = title;
            Description = description;

        }

    }
}
