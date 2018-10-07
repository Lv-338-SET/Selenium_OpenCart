using OpenQA.Selenium;

namespace Selenium_OpenCart.AdminPages.Body.ReviewsPage
{
    public sealed class ReviewsPageSuccessfullyModifiedReview : ReviewsPage
    {
        #region Properties
        private IWebElement SuccessAllert
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='alert alert-success alert-dismissible']"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewsPageSuccessfullyModifiedReview(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = SuccessAllert;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for SuccessAllert
        public bool IsReviewModified()
        {
            return this.SuccessAllert.Displayed;
        }

        public string GetSuccessAllertText()
        {
            return this.SuccessAllert.Text;
        }
        #endregion
        #endregion
    }
}
