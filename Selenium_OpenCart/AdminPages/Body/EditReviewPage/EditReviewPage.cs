using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.AdminPages.Body.ReviewsPage;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.Rating;
using Selenium_OpenCart.Data.ProductReview.ReviewStatus;

namespace Selenium_OpenCart.AdminPages.Body.EditReviewPage
{
    public sealed class EditReviewPage : AdminPageLogic
    {
        #region Properties
        private IWebElement PageTitle
        {
            get
            {
                return Search.ElementByXPath(".//div[@class='panel-heading']//h3[@class='panel-title']");
            }
        }

        private IWebElement ReviewerName
        {
            get
            {
                return Search.ElementById("input-author");
            }
        }

        private IWebElement ProductName
        {
            get
            {
                return Search.ElementById("input-product");
            }
        }

        private IWebElement ReviewText
        {
            get
            {
                return Search.ElementById("input-text");
            }
        }

        private List<IWebElement> ReviewRating
        {
            get
            {
                return Search.ElementsByXPath(".//input[@type='radio' and @name='rating']").ToList();
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return Search.ElementById("input-date-added");
            }
        }

        private List<IWebElement> ReviewStatus
        {
            get
            {
                return Search.ElementsByXPath(".//select[@id='input-status']//option").ToList();
            }
        }

        private IWebElement SaveButton
        {
            get
            {
                return Search.ElementByXPath(".//button[@data-original-title='Save']");
            }
        }
        #endregion

        #region Initialization And Verifycation
        public EditReviewPage()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = ReviewerName;
            tmp = ProductName;
            tmp = ReviewText;
            tmp = ReviewDate;
            tmp = SaveButton;
            List<IWebElement> tmp2 = ReviewRating;
            if (tmp2.Count != RatingRepository.ListOfRating.Count)
            {
                throw new CountRatingExeption("Expected " + RatingRepository.ListOfRating.Count + " raiting radio buttons but was " + tmp2.Count);
            }
            tmp2 = ReviewStatus;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsEditReviewPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for PageTitle
        public string GetTextFomPageTitle()
        {
            return PageTitle.Text;
        }
        #endregion

        #region Atomic operations for ReviewerName
        public string GetTextFomReviewerNameInput()
        {
            return ReviewerName.Text;
        }
        #endregion

        #region Atomic operations for ProductName
        public string GetTextFomProductNameInput()
        {
            return ProductName.Text;
        }
        #endregion

        #region Atomic operations for ReviewText
        public string GetTextFomReviewTextInput()
        {
            return ReviewText.Text;
        }
        #endregion

        #region Atomic operations for ReviewDate
        /// <summary>
        /// NOTE! In these case date format is yyyy-MM-dd but in all others is dd/MM/yyyy
        /// so date format is changed to suport using on other pages
        /// </summary>
        /// <returns>Date when review was written in format dd/MM/yyyy</returns>
        public string GetDateFomReviewDateInput()
        {
            DateTime.TryParse(this.ReviewDate.GetAttribute("value"), out DateTime date);
            return date.ToString(@"dd\/MM\/yyyy");
        }
        #endregion

        #region Atomic operations for ReviewRating
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Review rating in RatingList enum or none if cant parce rating</returns>
        public RatingList GetSelectedRating()
        {
            if (!int.TryParse(this.ReviewRating.FirstOrDefault(x => x.Selected).GetAttribute("value"), out int selected))
            {
                return RatingList.None;
            }
            return selected.ToRating();
        }
        #endregion

        #region Atomic operations for ReviewStatus
        public ReviewStatusList GetReviewStatus()
        {
            return ReviewStatus.FirstOrDefault(x => x.GetAttribute("selected") == "selected").Text.ToReviewStatus();
        }

        public void SetReviewStatus(ReviewStatusList status)
        {
            ReviewStatus.FirstOrDefault(x => x.Text == status.ToString()).Click();
        }
        #endregion

        #region Atomic operations for SaveButton
        public void ClickOnSaveButton()
        {
            SaveButton.Click();
        }
        #endregion
        #endregion

        #region overrided Methods and Operators
        public static bool operator ==(EditReviewPage first, object second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(EditReviewPage first, object second)
        {
            return !first.Equals(second);
        }

        /// <summary>
        /// Checks if data on page is equal to some obj
        /// </summary>
        /// <param name="obj">Can be IProductReview or ReviewItem,  represents Review that will be checked to equals</param>
        /// <returns>True is two reviews data are equal and false if not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IProductReview)
            {
                IProductReview productReview = obj as IProductReview;

                return (GetTextFomProductNameInput().Equals(productReview.GetProductName())
                    && GetTextFomReviewerNameInput().Equals(productReview.GetReviewerName())
                    && GetDateFomReviewDateInput().Equals(productReview.GetDate())
                    && GetSelectedRating().Equals(productReview.GetRating()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (GetTextFomProductNameInput().Equals(productReview.GetProductName())
                    && GetTextFomReviewerNameInput().Equals(productReview.GetReviewerName())
                    && GetDateFomReviewDateInput().Equals(productReview.GetReviewDate())
                    && GetSelectedRating().Equals(productReview.GetReviewRaiting()));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (GetTextFomProductNameInput() + " " + GetTextFomReviewerNameInput() + " " + GetTextFomReviewTextInput() + " " 
                + GetSelectedRating() + " " + GetDateFomReviewDateInput()).GetHashCode();
        }
        #endregion

    }
}
