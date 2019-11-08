﻿using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Models
{
    public class Feed : Entity
    {
        public int NumberOfEpisodes { get; set; }
        public List<Episode> Episodes { get; set; }
        public Category Category { get; set; }
        public string Url { get; set; }
        public UpdateFrequency Frequency { get; set; }

        public Feed(string podcastName, int numberOfEpisodes, List<Episode> episodes, Category category, string url, UpdateFrequency updatef) : base(podcastName)
        {
            NumberOfEpisodes = numberOfEpisodes;
            Episodes = episodes;
            Category = category;
            Url = url;
            Frequency = updatef;
        }

        public Feed()
        {

        }

        public List<Episode> GetEpisodesByNew()
        {
            List<Episode> sortedEpisodes = Episodes
                .OrderByDescending((e) => e.EpisodeNumber)
                .ToList();

            return sortedEpisodes;
        }
    }
}
