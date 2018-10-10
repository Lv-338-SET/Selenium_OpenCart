using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.Rating;

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

        private bool VerifyPage()
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
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsReviewPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for ReviewerNameInput
        public void ClickOnReviewerNameInput()
        {
            ReviewerNameInput.Click();
        }

        public void ClearReviewerNameInput()
        {
            ReviewerNameInput.Clear();
        }

        /// <summary>
        /// Inputs text to Reviewr Name Input
        /// </summary>
        /// <param name="productReview">Data tha represent product review in IProductReview format</param>
        public void InputTextToReviewerNameInput(IProductReview productReview)
        {
            ReviewerNameInput.SendKeys(productReview.GetReviewerName());
        }

        public string GetTextFromReviewerNameInput()
        {
            return ReviewerNameInput.Text;
        }
        #endregion

        #region Atomic operations for ReviewTextInput
        public void ClickOnReviewInput()
        {
            ReviewTextInput.Click();
        }

        public void ClearReviewInput()
        {
            ReviewTextInput.Clear();
        }

        /// <summary>
        /// Inputs text to Review Text Input
        /// </summary>
        /// <param name="productReview">Data tha represent product review in IProductReview format</param>
        public void InputTextToReviewInput(IProductReview productReview)
        {
            ReviewTextInput.SendKeys(productReview.GetReviewText());
        }

        public string GetTextFromReviewInput()
        {
            return ReviewTextInput.Text;
        }
        #endregion

        #region Atomic operations for Rating
        /// <summary>
        /// Gets selected rating in RatingList enum format
        /// </summary>
        /// <returns>selected rating in RatingList enum format or None if not found</returns>
        public RatingList GetSelectedRating()
        {
            if (!int.TryParse(this.RatingInputList.FirstOrDefault(x => x.Selected).GetAttribute("value"), out int selected))
            {
                return RatingList.None;
            }
            return selected.ToRating();
        }

        /// <param name="productReview">Data tha represent product review in IProductReview format</param>
        public void SelectRating(IProductReview productReview)
        {
            RatingInputList.FirstOrDefault(x => Convert.ToInt32(x.GetAttribute("value")) == productReview.GetRating().ToInt()).Click();
        }
        #endregion

        #region Atomic operations for AddReviewButton
        public void ClickOnAddReviewButton()
        {
            AddReviewButton.Click();
        }
        #endregion

        #region Atomic operations for Reviews
        /// <summary>
        /// Check is any review exist
        /// </summary>
        /// <returns>True if any review exist and fale if not</returns>
        public bool AnyReviewExists()
        {
            return Reviews.Any();
        }

        /// <summary>
        /// Get List<ReviewItem> if at least one review exist
        /// </summary>
        /// <returns>List<ReviewItem> if there are any review or null if not</returns>
        public List<ReviewItem> GetReviewsListInAnyReviewExist()
        {
            if (AnyReviewExists())
            {
                return Reviews;
            }
            return null;
        }

        /// <summary>
        /// Check is review exist in ReviewsList
        /// </summary>
        /// <param name="productReview">Data tha represent product review in IProductReview format</param>
        /// <returns>true if exist and false if not</returns>
        public bool ReviewExistInListOfReview(IProductReview productReview)
        {
            return GetReviewsListInAnyReviewExist().Where(x => x.Equals(productReview)).Any();           
        }
        #endregion
        #endregion
    }
}
