using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Data.Product;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    public class SearchTests
    {
        SearchMethods logicSearch;
        DBDataReader reader;

        IWebDriver driver;
        const string URL = "http://atqc-shop.epizy.com/";
        
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            logicSearch = new SearchMethods(driver);
            reader = new DBDataReader();
        }

        [TestCase("Apple")]
        public void SearchingResultItemsCount(string search)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            int actual = logicSearch
                .Search(search)
                .GetListProduct()
                .Count;

            int expected = 
                reader.GetProducts(String.Format("name LIKE '%{0}%'", search)).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Assert.IsTrue(logicSearch
                .TestCategoriesValue(
                    logicSearch
                        .ConvertToListStringCategory(reader.GetCategories())
                )
            );
        }

        [TestCase("Apple", "Tablets", 4)]
        public void TestCategoryResult(string search, string category, int count)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            int actual = logicSearch
                .SearchByCategory(search, category);
            Assert.AreEqual(count, actual);
        }

        [TestCase("Apple")]
        public void TestLabelSearch(string search)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string actual = logicSearch
                .GetSearchHeader(search);
            string expected = "Search - " + search;

            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
