using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class ProductComparisonPageWithMessage : ProductComparisonPage
    {
        #region Constants
        private const string SUCCESS_MESSAGE = ".alert.alert-success.alert-dismissible"; //CSS
        private const string SUCCESS_ADD_TO_CART_MESSAGE_LINK = "shopping cart"; //LinkText
        #endregion

        #region Properties
        protected IWebElement SuccessMessage
        {
            get
            {
                return Search.ElementByCssSelector(SUCCESS_MESSAGE);
            }
        }

        protected IWebElement SuccessAddToCartMessageLink
        {
            get
            {
                return Search.ElementByCssSelector(SUCCESS_ADD_TO_CART_MESSAGE_LINK);
            }
        }
        #endregion

        #region Initialization & Verifycation
        public ProductComparisonPageWithMessage()
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = SuccessMessage;
        }
        #endregion

        #region Atomic operations
        public string GetSuccessMessageText()
        {
            return SuccessMessage.Text;
        }
        
        public ShopingCartPage ClickSuccessAddToCartMessageLink()
        {
            SuccessAddToCartMessageLink.Click();
            return new ShopingCartPage();
        }
        #endregion
    }
}
