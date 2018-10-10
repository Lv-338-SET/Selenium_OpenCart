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

namespace Selenium_OpenCart.Logic
{
    class SearchMethods
    {
        IWebDriver driver;

        public SearchMethods(IWebDriver driver) {
            this.driver = driver;
        }

        public SearchPage Search(string textSearch)
        {
            Header item = new Header(driver);
            item.ClickSearchTextBox();
            item.ClearSearchTextBox();
            item.SetTextInSearchTextBox(textSearch);
            SearchPage page = item.ClickSearchButton();

            return page;
        }

        public string GetSearchHeader(string search)
        {
            SearchPage content = Search(search);
            return content.GetTextFromSearchLabel();
        }

        public bool TestCategoriesValue(List<string> list)
        {
            SearchPage content = new SearchPage(this.driver);
            List<string> actual = content.GetListOfCategories();
            int count = 0;
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i].Replace(" ", "") == list[i].Replace(" ", ""))
                {
                    count++;
                }
            }

            return count == actual.Count;
        }

        public int SearchByCategory(string textSearch, string category)
        {

            SearchPage content = Search(textSearch);
            content.SetCategoryValue(category);

            content = content.ClickSearchButtonInsideContent();

            return content.GetListProduct().Count;
        }

        public List<string> ConvertToListStringCategory(List<ICategory> list) {
            List<string> output = new List<string>();
            foreach (var current in list) {
                output.Add(current.GetName());
            }
            return output;
        }

        public void SearchingMethod(string testSearch, string category, bool chekSubcategory = false, bool checkSearchInDesc = false)
        {
            SearchPage content = new SearchPage(this.driver);

            content.SetTextInSearchTextBox(testSearch);
            content.SetCategoryValue(category);

            if (chekSubcategory != content.GetSearchCategoryValue())
            {
                content.ClickSearchCategoryCheck();
            }

            if (checkSearchInDesc != content.GetSearchDescriptionValue())
            {
                content.ClickSearchDescription();
            }

            content.ClickSearchButton();
        }
    }
}
