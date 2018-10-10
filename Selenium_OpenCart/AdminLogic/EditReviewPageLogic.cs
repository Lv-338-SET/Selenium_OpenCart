using OpenQA.Selenium;

using Selenium_OpenCart.AdminPages.Body.ReviewsPage;
using Selenium_OpenCart.AdminPages.Body.EditReviewPage;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.ReviewStatus;

namespace Selenium_OpenCart.AdminLogic
{
    public sealed class EditReviewPageLogic : AdminPageLogic
    {
        public EditReviewPage EditReviewPage
        {
            get
            {
                return new EditReviewPage(driver);
            }
        }

        public EditReviewPageLogic(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Eneble review if it is equalt to another
        /// </summary>
        /// <param name="productReview">Review data in IProductReview format</param>
        /// <returns>ReviewsPageSuccessAllert page if review equals and null if not</returns>
        public ReviewsPageSuccessAllert EnableReviewIfEqualsTo(IProductReview productReview)
        {
            if (EditReviewPage.Equals(productReview))
            {
                return EnableReview();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Eneble review
        /// </summary>
        /// <param name="productReview">Review data in IProductReview format</param>
        /// <returns>ReviewsPageSuccessAllert page</returns>
        public ReviewsPageSuccessAllert EnableReview()
        {
            EditReviewPage.SetReviewStatus(ReviewStatusList.Enabled);
            EditReviewPage.ClickOnSaveButton();
            return new ReviewsPageSuccessAllert(driver);
        }
    }
}
