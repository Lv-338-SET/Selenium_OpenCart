using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.Rating;
using Selenium_OpenCart.Logic.ProductPageLogic;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public class ProductPageReview : ProductPageInfo
    {
        #region Properties
        protected IWebElement ReviewerNameInput
        {
            get
            {
                return driver.FindElement(By.Id("input-name"));
            }
        }

        protected IWebElement ReviewTextInput
        {
            get
            {
                return driver.FindElement(By.Id("input-review"));
            }
        }

        protected List<IWebElement> RatingInputList
        {
            get
            {
                return driver.FindElements(By.XPath(".//form[@id='form-review']//input[@type='radio' and @name='rating']")).ToList();
            }
        }

        protected IWebElement AddReviewButton
        {
            get
            {
                return driver.FindElement(By.Id("button-review"));
            }
        }

        protected List<ReviewItem> Reviews
        {
            get
            {
                List<ReviewItem> tmp = new List<ReviewItem>();
                foreach (IWebElement currentReview in driver.FindElements(By.XPath(".//div[@id='review']//table//tbody")))
                {
                    tmp.Add(new ReviewItem(driver, currentReview));
                }
                return tmp;
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ProductPageReview(IWebDriver driver) : base(driver)
        {
            this.driver = driver;            
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ReviewerNameInput;
            tmp = ReviewTextInput;
            tmp = AddReviewButton;
            tmp = AddReviewButton;
            List<IWebElement> tmp2 = RatingInputList;
            if (tmp2.Count != RatingRepository.ListOfRating.Count)
            {
                throw new CountRatingExeption("Rating don't have 5 radio boxes, it has " + tmp2.Count);
            }
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for ReviewerNameInput
        public void ClickOnReviewerNameInput()
        {
            this.ReviewerNameInput.Click();
        }

        public void ClearReviewerNameInput()
        {
            this.ReviewerNameInput.Clear();
        }

        public void InputTextToReviewerNameInput(IProductReview productReview)
        {
            this.ReviewerNameInput.SendKeys(productReview.GetReviewerName());
        }

        public string GetTextFromReviewerNameInput()
        {
            return this.ReviewerNameInput.Text;
        }
        #endregion

        #region Atomic operations for ReviewTextInput
        public void ClickOnReviewInput()
        {
            this.ReviewTextInput.Click();
        }

        public void ClearReviewInput()
        {
            this.ReviewTextInput.Clear();
        }

        public void InputTextToReviewInput(IProductReview productReview)
        {
            this.ReviewTextInput.SendKeys(productReview.GetReviewText());
        }

        public string GetTextFromReviewInput()
        {
            return this.ReviewTextInput.Text;
        }
        #endregion

        #region Atomic operations for Rating
        public RatingList GetSelectedRating()
        {
            if (!int.TryParse(this.RatingInputList.FirstOrDefault(x => x.Selected).GetAttribute("value"), out int selected))
            {
                return RatingList.None;
            }
            return selected.ToRating();
        }

        //Fluent Interface
        public ProductPage SelectRating(IProductReview productReview)
        {
            this.RatingInputList.FirstOrDefault(x => Convert.ToInt32(x.GetAttribute("value")) == productReview.GetRating().ToInt()).Click();
            return this;
        }
        #endregion

        #region Atomic operations for AddReviewButton
        public ProductPageReviewLogic ClickOnAddReviewButton()
        {
            this.AddReviewButton.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for Reviews
        public bool AnyReviewExists()
        {
            return this.Reviews.Any();
        }

        public List<ReviewItem> GetReviewsListInAnyReviewExist()
        {
            if (AnyReviewExists())
            {
                return this.Reviews;
            }
            else
            {
                return null;
            }
        }

        public bool ReviewExistInListOfReview(IProductReview productReview)
        {
            return this.GetReviewsListInAnyReviewExist().Where(x => x.Equals(productReview)).Any();           
        }
        #endregion
        #endregion
    }
}
