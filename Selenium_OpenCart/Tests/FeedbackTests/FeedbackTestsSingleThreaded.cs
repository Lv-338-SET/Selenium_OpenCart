using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

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
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Tests.FeedbackTests
{
    [TestFixture]
    [SingleThreaded]
    public class FeedbackTestsSingleThreaded
    {
        const string URL = "http://40.118.125.245/";
        const string ADMIN_URL = "http://40.118.125.245/admin";

        const string ADMIN_HOME_PAGE_NAME = "Dashboard";
        const string REVIEWS_PAGE_NAME = "Reviews";
        const string REVIEW_ADDED_ALERT_TEXT = "Thank you for your review. It has been submitted to the webmaster for approval.";

        bool TestCase649 = false;
        bool TestCase670 = false;

        [TearDown]
        public void AfterEachTest()
        {
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void AfterAllTest()
        {
            Application.Remove();
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
            Application.Get().Browser.OpenUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(Application.Get().Browser.Driver);  },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(Application.Get().Browser.Driver)
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
            Assert.AreEqual(addedReview.GetTextFromSuccessAllert(), REVIEW_ADDED_ALERT_TEXT,
                "Step 6 Failed: " + REVIEW_ADDED_ALERT_TEXT + " message not appeared");
            TestCase649 = true;
        }

        [Test, TestCaseSource("ValidProductReviewAndAdminUser"), Order(2)]
        public void TestCase670AproveReviewTest(IProductReview review, IUser user)
        {
            Assert.IsTrue(TestCase649,
                "Blocked. Preconditions fail: add review test failed");

            Application.Get().Browser.OpenUrl(ADMIN_URL);

            LoginPageLogic loginPage = new LoginPageLogic();
            Assert.True(loginPage.LoginPage.IsLoginPage(), 
                "Step 1 Failed: Not login page");

            AdminPageLogic homePage = loginPage.InputValidUserAndLogin(user);
            Assert.AreEqual(homePage.Header.GetTextFromCurnetPageLable(), ADMIN_HOME_PAGE_NAME,
                "Step 2 Failed: Not admin home page");
             Catalog catalog = homePage.Navigation.ClickOnCatalogLink();

            ReviewsPageLogic reviewsPage = catalog.ClickOnReviewLink();
            Assert.True(reviewsPage.ReviewsPage.IsReviewsPage(), 
                "Step 3 Failed: Not reviews page");

            EditReviewPageLogic page2 = reviewsPage.EditReviewThatEqualsTo(review);
            Assert.True(page2.EditReviewPage.IsEditReviewPage(), 
                "Step 4 Failed: Not edit review page");

            ReviewsPageSuccessAllert successfullyModifiedReview = page2.EnableReview();
            Assert.True(successfullyModifiedReview.IsReviewModified(), 
                "Step 5 Failed: Review wasn't approved");
            TestCase670 = true;
        }

        [Test, TestCaseSource("ValidProductReview"), Order(3)]
        public void TestCase672CheckReviewTest(IProductReview review)
        {
            Assert.IsTrue(TestCase649 && TestCase670, 
                "Blocked. Preconditions fail: add review test failed or approve review test failed");

            Application.Get().Browser.OpenUrl(URL);

            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(Application.Get().Browser.Driver); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods(Application.Get().Browser.Driver)
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
        public void TestCase712DeleteReview (IProductReview review, IUser user)
        {
            Assert.IsTrue(TestCase649,
                "Blocked. Preconditions fail: add review test failed");

            Application.Get().Browser.OpenUrl(ADMIN_URL);

            LoginPageLogic loginPage = new LoginPageLogic();
            Assert.True(loginPage.LoginPage.IsLoginPage(),
                "Step 1 Failed: Not login page");

            AdminPageLogic homePage = loginPage.InputValidUserAndLogin(user);
            Assert.AreEqual(homePage.Header.GetTextFromCurnetPageLable(), ADMIN_HOME_PAGE_NAME,
                "Step 2 Failed: Not admin home page");
            Catalog catalog = homePage.Navigation.ClickOnCatalogLink();

            ReviewsPageLogic reviewsPage = catalog.ClickOnReviewLink();
            Assert.True(reviewsPage.ReviewsPage.IsReviewsPage(),
                "Step 3 Failed: Not reviews page");

            ReviewsPageSuccessAllert page2 = reviewsPage.DeleteAllReviewsThatEqualsTo(review);
            Assert.True(page2.IsReviewModified(),
                "Step 4 Failed: Review wasn't deleted");
        }
    }
}
