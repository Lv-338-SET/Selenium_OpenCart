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
                return driver.FindElement(By.Id("tab-description"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ProductPageDescription(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = DescriptionText;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for DescriptionText
        public string GetDescriptionText()
        {
            return this.DescriptionText.Text;
        }
        #endregion
        #endregion
    }
}
