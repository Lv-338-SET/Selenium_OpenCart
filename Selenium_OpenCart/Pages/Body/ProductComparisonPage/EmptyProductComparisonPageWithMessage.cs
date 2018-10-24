using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class EmptyProductComparisonPageWithMessage : EmptyProductComparisonPage
    {
        #region Constants
        private const string SUCCESS_REMOVE_MESSAGE = ".alert.alert-success.alert-dismissible"; //CSS
        private const string REMOVE_LINK = "//tbody[last()]/descendant::a"; //XPath
        private const string COMPARISON_TABLE = ".table.table-bordered"; //CSS
        #endregion

        #region Properties
        protected IWebElement SuccessRemoveMessage
        {
            get
            {
                return Search.ElementByCssSelector(SUCCESS_REMOVE_MESSAGE);
            }
        }
        #endregion

        #region Initialization & Verifycation
        public EmptyProductComparisonPageWithMessage()
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = SuccessRemoveMessage;
        }
        #endregion

        #region Atomic operations
        public string GetSuccessRemoveMessageText()
        {
            return SuccessRemoveMessage.Text;
        }
        #endregion


        #region Business logic
        public bool IsElementPresent()
        {
            try
            {
                Search.ElementsByCssSelector(COMPARISON_TABLE);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public int CountColumns()
        {
            return Search.ElementsByXPath(REMOVE_LINK).Count;
        }
        #endregion
    }
}
