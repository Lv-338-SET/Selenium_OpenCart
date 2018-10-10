using OpenQA.Selenium;

using Selenium_OpenCart.Pages.Body.ProductComparisonPage;
using Selenium_OpenCart.Logic.ProductPageLogic;

namespace Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts
{
    public sealed class SuccessfullyAddedProductForComparisonPage : ProductPage
    {
        #region Properties
        private IWebElement SuccessAllert
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='alert alert-success alert-dismissible']"));
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
        #endregion

        #region Initialization And Verifycation
        public SuccessfullyAddedProductForComparisonPage(IWebDriver driver) : base(driver)
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
        #endregion

        #region Atomic operations
        #region Atomic operations for SuccessAllert
        public bool IsProductAddedToComparePage()
        {
            return this.SuccessAllert.Displayed;
        }
        #endregion

        #region Atomic operations for ProductPageLink
        public string GetProductPageLinkText()
        {
            return this.ProductPageLink.Text;
        }

        public ProductPageReviewLogic ClickOnProductPageLink()
        {
            this.ProductPageLink.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for CompareProductsPageLink
        public string GetCompareProductsPageLink()
        {
            return this.CompareProductsPageLink.Text;
        }

        public ProductComparisonPage.ProductComparisonPage ClickOnCompareProductsPageLink()
        {
            this.CompareProductsPageLink.Click();
            return new ProductComparisonPage.ProductComparisonPage(driver);
        }
        #endregion
        #endregion
    }
}
