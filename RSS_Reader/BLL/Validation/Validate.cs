using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Validation
{
    public static class Validation
    {



        public static bool checkIfFeedExists(string url, List<Feed> feeds)
        {

            
            foreach (var item in feeds)
            {
                if(url.ToLower().Equals(item.Url.ToLower()))
                {

                    return false;                    
                   
                }               
            }

            return true;
        }

        public static bool checkIfCategoryExists(string categoryName, List<Category> list)
        {


            foreach (var item in list)
            {
                if(categoryName.ToLower().Equals(item.Name.ToLower()) || categoryName.ToLower().Equals("alla"))
                {

                    return false;
                }
            }

            return true;
        }

        public static bool allowedToDeleteCategory(string categoryName, List<Feed> list)
        {

            foreach (var item in list)
            {

                if(item.Category.Name.Equals(categoryName))
                {
                    return false;
                }

            }

            return true;
        }

        public static bool isAlla(string fieldName)
        {

            if (fieldName.Equals("Alla"))
            {
                return false;
            }

            return true;
        }

        

    }
}
