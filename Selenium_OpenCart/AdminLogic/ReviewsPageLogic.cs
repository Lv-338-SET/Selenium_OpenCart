using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.AdminPages.Body.ReviewsPage;
using Selenium_OpenCart.Data.ProductReview;

namespace Selenium_OpenCart.AdminLogic
{
    public class ReviewsPageLogic : AdminPageLogic
    {
        public ReviewsPage ReviewsPage
        {
            get
            {
                return new ReviewsPage(driver);
            }
        }

        public ReviewsPageLogic(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public ReviewsPageSuccessfullyModifiedReview DeleteAllReviews()
        {
            ReviewsPage.SelectAllReviews();
            ReviewsPage.DeleteReview();
            return new ReviewsPageSuccessfullyModifiedReview(driver);
        }

        public EditReviewPageLogic EditReviewThatExistAndEqualsTo(IProductReview productReview)
        {
            ReviewsPage.GetReviewsListIfAnyExists().FirstOrDefault(x => x.Equals(productReview)).ClickOnEditLink();
            return new EditReviewPageLogic(driver);
        }

        public ReviewsPageSuccessfullyModifiedReview DeleteAllReviewsThatEqualsTo(IProductReview productReview)
        {
            foreach (ReviewItem item in ReviewsPage.GetReviewsListIfAnyExists().Where(x => x.Equals(productReview)))
            {
                item.SelectReview();
            }
            ReviewsPage.DeleteReview();
            return new ReviewsPageSuccessfullyModifiedReview(driver);
        }
    }
}
