using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
     public class WishListPage
    {

        protected IWebElement WishListTable { get; private set; }
        protected IWebElement AddToCartButton { get; private set; }
        protected IWebElement RemoveFromWishlistButton { get; private set; }
        
        public WishListPage(IWebDriver driver)
        {
            WishListTable = driver.FindElement(By.CssSelector(".table-responsive"));

        }

        public void AddToCartButtonClick(IWebDriver driver,string product)
        {

        }

        public void RemoveProductFromWishListClick(IWebDriver driver,string product)
        {
           driver.FindElement(By.XPath("//a[text()='" + product + "']//..//..//*[@data-original-title='Remove']")).Click();
        }

        public IWebElement GetTable()
        {
            return this.WishListTable;
        }
        
        
    }
}
