using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.WishListPage;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    class ShopingCartPage : Header.Header
    {
        protected IWebElement TableRow
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']//tbody")); } }
        protected IWebElement ButtonContinue
        { get { return driver.FindElement(By.XPath("//a[text() = 'Continue']")); } }
        protected IWebElement EmptyCartMessage
        { get { return driver.FindElement(By.XPath("//p[contains(text(),'Your shopping cart is empty!')]")); } }
        protected ShopingCartTableItem ShopingCartProduct
        { get { return GetProductElement(GetTableRow()); } }



        public ShopingCartPage(IWebDriver driver) : base(driver)
        { }

        public HomePage GoToMainPageIfCartIsEmpty()
        {
            ButtonContinue.Click();
            return new HomePage(driver);
        }

        public ShopingCartTableItem GetProductElement(IWebElement webElement)
        {
            return new ShopingCartTableItem(webElement);
        }

        public IWebElement GetTableRow()
        {
            return this.TableRow;
        }

        public ShopingCartTableItem GetProduct()
        {
            return this.ShopingCartProduct;
        }


        public bool GetEmptyCartMessage()
        {
            return EmptyCartMessage.Displayed;
        }
    }
}