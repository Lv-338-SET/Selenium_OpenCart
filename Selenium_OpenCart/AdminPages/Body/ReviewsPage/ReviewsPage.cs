using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview.Rating;
using Selenium_OpenCart.Data.ProductReview.ReviewStatus;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.AdminPages.HeaderAndNavigation;

namespace Selenium_OpenCart.AdminPages.Body.ReviewsPage
{
    public class ReviewsPage : ReviewsPageLogic
    {
        #region Properties
        protected IWebElement SelectAllReviewsCheckBox
        {
            get
            {
                return driver.FindElement(By.XPath(".//form//table//thead//tr//td//input[@type='checkbox']"));
            }
            
        }

        protected IWebElement DeleteButton
        {
            get
            {
                return driver.FindElement(By.XPath(".//button[@data-original-title='Delete']"));
            }
        }

        protected List<ReviewItem> ReviewsList
        {
            get
            {
                List<ReviewItem> tmp = new List<ReviewItem>();
                foreach (IWebElement item in driver.FindElements(By.XPath(".//form//table//tbody//tr")).ToList())
                {
                    tmp.Add(new ReviewItem(driver, item));
                }
                return tmp;
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = SelectAllReviewsCheckBox;
            tmp = DeleteButton;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for SelectAllReviewsCheckBox
        public void SelectAllReviews()
        {
            this.SelectAllReviewsCheckBox.Click();
        }
        #endregion

        #region Atomic operations for DeleteButton
        public ReviewsPageLogic DeleteReview()
        {
            this.DeleteButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return new ReviewsPageLogic(driver);
        }
        #endregion

        #region Atomic operations for ReviewsList
        public List<ReviewItem> GetReviewsListIfAnyExists()
        {
            if (IsAnyReviewExist())
            {
                return this.ReviewsList;
            }
            return null;
        }

        public bool IsAnyReviewExist()
        {
            return (this.ReviewsList.Any());
        }
        #endregion
        #endregion
    }
}
