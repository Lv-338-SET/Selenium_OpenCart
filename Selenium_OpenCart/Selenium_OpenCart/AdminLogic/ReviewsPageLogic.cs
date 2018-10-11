using System.Linq;

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
                return new ReviewsPage();
            }
        }

        public ReviewsPageLogic()
        {

        }

        /// <summary>
        /// Deletes all reviews on page
        /// </summary>
        /// <returns>ReviewsPageSuccessAllert page</returns>
        public ReviewsPageSuccessAllert DeleteAllReviews()
        {
            ReviewsPage.SelectAllReviews();
            ReviewsPage.DeleteReview();
            return new ReviewsPageSuccessAllert();
        }

        /// <summary>
        /// Open edit review page if these review is on page
        /// </summary>
        /// <param name="productReview">Review data in IProductReview format</param>
        /// <returns>EditReviewPageLogic page if review exist and null if not</returns>
        public EditReviewPageLogic EditReviewThatEqualsTo(IProductReview productReview)
        {
            ReviewItem tmp = ReviewsPage.GetReviewsListIfAnyExists().FirstOrDefault(x => x.Equals(productReview));
            if (tmp != null)
            {
                tmp.ClickOnEditLink();
                return new EditReviewPageLogic();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes all review on the page that equals to some review
        /// </summary>
        /// <param name="productReview">Review data in IProductReview format</param>
        /// <returns>ReviewsPageSuccessAllert page</returns>
        public ReviewsPageSuccessAllert DeleteAllReviewsThatEqualsTo(IProductReview productReview)
        {
            foreach (ReviewItem item in ReviewsPage.GetReviewsListIfAnyExists().Where(x => x.Equals(productReview)))
            {
                item.SelectReview();
            }
            ReviewsPage.DeleteReview();
            return new ReviewsPageSuccessAllert();
        }
    }
}
