using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ProductPageSuccessfullyAddedProductForComparison : ProductPage
    {
        //
        private IWebElement SuccessAllert
        {
            get
            {
                return driver.FindElement(By.CssSelector("#alert alert-success alert-dismissible"));
            }
        }

        private IWebElement ProductPageLink
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='alert alert-success alert-dismissible']//a[contains(@href,'route=product/product')]"));
            }
        }

        private IWebElement CompareProductsPageLink
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='alert alert-success alert-dismissible']//a[contains(@href,'route=product/compare')]"));
            }
        }
        //

        //
        public ProductPageSuccessfullyAddedProductForComparison(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = this.SuccessAllert;
            tmp = this.ProductPageLink;
            tmp = this.CompareProductsPageLink;
        }
        //

        //Atomic for SuccessAllert
        public bool IsProductAddedToComparePage()
        {
            return this.SuccessAllert.Displayed;
        }
        //

        //Atomic for ProductPageLink
        public string GetProductPageLinkText()
        {
            return this.ProductPageLink.Text;
        }

        public ProductPage ClickOnProductPageLink()
        {
            this.ProductPageLink.Click();
            return new ProductPage(driver);
        }
        //

        //Atomic for CompareProductsPageLink
        public string GetCompareProductsPageLink()
        {
            return this.CompareProductsPageLink.Text;
        }

        public ProductPage ClickOnCompareProductsPageLink()
        {
            //CHANGE TO ANDRIY PAGE!
            this.CompareProductsPageLink.Click();
            return new ProductPage(driver);
        }
        //
    }
}
