using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryGroup
    {

        public List<Category> Categories { get; set; }

        public CategoryGroup()
        {
            Categories = new List<Category>();
        }

        public void Add(Category category)
        {
            Categories.Add(category);
        }

        public void AddRange(List<Category> categories)
        {
            Categories = categories;
        }

        public List<Category> GetAllCategories()
        {
            return Categories;
        }

        public void Remove(string categoryName)
        {
            var result = Categories.Where(x => x.Name == categoryName).ToList();

            foreach (var item in result)
            {
                Categories.Remove(item);
            }

        }


    }
}
