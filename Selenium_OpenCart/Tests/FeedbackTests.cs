using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Linq;
using OpenQA.Selenium.Support.UI;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Data.ProductReview.ReviewStatus;
using Selenium_OpenCart.Pages.Body.ProductPage;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.AdminPages.HeaderAndNavigation;
using Selenium_OpenCart.AdminPages.Body.ReviewsPage;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    [SingleThreaded]
    public class FeedbackTests
    {
        IWebDriver driver;

        //const string URL = "http://set-338.000webhostapp.com/index.php?route=product/product&product_id=47";
        const string URL = "http://192.168.1.105/index.php?route=product/product&product_id=47";
        const string ADMIN_URL = "http://192.168.1.105/admin";

        const string REVIEWS_PAG_NAME = "Reviews";

        const int IMPLISIT_WAIT = 5;
        const int NO_IMPLISIT_WAIT = 0;
        const int EXPLISIT_WAIT = 5;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
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

        private static readonly object[] ValidProductReviewAndAdminUser =
        {
            new object[] { ProductReviewRepository.Get().Valid(), UserRepository.Get().Admin() }
        };

        private void DeleteAllTestReviewsFromValidProductReviewAndAdminUserSource()
        {
            foreach (object[] item in ValidProductReviewAndAdminUser)
            {
                Catalog menu = new LoginPageLogic(driver)
                   .InputValidUserAndLogin((IUser)item[0])
                   .Navigation.ClickOnCatalogLink();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                wait.Until(d => menu.GetTextFromReviewLink().Equals(REVIEWS_PAG_NAME));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
                menu.ClickOnReviewLink().DeleteAllReviewsThatEqualsTo((IProductReview)item[1]);
            }
        }

        [Test, TestCaseSource("ValidProductReview"), Order(1)]
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

        [Test, TestCaseSource("ValidProductReviewAndAdminUser"), Order(2)]
        public void AproveReviewTest(IProductReview review, IUser user)
        {
            driver.Navigate().GoToUrl(ADMIN_URL);

            Catalog menu = new LoginPageLogic(driver).InputValidUserAndLogin(user).Navigation.ClickOnCatalogLink();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(d => menu.GetTextFromReviewLink().Equals(REVIEWS_PAG_NAME));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
            ReviewsPageLogic page = menu.ClickOnReviewLink();
            //Assert
            Assert.AreEqual(REVIEWS_PAG_NAME, page.Header.GetTextFromCurnetPageLink()
                , "Not reviews page");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(0);
            //wait.Until(d => page.ReviewsPage.GetReviewsListIfAnyExists().Where(x => x.GetReviewStatus() == ReviewStatusList.Disabled).Any());
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ReviewsPageSuccessfullyModifiedReview page2 = page.EditReviewThatExistAndEqualsTo(review).EnableReview();
            //Assert
            Assert.True(page2.IsReviewModified());

        }

        [Test, TestCaseSource("ValidProductReview"), Order(3)]
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
