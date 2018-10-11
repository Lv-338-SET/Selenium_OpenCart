using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.CartPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class ProductComparisonPageWhithMessage : ProductComparisonPage
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
                return driver.FindElement(By.CssSelector(SUCCESS_MESSAGE));
            }
        }

        protected IWebElement SuccessAddToCartMessageLink
        {
            get
            {
                return driver.FindElement(By.LinkText(SUCCESS_ADD_TO_CART_MESSAGE_LINK));
            }
        }
        #endregion

        #region Initialization & Verifycation
        public ProductComparisonPageWhithMessage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
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

        //public ShopingCartPage ClickSuccessAddToCartMessageLink()
        //{
        //    SuccessAddToCartMessageLink.Click();
        //    return new ShopingCartPage(driver);
        //}
        #endregion
    }
}
