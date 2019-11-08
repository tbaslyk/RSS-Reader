using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Category : Entity
    {
        public Category(string name) : base(name)
        {
        }

        public Category()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
