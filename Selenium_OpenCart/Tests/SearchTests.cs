using System;
using NUnit.Framework;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Data.Search;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SearchTests
    {
        SearchMethods logicSearch;
        DBDataReader reader;

        ISearch InputData
            = new XMLDataParser().GetSearchInputData();
        readonly Uri Grid = new System.Uri("http://137.117.227.15:4444/wd/hub");

        [SetUp]
        public void SetUp()
        {
            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew(Grid)).Browser.OpenUrl(Application.Get().ApplicationSource.HomePageUrl);
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
            int actual = logicSearch
                .SearchByCategory(InputData.GetName(), InputData.GetCategory());

            Assert.AreEqual(actual, InputData.GetCount());
        }

        [Test]
        public void TestLabelSearch()
        {
            string actual = logicSearch
                .GetSearchHeader(InputData.GetName());

            string expected = "Search - " + InputData.GetName();

            Assert.AreEqual(expected, actual);
        }

    }
}
