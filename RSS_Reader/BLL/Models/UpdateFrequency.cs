using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UpdateFrequency
    {
        public int Minutes { get; set; }
        public UpdateFrequency(int minutes)
        {
            Minutes = minutes;
        }

        public UpdateFrequency()
        {

        }
    }
}
