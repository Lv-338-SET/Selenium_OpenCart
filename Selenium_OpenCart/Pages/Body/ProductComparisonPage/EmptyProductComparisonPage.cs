using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class EmptyProductComparisonPage : MainComparisonPage
    {
        #region Constants
        private const string NO_COMPARE_PRODUCTS_MESSAGE = "#content p"; //CSS
        private const string CONTINUE_BUTTON = ".pull-right>.btn.btn-default"; //CSS
        #endregion

        #region Properties
        protected IWebElement NoCompareProductsMessage
        {
            get
            {
                return Search.ElementByCssSelector(NO_COMPARE_PRODUCTS_MESSAGE);
            }
        }

        protected IWebElement ContinueButton
        {
            get
            {
                return Search.ElementByCssSelector(CONTINUE_BUTTON);
            }
        }
        #endregion

        #region Initialization & Verifycation
        public EmptyProductComparisonPage()
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = NoCompareProductsMessage;
            temp = ContinueButton;

        }
        #endregion

        #region Atomic operations
        public string GetNoProductsToCompareLabelText()
        {
            return NoCompareProductsMessage.Text;
        }

        public HomePage ClickContinueButton()
        {
            ContinueButton.Click();
            return new HomePage(Application.Get().Browser.Driver);
        }
        #endregion
    }
}
