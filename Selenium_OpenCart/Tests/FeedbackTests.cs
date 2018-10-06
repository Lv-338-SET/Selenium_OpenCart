using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Pages.Body.ProductPage;
using Selenium_OpenCart.Logic.ProductPageLogic;

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

            ProductPageReviewLogic productPage = new ProductPageReviewLogic(driver);
            //Assert
            Assert.AreEqual(review.GetProductName(), productPage.ProductPage.GetProductNameText(),
                $"Not {review.GetProductName()} product page");

            ProductPageSuccessfullyAddedReview page2 = productPage.ProductPage.ClickWriteReviewLink()
                .InputValidReviewAndClickOnAddReviewButton(review);
            //Asser
            Assert.True(page2.IsReviewAdded(),
                "Review not added");
        }

        [Test, TestCaseSource("ValidProductReview")]
        public void CheckReviewTest(IProductReview review)
        {
            //USE SERGIY SEARCH METHODS
            driver.Navigate().GoToUrl(URL);

            ProductPageReviewLogic productPage = new ProductPageReviewLogic(driver);
            //Assert
            Assert.AreEqual(review.GetProductName(), productPage.ProductPage.GetProductNameText(),
                $"Not {review.GetProductName()} product page");

            bool hasReview = productPage.ProductPage.ClickReviewsLink().ProductPageReview.ReviewExistInListOfReview(review);
            Assert.True(hasReview);
        }
    }
}
