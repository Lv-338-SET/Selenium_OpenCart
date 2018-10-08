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
using Selenium_OpenCart.Logic;
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

        const string URL = "http://40.118.125.245/";
        const string ADMIN_URL = "http://40.118.125.245/admin";

        const string REVIEWS_PAG_NAME = "Reviews";

        const int IMPLISIT_WAIT = 5;
        const int NO_IMPLISIT_WAIT = 0;
        const int EXPLISIT_WAIT = 1;

        bool addedReview = false;
        bool approvedReview = false;

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
            DeleteAllTestReviewsFromValidProductReviewAndAdminUserSource();

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

        private void DeleteAllTestReviewsFromValidProductReviewAndAdminUserSource()
        {
            foreach (object[] item in ValidProductReviewAndAdminUser)
            {
                IUser user = item[1] as IUser;
                IProductReview review = item[0] as IProductReview;

                driver.Navigate().GoToUrl(ADMIN_URL);

                Catalog menu = new LoginPageLogic(driver)
                   .InputValidUserAndLogin(user)
                   .Navigation.ClickOnCatalogLink();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLISIT_WAIT));

                wait.Until(d => menu.GetTextFromReviewLink().Equals(REVIEWS_PAG_NAME));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);

                menu.ClickOnReviewLink().DeleteAllReviewsThatEqualsTo(review);
            }
        }

        [Test, TestCaseSource("ValidProductReview"), Order(1)]
        public void AddReviewTest(IProductReview review)
        {
            driver.Navigate().GoToUrl(URL);
            ProductPageLogic productPage = new SearchMethods(driver)
                .Search(review.GetProductName())
                .GetListProduct()
                .FirstOrDefault(x => x.GetTextFromProductName() == review.GetProductName()).ClickProductName();
            //Assert
            Assert.AreEqual(review.GetProductName(), productPage.ProductPage.GetProductNameText(),
                $"Not {review.GetProductName()} product page");

            ProductPageSuccessfullyAddedReview page2 = productPage.ProductPage.ClickWriteReviewLink()
                .InputValidReviewAndClickOnAddReviewButton(review);
            //Asser
            Assert.True(page2.IsReviewAdded(),
                "Review not added");
            addedReview = true;
        }

        [Test, TestCaseSource("ValidProductReviewAndAdminUser"), Order(2)]
        public void AproveReviewTest(IProductReview review, IUser user)
        {
            Assert.IsTrue(addedReview
                , "Blocked. Preconditions fail: add review test failed");

            driver.Navigate().GoToUrl(ADMIN_URL);

            Catalog menu = new LoginPageLogic(driver).InputValidUserAndLogin(user).Navigation.ClickOnCatalogLink();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromTicks(NO_IMPLISIT_WAIT);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLISIT_WAIT));

            wait.Until(d => menu.GetTextFromReviewLink().Equals(REVIEWS_PAG_NAME));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLISIT_WAIT);

            ReviewsPageLogic page = menu.ClickOnReviewLink();
            //Assert
            Assert.AreEqual(REVIEWS_PAG_NAME, page.Header.GetTextFromCurnetPageLink()
                , "Not reviews page");

            ReviewsPageSuccessfullyModifiedReview page2 = page.EditReviewThatExistAndEqualsTo(review).EnableReview();
            //Assert
            Assert.True(page2.IsReviewModified());
            approvedReview = true;
        }

        [Test, TestCaseSource("ValidProductReview"), Order(3)]
        public void CheckReviewTest(IProductReview review)
        {
            Assert.IsTrue(addedReview && approvedReview
                , "Blocked. Preconditions fail: add review test failed or approve review test failed");

            driver.Navigate().GoToUrl(URL);
            ProductPageLogic productPage = new SearchMethods(driver)
                .Search(review.GetProductName())
                .GetListProduct()
                .FirstOrDefault(x => x.GetTextFromProductName() == review.GetProductName()).ClickProductName();
            //Assert
            Assert.AreEqual(review.GetProductName(), productPage.ProductPage.GetProductNameText(),
                $"Not {review.GetProductName()} product page");

            bool hasReview = productPage.ProductPage.ClickReviewsLink().ProductPageReview.ReviewExistInListOfReview(review);
            Assert.True(hasReview);
        }
    }
}
