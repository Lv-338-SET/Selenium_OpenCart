using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ProductPageDescription : ProductPageInfo
    {
        //
        private IWebElement DescriptionText
        {
            get
            {
                return driver.FindElement(By.Id("tab-description"));
            }
        }
        //

        //
        public ProductPageDescription(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = DescriptionText;
        }
        //
    }
}
