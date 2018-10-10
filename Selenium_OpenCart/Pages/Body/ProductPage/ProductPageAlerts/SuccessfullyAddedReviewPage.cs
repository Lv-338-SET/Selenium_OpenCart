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
                return Search.ElementByCssSelector("#form-review > div.alert.alert-success");
            }
        }
        #endregion

        #region Initialization and Verifycation
        public SuccessfullyAddedReviewPage()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = SuccessAllert;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsReviewAdded()
        {
            return VerifyPage();
        }

        #region Atomic operations for SuccessAllert
        public string GetTextFromSuccessAllert()
        {
            return SuccessAllert.Text;
        }
        #endregion
        #endregion
    }
}
