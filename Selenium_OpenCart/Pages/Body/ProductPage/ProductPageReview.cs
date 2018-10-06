using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public class ProductPageReview : ProductPageInfo
    {
        //
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
                foreach (IWebElement currentReview in driver.FindElements(By.XPath(".//div[@id='review']/table//tbody")))
                {
                    Reviews.Add(new ReviewItem(driver, currentReview));
                }
                return Reviews;
            }
        }
        //

        //
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
            //Reiting as emun of somthing else
            if (tmp2.Count != 5)
            {
                //ADD OWN EXCEPTION
                throw new FormatException("Raiting don't have 5 radio boxes, it has " + tmp2.Count);
            }
        }
        //

        //Atomic operations for ReviewerNameInput
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
        //

        //Functional operations for ReviewerNameInput
        //Fluent Interface
        public ProductPageReview ClickClearAndInputToReviewerNameInput(IProductReview productReview)
        {
            this.ReviewerNameInput.Click();
            this.ReviewerNameInput.Clear();
            this.ReviewerNameInput.SendKeys(productReview.GetReviewerName());
            return this;
        }
        //


        //Atomic operations for ReviewInput
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
        //

        //Functional operations for ReviewerNameInput
        //Fluent Interface
        public ProductPageReview ClickClearAndInputToReviewInput(IProductReview productReview)
        {
            this.ReviewTextInput.Click();
            this.ReviewTextInput.Clear();
            this.ReviewTextInput.SendKeys(productReview.GetReviewText());
            return this;
        }
        //

        //Atomic operations for Raiting
        public int? GetSelectedRaiting()
        {
            if (!int.TryParse(this.RatingInputList.FirstOrDefault(x => x.Selected).GetAttribute("value"), out int selected))
            {
                return null;
            }
            return selected;
        }

        //Fluent Interface
        public void SelectRating(IProductReview productReview)
        {
            this.RatingInputList.FirstOrDefault(x => Convert.ToInt32(x.GetAttribute("value")) == productReview.GetRaiting()).Click();
        }
        //

        //Atomic operations for Raiting AddReviewButton
        public ProductPageReview ClickOnAddReviewButton()
        {
            this.AddReviewButton.Click();
            return new ProductPageReview(driver);
        }
        //

        //Atomic operations for Reviews
        public bool AnyReviewExists()
        {
            return this.Reviews.Any();
        }

        public List<ReviewItem> GetReviewsList()
        {
            return this.Reviews;
        }
        //

        //Functional operations for Reviews
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
        //

        //Business logic
        public ProductPageSuccessfullyAddedReview InputValidReviewAndClickOnAddReviewButton(IProductReview productReview)
        {
            this.ClickClearAndInputToReviewerNameInput(productReview);
            this.ClickClearAndInputToReviewInput(productReview);
            this.SelectRating(productReview);
            return new ProductPageSuccessfullyAddedReview(driver);
        }
        //
    }
}
