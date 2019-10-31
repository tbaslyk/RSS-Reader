using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Category : Entity, IEntity
    {
        private string name;
        public override string Name {
            get {

                return name;
            } 
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public Category(string name)
        {
            Name = name;
        }
        public Category()
        {

        }

        public override string ToString()
        {
            return name;
        }
    }
}
