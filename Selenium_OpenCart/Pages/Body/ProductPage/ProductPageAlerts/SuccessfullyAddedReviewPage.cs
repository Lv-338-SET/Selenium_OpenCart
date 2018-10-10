using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts
{
    public sealed class SuccessfullyAddedReviewPage : ProductPageReview
    {
        #region Properties
        private IWebElement SuccessAllert
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div.alert.alert-success"));
            }
        }
        #endregion

        #region Initialization and Verifycation
        public SuccessfullyAddedReviewPage(IWebDriver driver) : base(driver)
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
        public bool IsReviewAdded()
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
