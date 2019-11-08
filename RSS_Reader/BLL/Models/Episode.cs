﻿using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Episode : Entity
    {
        public int EpisodeNumber { get; set; }
        public string Description { get; set; }

        public Episode(int episodeNumber, string name, string description) : base(name)
        {
            EpisodeNumber = episodeNumber;
            Description = description;

        }
        public Episode()
        {

        }
    }
}
