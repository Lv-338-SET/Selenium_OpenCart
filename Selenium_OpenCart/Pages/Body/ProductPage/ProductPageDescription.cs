using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ProductPageDescription : ProductPageInfo
    {
        #region Properties
        private IWebElement DescriptionText
        {
            get
            {
                return Search.ElementById("tab-description");
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ProductPageDescription()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = DescriptionText;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsDescriptionPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for DescriptionText
        public string GetTextFromDescription()
        {
            return this.DescriptionText.Text;
        }
        #endregion
        #endregion
    }
}
