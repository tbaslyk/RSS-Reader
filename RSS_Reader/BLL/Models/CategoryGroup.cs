using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryGroup
    {

        public List<Category> categories { get; set; }

        public CategoryGroup()
        {
            categories = new List<Category>();
        }

        public void Add(Category category)
        {
            categories.Add(category);
        }


    }
}
