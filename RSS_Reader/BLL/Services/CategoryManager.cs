using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class CategoryManager
    {

        public static void SaveCategories(List<Category> categories)
        {
            XMLSerializer.Serialize(categories, Environment.CurrentDirectory + "\\categories.xml");
        }

        public static List<Category> LoadCategories()
        {
            return XMLSerializer.Deserialize<List<Category>>(Environment.CurrentDirectory + "\\categories.xml");
        }
    }
}
