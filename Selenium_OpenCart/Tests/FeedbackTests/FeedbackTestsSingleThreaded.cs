using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Linq;
using OpenQA.Selenium.Support.UI;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.AdminPages.HeaderAndNavigation;
using Selenium_OpenCart.AdminPages.Body.ReviewsPage;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Tests.FeedbackTests
{
    [TestFixture]
    [SingleThreaded]
    public class FeedbackTestsSingleThreaded
    {
        IWebDriver driver;

        const string URL = "http://40.118.125.245/";
        const string ADMIN_URL = "http://40.118.125.245/admin";

        const string REVIEWS_PAGE_NAME = "Reviews";
        const string REVIEW_ADDED_ALERT_TEXT = "Thank you for your review. It has been submitted to the webmaster for approval.";

        const int IMPLISIT_WAIT = 5;
        const int NO_IMPLISIT_WAIT = 0;
        const int EXPLISIT_WAIT = 1;

        bool TestCase649 = false;
        bool TestCase670 = false;

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

        [TearDown]
        public void AfterEachTest()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        private static readonly object[] ValidProductReview =
{
            new object[] { ProductReviewRepository.Get().ValidHP() }
        };

        private static readonly object[] ValidProductReviewAndAdminUser =
        {
            new object[] { ProductReviewRepository.Get().ValidHP(), UserRepository.Get().Admin() }           
        };

        [Test, TestCaseSource("ValidProductReview"), Order(1)]
        public void TestCase649AddReviewTest(IProductReview review)
        {
            driver.Navigate().GoToUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(driver);  },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(driver)
                .Search(review.GetProductName())
                .GetListProduct();
            Assert.True(searchPage.Any(), 
                "Step 3 Failed: No search results");

            ProductPageLogic productPage = searchPage
                .FirstOrDefault(x => x.GetTextFromProductName() == review.GetProductName())
                .ClickProductName();
            Assert.True(productPage.ProductPage.IsProductPageOf(review),
                $"Step 4 Failed: Not {review.GetProductName()} product page");

            ProductPageReviewLogic productReviewPage = productPage.ProductPage.ClickWriteReviewLink();
            Assert.True(productReviewPage.ProductPageReview.IsReviewPage(), 
                "Step 5 Failed: Not reviews page");
             
            SuccessfullyAddedReviewPage addedReview = productReviewPage.InputValidReviewAndClickOnAddReviewButton(review);
            Assert.AreEqual(addedReview.GetSuccessAllertText(), REVIEW_ADDED_ALERT_TEXT,
                "Step 6 Failed: " + REVIEW_ADDED_ALERT_TEXT + " message not appeared");
            TestCase649 = true;
        }

        [Test, TestCaseSource("ValidProductReviewAndAdminUser"), Order(2)]
        public void TestCase670AproveReviewTest(IProductReview review, IUser user)
        {
            Assert.IsTrue(TestCase649, 
                "Blocked. Preconditions fail: add review test failed");

            driver.Navigate().GoToUrl(ADMIN_URL);

            LoginPageLogic loginPage = new LoginPageLogic(driver);
            Assert.True(loginPage.LoginPage.IsLoginPage(), 
                "Step 1 Failed: Not login page");

            AdminPageLogic homePage = new LoginPageLogic(driver).InputValidUserAndLogin(user);
            Assert.True(homePage.Header.IsHomePage(), 
                "Step 2 Failed: Not admin home page");
             Catalog catalog = homePage.Navigation.ClickOnCatalogLink();

            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLISIT_WAIT));

            wait.Until(d => catalog.GetTextFromReviewLink().Equals(REVIEWS_PAGE_NAME));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
            //

            ReviewsPageLogic reviewsPage = catalog.ClickOnReviewLink();
            Assert.True(reviewsPage.ReviewsPage.IsReviewsPage(), 
                "Step 3 Failed: Not reviews page");

            EditReviewPageLogic page2 = reviewsPage.EditReviewThatExistAndEqualsTo(review);
            Assert.True(page2.EditReviewPage.IsEditReviewPage(), 
                "Step 4 Failed: Not edit review page");

            ReviewsPageSuccessfullyModifiedReview successfullyModifiedReview = page2.EnableReview();
            Assert.True(successfullyModifiedReview.IsReviewModified(), 
                "Step 5 Failed: Review wasn't approved");
            TestCase670 = true;
        }

        [Test, TestCaseSource("ValidProductReview"), Order(3)]
        public void TestCase672CheckReviewTest(IProductReview review)
        {
            Assert.IsTrue(TestCase649 && TestCase670, 
                "Blocked. Preconditions fail: add review test failed or approve review test failed");

            driver.Navigate().GoToUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(driver); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(driver)
                .Search(review.GetProductName())
                .GetListProduct();
            Assert.True(searchPage.Any(), 
                "Step 3 Failed: No search results");

            ProductPageLogic productPage = searchPage
                .FirstOrDefault(x => x.GetTextFromProductName() == review.GetProductName())
                .ClickProductName();
            Assert.True(productPage.ProductPage.IsProductPageOf(review),
                $"Step 4 Failed: Not {review.GetProductName()} product page");

            ProductPageReviewLogic productReviewPage = productPage.ProductPage.ClickWriteReviewLink();
            Assert.True(productReviewPage.ProductPageReview.IsReviewPage(), 
                "Step 5 Failed: Not reviews page");

            bool hasReview = productReviewPage.ProductPageReview.ReviewExistInListOfReview(review);
            Assert.True(hasReview,
                "Step 6 Failed: Review not exist");
        }

        [Test, TestCaseSource("ValidProductReviewAndAdminUser"), Order(4)]
        public void TestCase_DeleteReview (IProductReview review, IUser user)
        {
            Assert.IsTrue(TestCase649,
                "Blocked. Preconditions fail: add review test failed");

            driver.Navigate().GoToUrl(ADMIN_URL);

            LoginPageLogic loginPage = new LoginPageLogic(driver);
            Assert.True(loginPage.LoginPage.IsLoginPage(),
                "Step 1 Failed: Not login page");

            AdminPageLogic homePage = new LoginPageLogic(driver).InputValidUserAndLogin(user);
            Assert.True(homePage.Header.IsHomePage(),
                "Step 2 Failed: Not admin home page");
            Catalog catalog = homePage.Navigation.ClickOnCatalogLink();

            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLISIT_WAIT));

            wait.Until(d => catalog.GetTextFromReviewLink().Equals(REVIEWS_PAGE_NAME));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);
            //

            ReviewsPageLogic reviewsPage = catalog.ClickOnReviewLink();
            Assert.True(reviewsPage.ReviewsPage.IsReviewsPage(),
                "Step 3 Failed: Not reviews page");

            ReviewsPageSuccessfullyModifiedReview page2 = reviewsPage.DeleteAllReviewsThatEqualsTo(review);
            Assert.True(page2.IsReviewModified(),
                "Step 4 Failed: Review wasn't deleted");
        }
    }
}
