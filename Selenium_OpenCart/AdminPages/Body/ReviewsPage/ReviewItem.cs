using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.Rating;
using Selenium_OpenCart.Data.ProductReview.ReviewStatus;
using Selenium_OpenCart.AdminPages.Body.EditReviewPage;

namespace Selenium_OpenCart.AdminPages.Body.ReviewsPage
{
    public sealed class ReviewItem : ReviewsPage
    {
        #region Properties
        private IWebElement currentReview;

        private IWebElement SelectCheckBox
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td//input[@type='checkbox']"));
            }
        }

        private IWebElement ProductName
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[@class='text-center']/following-sibling::td"));
            }
        }

        private IWebElement ReviewerName
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[@class='text-center']/following-sibling::td[not(contains(text(),'" + GetProductName() + "'))]"));
            }
        }

        private IWebElement ReviewRating
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[@class='text-right' and not(a)]"));
            }
        }

        private IWebElement ReviewStatus
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[contains(text(),'" + ReviewStatusList.Enabled.ToString() + "') or contains(text(),'" + ReviewStatusList.Disabled.ToString() + "')]"));
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[@class='text-left' and contains(text(),'/')]"));
            }
        }

        private IWebElement EditLink
        {
            get
            {
                return currentReview.FindElement(By.XPath(".//td[@class='text-right']//a"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewItem(IWebDriver driver, IWebElement currentReview) : base(driver)
        {
            this.driver = driver;
            this.currentReview = currentReview;
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = SelectCheckBox;
            tmp = ProductName;
            tmp = ReviewerName;
            tmp = ReviewRating;
            tmp = ReviewStatus;
            tmp = ReviewDate;
            tmp = EditLink;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsReviewItem()
        {
            return VerifyPage();
        }

        #region Atomic operations for SelectCheckBox
        public void SelectReview()
        {
            SelectCheckBox.Click();
        }
        #endregion

        #region Atomic operations for ProductName
        public string GetProductName()
        {
            return ProductName.Text;
        }
        #endregion

        #region Atomic operations for ReviewerName
        public string GetReviewerName()
        {
            return ReviewerName.Text;
        }
        #endregion

        #region Atomic operations for ReviewRaiting
        /// <returns>Review Rating as RatingList enum, returns None if can't parce rating to enum</returns>
        public RatingList GetReviewRaiting()
        {
            if (int.TryParse(ReviewRating.Text, out int rating))
            {
                return rating.ToRating();
            }
            else
            {
                return RatingList.None;
            }
        }
        #endregion

        #region Atomic operations for ReviewStatus
        /// <returns>Review status as ReviewStatusList enum</returns>
        public ReviewStatusList GetReviewStatus()
        {
            return ReviewStatus.Text.ToReviewStatus();
        }
        #endregion

        #region Atomic operations for ReviewDate
        public string GetReviewDate()
        {
            return this.ReviewDate.Text;
        }
        #endregion

        #region Atomic operations for EditLink
        public EditReviewPage.EditReviewPage ClickOnEditLink()
        {
            EditLink.Click();
            return new EditReviewPage.EditReviewPage(driver);
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

                return (this.GetProductName().Equals(productReview.GetProductName())
                    && this.GetReviewerName().Equals(productReview.GetReviewerName())
                    && this.GetReviewDate().Equals(productReview.GetDate())
                    && this.GetReviewRaiting().Equals(productReview.GetRating()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (this.GetProductName().Equals(productReview.GetProductName())
                    && this.GetReviewerName().Equals(productReview.GetReviewerName())
                    && this.GetReviewDate().Equals(productReview.GetReviewDate())
                    && this.GetReviewRaiting().Equals(productReview.GetReviewRaiting()));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (this.GetProductName() + " " + this.GetReviewerName() + " " + this.GetReviewRaiting() + " " + this.GetReviewDate()).GetHashCode();
        }
        #endregion
    }
}
