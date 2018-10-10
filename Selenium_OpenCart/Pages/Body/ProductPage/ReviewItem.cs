using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.Rating;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ReviewItem : ProductPageReview
    {
        #region Properties
        private IWebElement currnetReview;

        private IWebElement ReviewerName
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td//strong"));
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td[@class='text-right']"));
            }
        }

        private IWebElement ReviewText
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td//p"));
            }
        }

        private List<IWebElement> Rating
        {
            get
            {
                return currnetReview.FindElements(By.XPath(".//tr//td//span")).ToList();
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewItem(IWebElement currnetReview)
        {
            this.currnetReview = currnetReview;
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = ReviewerName;
            tmp = ReviewDate;
            tmp = ReviewText;
            List<IWebElement> tmp2 = Rating;
            if (tmp2.Count != RatingRepository.ListOfRating.Count)
            {
                throw new CountRatingExeption("Rating don't have 5 stars, it has " + tmp2.Count);
            }
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsReview()
        {
            return VerifyPage();
        }

        #region Atomic operations for ReviewerName
        public string GetTextFromReviewerName()
        {
            return ReviewerName.Text;
        }
        #endregion

        #region Atomic operations for ReviewDate
        public string GetReviewDate()
        {
            return ReviewDate.Text;
        }
        #endregion

        #region Atomic operations for ReviewText
        public string GetReviewText()
        {
            return ReviewText.Text;
        }
        #endregion

        #region Atomic operations for Rating
        /// <summary>
        /// Get review rating in RatingList enum format
        /// </summary>
        /// <returns>review rating in RatingList enum format</returns>
        public RatingList GetRating()
        {
            int raiting = 0;
            for (int i = 0; i < this.Rating.Count; i++)
            {
                if (Rating[i].FindElements(By.XPath(".//i[@class='fa fa-star fa-stack-2x']")).Any())
                {
                    raiting = (i + 1);
                }
            }
            return raiting.ToRating();
        }
        #endregion
        #endregion

        #region overrided Methods and Operators
        public static bool operator ==(ReviewItem first, object second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(ReviewItem first, object second)
        {
            return !first.Equals(second);
        }

        /// <summary>
        /// Checks if review data is equal to another. Support IProductReview or ReviewItem
        /// </summary>
        /// <param name="obj">Can be IProductReview or ReviewItem</param>
        /// <returns>true if review data equals to obj data</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IProductReview)
            {
                IProductReview productReview = obj as IProductReview;

                return (GetTextFromReviewerName().Equals(productReview.GetReviewerName())
                    && GetReviewDate().Equals(productReview.GetDate())
                    && GetReviewText().Equals(productReview.GetReviewText())
                    && GetRating().Equals(productReview.GetRating()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (GetTextFromReviewerName().Equals(productReview.GetTextFromReviewerName())
                    && GetReviewDate().Equals(productReview.GetReviewDate())
                    && GetReviewText().Equals(productReview.GetReviewText())
                    && GetRating().Equals(productReview.GetRating()));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return  (GetTextFromReviewerName() + " " + this.GetReviewText() + " " + this.GetRating() + " " + this.GetReviewDate()).GetHashCode();
        }
        #endregion
    }
}
