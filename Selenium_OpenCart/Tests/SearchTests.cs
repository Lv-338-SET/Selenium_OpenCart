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

        const string URL = "http://40.118.125.245";

        [SetUp]
        public void SetUp()
        {
            Application.Get();
            logicSearch = new SearchMethods();
            reader = new DBDataReader();
        }

        [TearDown]
        public void closeBrowser()
        {
            Application.Remove();
        }

        [Test]
        public void SearchingResultItemsCount()
        {
            Application.Get().Browser.OpenUrl(URL);

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
            Application.Get().Browser.OpenUrl(URL);

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
            Application.Get().Browser.OpenUrl(URL);

            int actual = logicSearch
                .SearchByCategory(InputData.GetName(), InputData.GetCategory());

            Assert.AreEqual(actual, InputData.GetCount());
        }

        [Test]
        public void TestLabelSearch()
        {
            Application.Get().Browser.OpenUrl(URL);

            string actual = logicSearch
                .GetSearchHeader(InputData.GetName());

            string expected = "Search - " + InputData.GetName();

            Assert.AreEqual(expected, actual);
        }

    }
}
