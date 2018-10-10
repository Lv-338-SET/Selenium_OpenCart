using OpenQA.Selenium;

namespace Selenium_OpenCart.AdminPages.Body.ReviewsPage
{
    public sealed class ReviewsPageSuccessAllert : ReviewsPage
    {
        #region Properties
        private IWebElement SuccessAllert
        {
            get
            {
                return Search.ElementByXPath(".//div[@class='alert alert-success alert-dismissible']");
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewsPageSuccessAllert()
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
        public bool IsReviewsPageWithSuccessAllert()
        {
            return VerifyPage();
        }
        #region Atomic operations for SuccessAllert
        public bool IsReviewModified()
        {
            return this.SuccessAllert.Displayed;
        }

        public string GetTextFromSuccessAllert()
        {
            return this.SuccessAllert.Text;
        }
        #endregion
        #endregion
    }
}
