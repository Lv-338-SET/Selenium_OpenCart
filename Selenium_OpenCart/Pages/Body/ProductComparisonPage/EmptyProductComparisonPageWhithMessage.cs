using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class EmptyProductComparisonPageWhithMessage : EmptyProductComparisonPage
    {
        #region Constants
        private const string SUCCESS_REMOVE_MESSAGE = ".alert.alert-success.alert-dismissible"; //CSS
        #endregion

        #region Properties
        protected IWebElement SuccessRemoveMessage
        {
            get
            {
                return driver.FindElement(By.CssSelector(SUCCESS_REMOVE_MESSAGE));
            }
        }
        #endregion

        #region Initialization & Verifycation
        public EmptyProductComparisonPageWhithMessage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
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
    }
}
