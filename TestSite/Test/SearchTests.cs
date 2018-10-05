using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSite.Pages;
using TestSite.Logic;

namespace Selenium_OpenCart
{
    [TestFixture]
    public class SearchTests
    {
        IWebDriver driver;
        const string URL = "http://atqc-shop.epizy.com/";

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCase("Apple", 7)]
        public void SearchingResultItemsCount(string search, int count)
        {
            driver.Navigate().GoToUrl(URL);

            int actual = new Header(driver)
                .Search(search)
                .GetListProduct()
                .Count;

            Assert.AreEqual(actual, count);
        }

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search)
        {
            driver.Navigate().GoToUrl(URL);

            Assert.IsTrue(new Header(driver)
                .Search(search)
                .TestCategoriesValue(GlobalVariables.inputListCategories)
            );
        }

        [TestCase("Apple", "Tablets", 4)]
        public void TestCategoryResult(string search, string category, int count)
        {
            driver.Navigate().GoToUrl(URL);

            int actual = new Header(driver)
                .Search(search)
                .SearchByCategory(search, category);
            Assert.AreEqual(actual, count);
        }

        [TestCase("Apple")]
        public void TestLabelSearch(string search)
        {
            driver.Navigate().GoToUrl(URL);

            string actual = new Header(driver)
                .Search(search)
                .GetSearchHeader(search);
            string expected = "Search - " + search;

            Assert.AreEqual(actual, expected);
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
