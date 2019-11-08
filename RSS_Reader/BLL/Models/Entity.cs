using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public abstract class Entity : IEntity
    {
        public string Name { get; set; }

        public Entity(string name)
        {
            Name = name;
        }

        public Entity()
        {

        }
    }
}
