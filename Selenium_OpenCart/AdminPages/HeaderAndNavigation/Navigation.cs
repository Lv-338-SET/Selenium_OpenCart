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

        private bool VerifyPage()
        {
            IWebElement tmp = CatalogLink;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsNavigationPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for CatalogLink
        public string GetTextFromCatalogLink()
        {
            return CatalogLink.Text;
        }

        public Catalog ClickOnCatalogLink()
        {
            CatalogLink.Click();
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

        private bool VerifyPage()
        {
            IWebElement tmp = ReviewLink;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsCatalog()
        {
            return VerifyPage();
        }

        #region Atomic operations for ReviewLink
        public string GetTextFromReviewLink()
        {
            return ReviewLink.Text;
        }

        public ReviewsPageLogic ClickOnReviewLink()
        {
            ReviewLink.Click();
            return new ReviewsPageLogic(driver);
        }
        #endregion
        #endregion
    }
}
