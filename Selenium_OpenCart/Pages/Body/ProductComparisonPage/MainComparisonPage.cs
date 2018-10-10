using OpenQA.Selenium;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class MainComparisonPage
    {
        #region Constants
        private const string COMPARISON_HEADER = "#content h1"; //CSS
        #endregion

        #region Properties
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        protected IWebElement ComparisonHeader
        {
            get
            {
                return Search.ElementByCssSelector(COMPARISON_HEADER);
            }
        }
        #endregion

        #region Initialization & Verifycation
        public MainComparisonPage()
        {
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
