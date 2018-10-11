using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ProductComparisonPage;
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
        IWebDriver driver;
        const string URL = "http://40.118.125.245/";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//TODO!!!!!!!!!!!!!!

            driver.Navigate().GoToUrl(URL);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-660
        [TestCase("iMac")]
        public void ProductComparison_ClickingTwoTimesCompareButton_OneProductAdded(string product)
        {
            //Arrange
            SearchMethods addedToComparisonProduct = new SearchMethods();
            ProductComparisonPage columns = new ProductComparisonPage(driver);
            //Act
            //addedToComparisonProduct.Search(product)
            //    .AddAppropriateProductToComparison(product)
            //    .OpenAppropriateProductPage(product)
            //    .ClickOnCompareProductButton()
            //    .ClickOnCompareProductsPageLink()
            //    .GetFirstProductNameText();
            //Assert
            Assert.AreEqual(product, addedToComparisonProduct, "The selected product was not added to the comparison table.");            
            Assert.True(columns.CountColumns() == 1, "One product is added to the comparison table several times.");
        }


    }
}
