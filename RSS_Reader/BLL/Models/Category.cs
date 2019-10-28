using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Category : IEntity
    {
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
        }
        public Category()
        {

        }
    }
}
