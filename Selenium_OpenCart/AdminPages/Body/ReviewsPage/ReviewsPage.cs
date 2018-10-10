using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.AdminPages.Body.ReviewsPage
{
    public class ReviewsPage : ReviewsPageLogic
    {
        #region Properties
        protected IWebElement SelectAllReviewsCheckBox
        {
            get
            {
                return Search.ElementByXPath(".//form//table//thead//tr//td//input[@type='checkbox']");
            }
            
        }

        protected IWebElement DeleteButton
        {
            get
            {
                return Search.ElementByXPath(".//button[@data-original-title='Delete']");
            }
        }

        protected List<ReviewItem> ReviewsList
        {
            get
            {
                List<ReviewItem> tmp = new List<ReviewItem>();
                foreach (IWebElement item in Search.ElementsByXPath(".//form//table//tbody//tr").ToList())
                {
                    tmp.Add(new ReviewItem(item));
                }
                return tmp;
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewsPage()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = SelectAllReviewsCheckBox;
            tmp = DeleteButton;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsReviewsPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for SelectAllReviewsCheckBox
        public void SelectAllReviews()
        {
            SelectAllReviewsCheckBox.Click();
        }
        #endregion

        #region Atomic operations for DeleteButton
        /// <summary>
        /// Deletes review
        /// </summary>
        /// <returns>Returns on ReviewsPageLogic</returns>
        public ReviewsPageLogic DeleteReview()
        {
            DeleteButton.Click();
            IAlert alert = Application.Get().Browser.Driver.SwitchTo().Alert();
            alert.Accept();
            return new ReviewsPageLogic();
        }
        #endregion

        #region Atomic operations for ReviewsList
        /// <summary>
        /// Get all reviews from page is at least one review exist
        /// </summary>
        /// <returns>List<ReviewItem> is any review exist and null if not</returns>
        public List<ReviewItem> GetReviewsListIfAnyExists()
        {
            if (IsAnyReviewExist())
            {
                return ReviewsList;
            }
            return null;
        }

        public bool IsAnyReviewExist()
        {
            return (ReviewsList.Any());
        }
        #endregion
        #endregion
    }
}
