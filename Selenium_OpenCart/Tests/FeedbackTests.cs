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
        const string URL = "http://192.168.96.124/index.php?route=product/product&product_id=47";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            driver = new ChromeDriver();
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
            Assert.AreEqual(review.GetProductName(), page.GetProductNameText());
            ProductPageSuccessfullyAddedReview page2 = page.ClickWriteReviewLink()
                .InputValidReviewAndClickOnAddReviewButton(review);
            Assert.True(page2.IsReviewAdded());
        }

        [Test, TestCaseSource("ValidProductReview")]
        public void CheckReviewTest(IProductReview review)
        {
            //USE SERGIY SEARCH METHODS
            driver.Navigate().GoToUrl(URL);
            ProductPage page = new ProductPage(driver);
            Assert.AreEqual(review.GetProductName(), page.GetProductNameText());
            List<ReviewItem> myReview = page.ClickReviewsLink().GetReviewsList();
            Assert.NotNull(myReview.FirstOrDefault(x => x.GetProductNameText() == review.GetProductName()
                && x.GetReviewerNameText() == review.GetReviewerName()
                && x.GetReviewDate() == review.GetDate()
                && x.GetReviewText() == review.GetReviewText()
                && x.GetRaiting() == review.GetRaiting()));
        }
    }
}
