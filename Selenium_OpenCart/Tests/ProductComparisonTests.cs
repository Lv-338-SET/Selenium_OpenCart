using NUnit.Framework;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ProductComparisonPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Constants;
using System;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    public class ProductComparisonTests
    {
        readonly Uri Grid = new System.Uri(CONST_EN.ANDRII_SELENIUM_HUB_URL);

        Application application;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            application = Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew(Grid));
        }

        [SetUp]
        public void BeforeEachTest()
        {
            application.Browser.OpenUrl(application.ApplicationSource.HomePageUrl);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Application.Remove();
        }

        [TearDown]
        public void AfterEachTest()
        {
            application.Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-722
        [TestCase(CONST_EN.PHONE, CONST_EN.SUCCESSFUL_COMPARISON_MESSAGE)]
        public void ProductComparison_AddProductFromSearchPage_SuccessfulMessageDisplayed(string product, string conparisonMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(product)
                .AddAppropriateProductToComparison(product);

            Assert.AreEqual(conparisonMessage, searchPage.successAlertMessageText(),
                "An invalid comparison message on the Search page is displayed.");
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-719
        [TestCase(CONST_EN.PHONE, CONST_EN.SUCCESSFUL_COMPARISON_MESSAGE)]
        public void ProductComparison_AddProductFromProductPage_SuccessfulMessageDisplayed(string product, string conparisonMessage)
        {
            SearchPage searchPage = new SearchMethods().Search(product);
            SuccessfullyAddedProductForComparisonPage productPage = searchPage
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton();

            Assert.AreEqual(conparisonMessage, productPage.GetTextFromCompareProductsPageMessage(),
                "An invalid comparison message on the Product page is displayed.");
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-660
        [TestCase(CONST_EN.PHONE)]
        public void ProductComparison_ClickingTwoTimesCompareButton_OneProductAdded(string product)
        {
            SearchPage searchPage = new SearchMethods().Search(product);
            ProductComparisonPage comparePage = searchPage
                .AddAppropriateProductToComparison(product)
                .OpenAppropriateProductPage(product)
                .ClickOnCompareProductButton()
                .ClickOnCompareProductsPageLink();

            Assert.AreEqual(product, comparePage.GetLastProductNameText(), "The selected product wasn't added to the comparison table.");
            Assert.True(comparePage.CountColumns() == 1, "One product is added to the comparison table several times.");
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-674
        [TestCase(CONST_EN.DESKTOP, CONST_EN.DESKTOP_FIRST, CONST_EN.DESKTOP_SECOND)]
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
            Assert.True(comparePage.CountColumns() == 2, "All or one of products aren't added to the comparison table.");
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-720
        [TestCase(CONST_EN.DESKTOP, CONST_EN.DESKTOP_FIRST, CONST_EN.DESKTOP_SECOND, CONST_EN.EDIT_TABLE_COMPARISON_MESSAGE)]
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
                "An invalid comparison message on the Product page is displayed.");
            Assert.True(comparePage.CountColumns() == 1, "A comparison table with at least two columns " +
                "is present on the page after removing second product.");
        }

        //Jira Test Case: https://ssu-jira.softserveinc.com/browse/CCCXXXVIII-673
        [TestCase(CONST_EN.PHONE, CONST_EN.EMPTY_TABLE_COMPARISON_MESSAGE)]
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
                "is present on the page after removing the product.");
            Assert.AreEqual(conparisonNoProductsMessage, comparePage.GetNoProductsToCompareLabelText(), "An invalid comparison message is displayed.");
        }
    }
}
