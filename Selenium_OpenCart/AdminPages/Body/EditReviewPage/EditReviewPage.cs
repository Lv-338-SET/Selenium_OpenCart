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
        const string EDIT_REVIEW_PAGE_TITLE = "Edit Review";

        #region Properties
        private IWebElement PageTitle
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='panel-heading']//h3[@class='panel-title']"));
            }
        }

        private IWebElement ReviewerName
        {
            get
            {
                return driver.FindElement(By.Id("input-author"));
            }
        }

        private IWebElement ProductName
        {
            get
            {
                return driver.FindElement(By.Id("input-product"));
            }
        }

        private IWebElement ReviewText
        {
            get
            {
                return driver.FindElement(By.Id("input-text"));
            }
        }

        private List<IWebElement> ReviewRating
        {
            get
            {
                return driver.FindElements(By.XPath(".//input[@type='radio' and @name='rating']")).ToList();
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return driver.FindElement(By.Id("input-date-added"));
            }
        }

        private List<IWebElement> ReviewStatus
        {
            get
            {
                return driver.FindElements(By.XPath(".//select[@id='input-status']//option")).ToList();
            }
        }

        private IWebElement SaveButton
        {
            get
            {
                return driver.FindElement(By.XPath(".//button[@data-original-title='Save']"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public EditReviewPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ReviewerName;
            tmp = ProductName;
            tmp = ReviewText;
            tmp = ReviewDate;
            tmp = SaveButton;
            List<IWebElement> tmp2 = ReviewRating;
            if (tmp2.Count != RatingRepository.ListOfRating.Count)
            {
                throw new CountRatingExeption("Expected " + RatingRepository.ListOfRating.Count + " raiting radio boxed bu was " + tmp2.Count);
            }
            tmp2 = ReviewStatus;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for PageTitle
        public string GetTextFomPageTitle()
        {
            return this.PageTitle.Text;
        }

        public bool IsEditReviewPage()
        {
            return this.PageTitle.Text.Equals(EDIT_REVIEW_PAGE_TITLE);
        }
        #endregion


        #region Atomic operations for ReviewerName
        public string GetTextFomReviewerNameInput()
        {
            return this.ReviewerName.Text;
        }
        #endregion

        #region Atomic operations for ProductName
        public string GetTextFomProductNameInput()
        {
            return this.ProductName.Text;
        }
        #endregion

        #region Atomic operations for ReviewText
        public string GetTextFomReviewTextInput()
        {
            return this.ReviewText.Text;
        }
        #endregion

        #region Atomic operations for ReviewDate
        public string GetDateFomReviewDateInput()
        {
            //Format at server in thise case is yyyy-MM-dd but in all others is dd/MM/yyyy
            
            DateTime.TryParse(this.ReviewDate.GetAttribute("value"), out DateTime date);
            return date.ToString(@"dd\/MM\/yyyy");
        }
        #endregion

        #region Atomic operations for ReviewRating
        public RatingList GetSelectedRating()
        {
            if (!int.TryParse(this.ReviewRating.FirstOrDefault(x => x.Selected).GetAttribute("value"), out int selected))
            {
                return RatingList.None;
            }
            return RatingList.None;
        }
        #endregion

        #region Atomic operations for ReviewStatus
        public ReviewStatusList GetReviewStatus()
        {
            return this.ReviewStatus.FirstOrDefault(x => x.GetAttribute("selected") == "selected").Text.ToReviewStatus();
        }

        public void SetReviewStatus(ReviewStatusList status)
        {
            this.ReviewStatus.FirstOrDefault(x => x.Text == status.ToString()).Click();
        }
        #endregion

        #region Atomic operations for SaveButton
        public void ClickOnSaveButton()
        {
            this.SaveButton.Click();
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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IProductReview)
            {
                IProductReview productReview = obj as IProductReview;

                return (this.GetTextFomProductNameInput().Equals(productReview.GetProductName())
                    && this.GetTextFomReviewerNameInput().Equals(productReview.GetReviewerName())
                    && this.GetDateFomReviewDateInput().Equals(productReview.GetDate())
                    && this.GetSelectedRating().Equals(productReview.GetRating()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (this.GetTextFomProductNameInput().Equals(productReview.GetProductName())
                    && this.GetTextFomReviewerNameInput().Equals(productReview.GetReviewerName())
                    && this.GetDateFomReviewDateInput().Equals(productReview.GetReviewDate())
                    && this.GetSelectedRating().Equals(productReview.GetReviewRaiting()));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (this.GetTextFomProductNameInput() + " " + this.GetTextFomReviewerNameInput() + " " + this.GetTextFomReviewTextInput() + " " 
                + this.GetSelectedRating() + " " + this.GetDateFomReviewDateInput()).GetHashCode();
        }
        #endregion

    }
}
