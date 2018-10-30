using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.SearchPage;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Selenium_OpenCart.Data.Category;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Logic
{
    class SearchMethods
    {
        public SearchMethods()
        {
           
        }

        /// <summary>
        /// Method for search by textbox search
        /// </summary>
        /// <param name="textSearch">text for searching</param>
        /// <returns>Search page object</returns>
        public SearchPage Search(string textSearch)
        {
            Header item = new Header();
            item.ClickSearchTextBox();
            item.ClearSearchTextBox();
            item.SetTextInSearchTextBox(textSearch);
            SearchPage page = item.ClickSearchButton();

            return page;
        }

        /// <summary>
        /// Get main label for searching after search
        /// </summary>
        /// <param name="search">string for searching</param>
        /// <returns>String content header</returns>
        public string GetSearchHeader(string search)
        {
            SearchPage content = Search(search);
            return content.GetTextFromSearchLabel();
        }

        /// <summary>
        /// Check displayed categories with data from DB
        /// </summary>
        /// <param name="list">list from DB</param>
        /// <returns>true if equal, false if not equal</returns>
        public bool TestCategoriesValue(List<string> list)
        {
            SearchPage content = new SearchPage();
            List<string> actual = content.GetListOfCategories();
            actual.RemoveAt(0);

            for (int i = 0; i < actual.Count; i++)
            {
                actual[i] = actual[i].Trim(' ');
                list[i] = list[i].Replace("amp;","");
            }


            actual.Sort();

            list.Sort();

            int count = 0;
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i] == list[i])
                {
                    count++;
                }
            }

            return count == list.Count;
        }

        /// <summary>
        /// Search with custom category
        /// </summary>
        /// <param name="textSearch">text for searching</param>
        /// <param name="category">category for select</param>
        /// <returns>count founded products</returns>
        public int SearchByCategory(string textSearch, string category)
        {

            SearchPage content = Search(textSearch);
            content.SetCategoryValue(category);

            content = content.ClickSearchButtonInsideContent();

            return content.GetListProduct().Count;
        }

        /// <summary>
        /// Get list of names categories
        /// </summary>
        /// <param name="list">list of ICategory objects</param>
        /// <returns>List of string names</returns>
        public List<string> ConvertToListStringCategory(List<ICategory> list) {
            List<string> output = new List<string>();
            foreach (var current in list) {
                output.Add(current.GetName());
            }
            return output;
        }

        /// <summary>
        /// Complex search method
        /// </summary>
        /// <param name="testSearch">string for searching</param>
        /// <param name="category">category for searching</param>
        /// <param name="chekSubcategory">value for checkbox subcategory</param>
        /// <param name="checkSearchInDesc">value for checkbox description searching</param>
        public void SearchingMethod(string testSearch, string category, bool chekSubcategory = false, bool checkSearchInDesc = false)
        {
            SearchPage content = Search(testSearch);
            
            content.SetCategoryValue(category);

            if (chekSubcategory != content.GetSearchCategoryValue())
            {
                content.ClickSearchCategoryCheck();
            }

            if (checkSearchInDesc != content.GetSearchDescriptionValue())
            {
                content.ClickSearchDescription();
            }

            content.ClickSearchButtonInsideContent();
        }
    }
}
