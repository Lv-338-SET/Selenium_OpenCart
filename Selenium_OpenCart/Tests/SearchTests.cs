using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Data.Product;
using Selenium_OpenCart.Data.Search;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Address;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    public class SearchTests
    {
        SearchMethods logicSearch;
        DBDataReader reader;

        ISearch InputData
            = new XMLDataParser().GetSearchInputData();

        IWebDriver driver;

        const string URL = "http://40.118.125.245";
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
                .Search(InputData
                    .GetName())
                .GetListProduct()
                .Count;

            int expected =
                reader.GetProducts(String.Format("name LIKE '%{0}%'", InputData
                    .GetName()))
                .Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCategoryDropDown()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            logicSearch.Search(InputData.GetName());

            Assert.IsTrue(logicSearch
                .TestCategoriesValue(
                    logicSearch
                        .ConvertToListStringCategory(reader.GetCategories())
                )
            );
        }

        [Test]
        public void TestCategoryResult()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            int actual = logicSearch
                .SearchByCategory(InputData.GetName(), InputData.GetCategory());

            Assert.AreEqual(actual, InputData.GetCount());
        }

        [Test]
        public void TestLabelSearch()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string actual = logicSearch
                .GetSearchHeader(InputData.GetName());

            string expected = "Search - " + InputData.GetName();

            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
