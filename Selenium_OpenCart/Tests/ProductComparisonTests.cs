using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ProductComparisonPage;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    public class ProductComparisonTests
    {
        const string URL = "http://40.118.125.245/";

        [SetUp]
        public void BeforeEachTest()
        {
            Application.Get();
        }

        [TearDown]
        public void AfterEachTest()
        {
            Application.Remove();
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-660
        [TestCase("iMac")]
        public void ProductComparison_ClickingTwoTimesCompareButton_OneProductAdded(string product)
        {
            Application.Get().Browser.OpenUrl(URL);

            //Arrange
            SearchPage searchPage = new SearchMethods(Application.Get().Browser.Driver).Search(product);
            ProductComparisonPage comparePage = searchPage
                .AddAppropriateProductToComparison(product)
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton()
                .ClickOnCompareProductsPageLink();
            //Assert
            Assert.AreEqual(product, comparePage.GetFirstProductNameText(), "The selected product was not added to the comparison table.");            
            Assert.True(comparePage.CountColumns() == 1, "One product is added to the comparison table several times.");
        }


    }
}
