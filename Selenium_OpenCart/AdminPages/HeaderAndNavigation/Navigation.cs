using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;

namespace Selenium_OpenCart.AdminPages.HeaderAndNavigation
{
    public class Navigation : Header
    {
        #region Properties
        protected IWebElement CatalogLink
        {
            get
            {
                return driver.FindElement(By.Id("menu-catalog"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Navigation(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = CatalogLink;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for CatalogLink
        public string GetTextFromCatalogLink()
        {
            return this.CatalogLink.Text;
        }

        public Catalog ClickOnCatalogLink()
        {
            this.CatalogLink.Click();
            return new Catalog(driver);
        }
        #endregion
        #endregion
    }

    public sealed class Catalog : Navigation
    {
        #region Properties
        private IWebElement ReviewLink
        {
            get
            {
                return driver.FindElement(By.XPath(".//ul[@id='collapse1']//li//a[text()='Reviews']"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Catalog(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ReviewLink;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for ReviewLink
        public string GetTextFromReviewLink()
        {
            return this.ReviewLink.Text;
        }

        public ReviewsPageLogic ClickOnReviewLink()
        {
            this.ReviewLink.Click();
            return new ReviewsPageLogic(driver);
        }
        #endregion
        #endregion
    }
}
