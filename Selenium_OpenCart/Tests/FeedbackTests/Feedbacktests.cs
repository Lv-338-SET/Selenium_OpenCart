using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;
using System;

namespace Selenium_OpenCart.Tests.FeedbackTests
{
    [TestFixture]
    [Parallelizable]
    public class FeedbackTests
    {
        const string URL = "http://40.118.125.245/";

        const string NOT_SELECTED_RATING_ALERT_TEXT = "Warning: Please select a review rating!";
        const string INVALID_REVIEW_TEXT_ALERT_TEXT = "Warning: Review Text must be between 25 and 1000 characters!";
        const string INVALID_REVIEWER_NAME_ALERT_TEXT = "Warning: Review Name must be between 3 and 25 characters!";
        readonly Uri Grid = new System.Uri(Data.Constants.CONST_EN.LEMM_SELENIUM_HUB_URL);

        [SetUp]
        public void BeforeEachTest()
        {
            //System.Diagnostics.Debugger.Launch();
            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew(Grid)).Browser.OpenUrl(URL);
        }

        [TearDown]
        public void AfterEachTest()
        {
            Application.Remove();
        }

        private static readonly object[] RatingProductReview =
{
            new object[] { ProductReviewRepository.Get().ValidHP(), ProductReviewRepository.Get().InvalidOnLeftEndgeOfBVClass() }
        };

        private static readonly object[] ProductReview =
        {
            new object[] { ProductReviewRepository.Get().ValidHP(), ProductReviewRepository.Get().InvalidOnLeftEndgeOfBVClass() },
            new object[] { ProductReviewRepository.Get().ValidHP(), ProductReviewRepository.Get().InvalidOnRightEndgeOfBVClass() }
        };

        /// <summary>
        /// http://ssu-jira.softserveinc.com/browse/CCCXXXVIII-703
        /// </summary>
        [Test, TestCaseSource("RatingProductReview")]
        public void TestCase703VerifyNotSelectedRatingMessage(IProductReview validReview, IProductReview invalidReview)
        {
            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods()
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

        /// <summary>
        /// http://ssu-jira.softserveinc.com/browse/CCCXXXVIII-704
        /// </summary>
        [Test, TestCaseSource("ProductReview")]
        public void TestCase704VerifyInvalidTextMessage(IProductReview validReview, IProductReview invalidReview)
        {
            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods()
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

        /// <summary>
        /// http://ssu-jira.softserveinc.com/browse/CCCXXXVIII-705
        /// </summary>
        [Test, TestCaseSource("ProductReview")]
        public void TestCase705VerifyInvalidRevierNameMessage(IProductReview validReview, IProductReview invalidReview)
        {
            HomePage homePage;
            Assert.DoesNotThrow(() => { homePage = new HomePage(); },
                "Step 1 Failed: Not home page");

            List<ProductItem> searchPage = new SearchMethods()
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
