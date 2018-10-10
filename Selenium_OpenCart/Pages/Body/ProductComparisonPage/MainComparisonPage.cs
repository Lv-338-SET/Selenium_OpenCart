using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class MainComparisonPage : Header.Header
    {
        #region Constants
        private const string COMPARISON_HEADER = "#content h1"; //CSS
        #endregion

        #region Properties
        protected IWebElement ComparisonHeader
        {
            get
            {
                return driver.FindElement(By.CssSelector(COMPARISON_HEADER));
            }
        }
        #endregion

        #region Initialization & Verifycation
        public MainComparisonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = ComparisonHeader;
        }
        #endregion

        #region Atomic operations
        public string GetComparisonHeaderText()
        {
            return ComparisonHeader.Text;
        }
        #endregion
    }
}
