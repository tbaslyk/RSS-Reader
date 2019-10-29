using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                if(categoryName.ToLower().Equals(item.Name.ToLower()))
                {

                    return false;
                }
            }

            return true;
        }

    }
}
