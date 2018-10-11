using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts
{
    public sealed class UnsuccessfullyAddedReviewPage : ProductPageReview
    {
        #region Properties
        private IWebElement WarningAlert
        {
            get
            {
                return Search.ElementByCssSelector("#form-review > div.alert.alert-danger.alert-dismissible");
            }
        }
        #endregion

        #region Initialization and Verifycation        
        public UnsuccessfullyAddedReviewPage()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = WarningAlert;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsWarningAlertDisplayed()
        {
            return VerifyPage();
        }

        #region Atomic operations for WarningAlert
        public string GetTextFromWarningAlert()
        {
            return WarningAlert.Text;
        }
        #endregion
        #endregion
    }
}
