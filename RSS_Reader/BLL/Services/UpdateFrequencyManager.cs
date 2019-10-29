using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace BLL.Services
{
    public static class UpdateFrequencyManager
    {


        public static void start(Feed feed)
        {
            Timer frequencyTimer = new Timer();
            frequencyTimer.Elapsed += (sender,e) => whenTimeElapsed(sender, e, feed);
            frequencyTimer.Interval = feed.Updatef.Minutes * 60 * 1000;
            frequencyTimer.Enabled = true;
            frequencyTimer.AutoReset = true;

            
        }

        private static void whenTimeElapsed(object source,ElapsedEventArgs e, Feed feed)
        {
            List<Episode> listOfEpisodes = FeedManager.GetEpisodes(feed.Url);
            feed.Episodes = listOfEpisodes;

        }
        
    }
}
