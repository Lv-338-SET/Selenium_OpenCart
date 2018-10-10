using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Linq;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Tests.FeedbackTests
{
    [TestFixture]
    public class FeedbackTests
    {
        IWebDriver driver;

        const string URL = "http://40.118.125.245/";

        const string NOT_SELECTED_RATING_ALERT_TEXT = "Warning: Please select a review rating!";
        const string INVALID_REVIEW_TEXT_ALERT_TEXT = "Warning: Review Text must be between 25 and 1000 characters!";
        const string INVALID_REVIEWER_NAME_ALERT_TEXT = "Warning: Review Name must be between 3 and 25 characters!";

        const int IMPLISIT_WAIT = 5;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            //chromeOptions.AddArguments("--headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        [TearDown]
        public void AfterEachTest()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        private static readonly object[] ValidProductReview =
        {
            new object[] { ProductReviewRepository.Get().ValidHP(), ProductReviewRepository.Get().InvalidOnLeftEndgeOfBVClass() },
            new object[] { ProductReviewRepository.Get().ValidHP(), ProductReviewRepository.Get().InvalidOnRightEndgeOfBVClass() }
        };

        [Test, TestCaseSource("ValidProductReview")]
        public void TestCase703VerifyNotSelectedRatingMessage(IProductReview validReview, IProductReview invalidReview)
        {
            driver.Navigate().GoToUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(driver); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(driver)
                .Search(validReview.GetProductName())
                .GetListProduct();
            Assert.True(searchPage.Any(),
                "Step 3 Failed: No search results");

            ProductPageLogic productPage = searchPage
                .FirstOrDefault(x => x.GetTextFromProductName() == validReview.GetProductName())
                .ClickProductName();
            Assert.True(productPage.ProductPage.IsProductPageOf(validReview),
                $"Step 4 Failed: Not {validReview.GetProductName()} product page");

            ProductPageReviewLogic productReviewPage = productPage.ProductPage.ClickWriteReviewLink();
            Assert.True(productReviewPage.ProductPageReview.IsReviewPage(),
                "Step 5 Failed: Not reviews page");

            UnsuccessfullyAddedReviewPage notSelectedRatingAlertPage = productReviewPage.InputReviewWithoutRatingAndClickOnAddReviewButton(validReview);
            Assert.AreEqual(notSelectedRatingAlertPage.GetTextFromWarningAlert(), NOT_SELECTED_RATING_ALERT_TEXT,
                "Step 7 Failed: " + NOT_SELECTED_RATING_ALERT_TEXT + " message not appeared");
        }

        [Test, TestCaseSource("ValidProductReview")]
        public void TestCase704VerifyInvalidTextMessage(IProductReview validReview, IProductReview invalidReview)
        {
            driver.Navigate().GoToUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(driver); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(driver)
                .Search(validReview.GetProductName())
                .GetListProduct();
            Assert.True(searchPage.Any(),
                "Step 3 Failed: No search results");

            ProductPageLogic productPage = searchPage
                .FirstOrDefault(x => x.GetTextFromProductName() == validReview.GetProductName())
                .ClickProductName();
            Assert.True(productPage.ProductPage.IsProductPageOf(validReview),
                $"Step 4 Failed: Not {validReview.GetProductName()} product page");

            ProductPageReviewLogic productReviewPage = productPage.ProductPage.ClickWriteReviewLink();
            Assert.True(productReviewPage.ProductPageReview.IsReviewPage(),
                "Step 5 Failed: Not reviews page");

            UnsuccessfullyAddedReviewPage emptyReviewTextAlertPage = productReviewPage.InputReviewWithInvalidReviewTextAndClickOnAddReviewButton(validReview, invalidReview);
            Assert.AreEqual(emptyReviewTextAlertPage.GetTextFromWarningAlert(), INVALID_REVIEW_TEXT_ALERT_TEXT,
                "Step 7 Failed: " + INVALID_REVIEW_TEXT_ALERT_TEXT + " message not appeared");
        }

        [Test, TestCaseSource("ValidProductReview")]
        public void TestCase705VerifyInvalidRevierNameMessage(IProductReview validReview, IProductReview invalidReview)
        {
            driver.Navigate().GoToUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(driver); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(driver)
                .Search(validReview.GetProductName())
                .GetListProduct();
            Assert.True(searchPage.Any(),
                "Step 3 Failed: No search results");

            ProductPageLogic productPage = searchPage
                .FirstOrDefault(x => x.GetTextFromProductName() == validReview.GetProductName())
                .ClickProductName();
            Assert.True(productPage.ProductPage.IsProductPageOf(validReview),
                $"Step 4 Failed: Not {validReview.GetProductName()} product page");

            ProductPageReviewLogic productReviewPage = productPage.ProductPage.ClickWriteReviewLink();
            Assert.True(productReviewPage.ProductPageReview.IsReviewPage(),
                "Step 5 Failed: Not reviews page");

            UnsuccessfullyAddedReviewPage invalidReviewerNameAlertPage = productReviewPage.InputReviewWithInvalidReviewerNameAndClickOnAddReviewButton(validReview, invalidReview);
            Assert.AreEqual(invalidReviewerNameAlertPage.GetTextFromWarningAlert(), INVALID_REVIEWER_NAME_ALERT_TEXT,
                "Step 7 Failed: " + INVALID_REVIEWER_NAME_ALERT_TEXT + " message not appeared");
        }
    }
}
