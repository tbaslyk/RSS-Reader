using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;


namespace BLL.Validation
{
    public static class Validator
    {
        public static bool CheckIfFeedExists(string url, List<Feed> feeds)
        {
            foreach (var item in feeds)
            {
                if (url.ToLower().Equals(item.Url.ToLower()))
                {
                    return false;
                }               
            }
            return true;
        }

        public static bool CheckIfCategoryExists(string categoryName, List<Category> list)
        {
            foreach (var item in list)
            {
                if (categoryName.ToLower().Equals(item.Name.ToLower()) || categoryName.ToLower().Equals("alla"))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AllowedToDeleteCategory(string categoryName, List<Feed> list)
        {
            foreach (var item in list)
            {
                if (item.Category.Name.ToLower().Equals(categoryName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAlla(string fieldName)
        {
            if (fieldName.Equals("Alla"))
            {
                return false;
            }
            return true;
        }

        public static bool AllFieldsFilled(string url)
        {
            if (url.Contains(" ") || url.Equals(""))
            {
                return false;
            }
            return true;
        }

        public static bool AllFieldsFilledCategory(string url)
        {
            bool tested = String.IsNullOrWhiteSpace(url);
            return !tested;
        }

        public static bool IsNotNull(object anObject)
        {
            if (anObject == null)
            {
                return false;
            }
            return true;
        }
    }
}
