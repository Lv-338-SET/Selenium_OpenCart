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

        public ReviewsPageSuccessfullyModifiedReview EnableReviewIfEqualsTo(IProductReview productReview)
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

        public ReviewsPageSuccessfullyModifiedReview EnableReview()
        {
            EditReviewPage.SetReviewStatus(ReviewStatusList.Enabled);
            EditReviewPage.ClickOnSaveButton();
            return new ReviewsPageSuccessfullyModifiedReview(driver);
        }
    }
}
