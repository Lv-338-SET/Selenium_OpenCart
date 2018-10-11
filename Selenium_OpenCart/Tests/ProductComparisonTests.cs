using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ProductComparisonPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
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
        Application application;

        [OneTimeSetUp]
        public void BeforeEachTest()
        {
            application = Application.Get(ApplicationSourceRepository.Default());
        }

        [SetUp]
        public void Beforetest()
        {
            application.Browser.OpenUrl(application.ApplicationSource.HomePageUrl);
        }

        [OneTimeTearDown]
        public void AfterEachTest()
        {
            Application.Remove();
        }

        [TearDown]
        public void EachTest()
        {
            application.Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        //Jira Test Case:
        [TestCase("iPhone", "Success: You have added iPhone to your product comparison!\r\n×")]
        public void ProductComparison_AddProductFromSearchPage_SuccessfulMessageDisplayed(string product, string conparisonMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(product)
                .AddAppropriateProductToComparison(product);

            Assert.AreEqual(conparisonMessage, searchPage.successAlertMessageText(), 
                "An invalid comparison message on Search page is displayed.");
        }

        //Jira Test Case:
        [TestCase("iPhone", "Success: You have added iPhone to your product comparison!\r\n×")]
        public void ProductComparison_AddProductFromProductPage_SuccessfulMessageDisplayed(string product, string conparisonMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(product);
            SuccessfullyAddedProductForComparisonPage productPage = searchPage
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton();

            Assert.AreEqual(conparisonMessage, productPage.GetTextFromCompareProductsPageMessage(),
                "An invalid comparison message on Product page is displayed.");
        }
        //N
        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-660
        [TestCase("iPhone")]
        public void ProductComparison_ClickingTwoTimesCompareButton_OneProductAdded(string product)
        {
            SearchPage searchPage = new SearchMethods().Search(product);
            ProductComparisonPage comparePage = searchPage
                .AddAppropriateProductToComparison(product)
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton()
                .ClickOnCompareProductsPageLink();

            Assert.AreEqual(product, comparePage.GetLastProductNameText(), "The selected product was not added to the comparison table.");
            Assert.True(comparePage.CountColumns() == 1, "One product is added to the comparison table several times.");
        }
        
        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-674
        [TestCase("Mac", "MacBook", "MacBook Air")]
        public void ProductComparison_TwoDifferentProducts_AddedToComparisonTable
            (string Desktop, string FirstDesktop, string SecondDesktop)
        {
            SearchPage searchPage = new SearchMethods().Search(Desktop);
            ProductComparisonPage comparePage = searchPage
                .AddAppropriateProductToComparison(FirstDesktop)
                .AddAppropriateProductToComparison(SecondDesktop)
                .ClickSuccessAlertMessageLink();

            Assert.AreEqual(FirstDesktop, comparePage.GetFirstProductNameText(), "The selected product was not added to the comparison table.");
            Assert.AreEqual(SecondDesktop, comparePage.GetLastProductNameText(), "The selected product was not added to the comparison table.");
            Assert.True(comparePage.CountColumns() == 2, "All or one of products isn't added to the comparison table.");
        }

        //Jira Test Case:
        [TestCase("Mac", "MacBook", "MacBook Air", "Success: You have modified your product comparison!\r\n×")]
        public void ProductComparison_AddTwoDifferemntProducts_SuccessfulRemoveMessageDisplayed
            (string Desktop, string FirstDesktop, string SecondDesktop, string conparisonRemoveMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(Desktop);
            ProductComparisonPageWithMessage comparePage = searchPage
                .AddAppropriateProductToComparison(FirstDesktop)
                .AddAppropriateProductToComparison(SecondDesktop)
                .ClickSuccessAlertMessageLink()
                .ClickRemoveLastProduct();

            Assert.AreEqual(conparisonRemoveMessage, comparePage.GetSuccessMessageText(), 
                "An invalid comparison message on Product page is displayed.");
            Assert.True(comparePage.CountColumns() == 1, "A comparison table with at least two columns " +
                "is present on the page after second product is removed.");
        }
        
        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-673
        [TestCase("iPhone", "Your shopping cart is empty!")]
        public void ProductComparison_AddedPreviouslyProduct_RemovedFromComparison(string product, string conparisonNoProductsMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(product);
            EmptyProductComparisonPageWithMessage comparePage = searchPage
                .AddAppropriateProductToComparison(product)
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton()
                .ClickOnCompareProductsPageLink()
                .ClickRemoveFirstProduct();

            Assert.True(comparePage.CountColumns() == 0, "A comparison table with at least one column " +
                "is present on the page after the product is removed.");
            Assert.AreEqual(conparisonNoProductsMessage, comparePage.GetNoProductsToCompareLabelText(), "An invalid comparison message is displayed.");
        }
    }    
}
