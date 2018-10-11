using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace Selenium_OpenCart.Pages.Header
{
    public class CartBox:Header
    {
        protected IWebElement Image { get { return driver.FindElement(By.XPath("//td[@class='text-center']//img")); } }
        protected IWebElement ProductName { get { return driver.FindElement(By.CssSelector(".text-left >a")); } }
        protected IWebElement Quantity { get { return driver.FindElement(By.XPath("//td[@class='text-right' and string-length(text()) > 0]")); } }
        protected IWebElement ProductPrice { get { return driver.FindElement(By.XPath("//td[@class='text-right' and not(contains(text(),'"+GetProductPrice()+"'))]")); } }
        public CartBox(IWebDriver driver) : base(driver)
        {

        }
        #region Atomic Operations
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetQuantity()
        {
            return Quantity.Text;
        }
        public string GetProductPrice()
        {
            Thread.Sleep(2000);
            return ProductPrice.Text;
        }
        #endregion
    }
}
