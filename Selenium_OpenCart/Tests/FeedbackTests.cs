using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Pages.Body.ProductPage;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    public class FeedbackTests
    {
        IWebDriver driver;
        //const string URL = "http://set-338.000webhostapp.com/index.php?route=product/product&product_id=47";
        const string URL = "http://192.168.1.105/index.php?route=product/product&product_id=47";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        private static readonly object[] ValidProductReview =
        {
            new object[] { ProductReviewRepository.Get().Valid() }
        };

        [Test, TestCaseSource("ValidProductReview")]
        public void AddReviewTest(IProductReview review)
        {
            //USE SERGIY SEARCH METHODS
            driver.Navigate().GoToUrl(URL);
            ProductPage page = new ProductPage(driver);
            Assert.AreEqual(review.GetProductName(), page.GetProductNameText(),
                $"Not {review.GetProductName()} product page");
            ProductPageSuccessfullyAddedReview page2 = page.ClickWriteReviewLink()
                .InputValidReviewAndClickOnAddReviewButton(review);
            Assert.True(page2.IsReviewAdded(),
                "Review not added");
        }

        [Test, TestCaseSource("ValidProductReview")]
        public void CheckReviewTest(IProductReview review)
        {
            //USE SERGIY SEARCH METHODS
            driver.Navigate().GoToUrl(URL);
            ProductPage page = new ProductPage(driver);
            Assert.AreEqual(review.GetProductName(), page.GetProductNameText(),
                $"Not {review.GetProductName()} product page");
            List<ReviewItem> myReview = page.ClickReviewsLink().GetReviewsList();
            bool hasReview = page.ClickReviewsLink().ReviewExistInListOfReview(review);
            Assert.True(hasReview);
        }
    }
}
