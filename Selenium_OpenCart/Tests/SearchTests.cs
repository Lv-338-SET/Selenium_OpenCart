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
        const string SEARCH_STRING = "Apple";
        
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            logicSearch = new SearchMethods(driver);
            reader = new DBDataReader();
        }

        [Test]
        public void SearchingResultItemsCount()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            int actual = logicSearch
                .Search(SEARCH_STRING)
                .GetListProduct()
                .Count;

            int expected = 
                reader.GetProducts(String.Format("name LIKE '%{0}%'", SEARCH_STRING)).Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCategoryDropDown()
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

        [TestCase("Tablets", 4)]
        public void TestCategoryResult(string category, int count)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            int actual = logicSearch
                .SearchByCategory(SEARCH_STRING, category);
            Assert.AreEqual(count, actual);
        }

        [Test]
        public void TestLabelSearch(string search)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string actual = logicSearch
                .GetSearchHeader(SEARCH_STRING);
            string expected = "Search - " + SEARCH_STRING;

            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
