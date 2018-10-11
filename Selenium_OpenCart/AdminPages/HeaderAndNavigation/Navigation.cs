using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.AdminPages.HeaderAndNavigation
{
    public class Navigation : Header
    {
        #region Properties
        protected IWebElement CatalogLink
        {
            get
            {
                return Search.ElementById("menu-catalog");
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Navigation()
        {
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
            return new Catalog();
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
                //STRATEGY OT WORKING
                //Application.Get().Search.SetExplicitStrategy();
                //IWebElement tmp = Search.ElementByXPath(".//ul[@id='collapse1']//li//a[text()='Reviews']");
                //Application.Get().Search.SetImplicitStrategy();
                Application.Get().Search.SetExplicitStrategy();
                OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Application.Get().Browser.Driver, System.TimeSpan.FromSeconds(1));
                wait.Until(d => Search.ElementByXPath(".//ul[@id='collapse1']//li//a[text()='Reviews']").Displayed);
                IWebElement tmp = Search.ElementByXPath(".//ul[@id='collapse1']//li//a[text()='Reviews']");
                Application.Get().Search.SetImplicitStrategy();
                return tmp;
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Catalog()
        {
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
            return new ReviewsPageLogic();
        }
        #endregion
        #endregion
    }
}
