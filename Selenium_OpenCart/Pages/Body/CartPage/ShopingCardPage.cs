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
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    public class ShopingCartPage
    {

        protected IWebElement TableRow
        { get { return Application.Get().Search.ElementByXPath("//div[@class='table-responsive']//tbody"); } }
        protected IWebElement ButtonContinue
        { get { return Application.Get().Search.ElementByXPath("//a[text() = 'Continue']"); } }
        protected IWebElement EmptyCartMessage
        { get { System.Threading.Thread.Sleep(250); return Application.Get().Search.ElementByXPath("//p[contains(text(),'Your shopping cart is empty!')]"); } }
        protected ShopingCartTableItem ShopingCartProduct
        { get { return GetProductElement(GetTableRow()); } }
        protected IWebElement CheckoutButton
        { get { return Application.Get().Search.ElementByXPath(" //a[@class='btn btn-primary']"); } }
     

        public ShopingCartPage()
        { }



        public HomePage ClickButtonContinue()
        {
            ButtonContinue.Click();
            return new HomePage();
        }

        public CheckoutPage.CheckoutPage ClickCheckoutButton()
        {
            CheckoutButton.Click();
            return new CheckoutPage.CheckoutPage();
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

        public bool IsEmpty()
        {
            IWebElement element;
            try
            {
                element = Application.Get().Search.ElementByXPath("//div[@id='content']/p[text()='Your shopping cart is empty!']");
            }
            catch (Exception)
            {
                return false;
            }

            if (element.Enabled)
            {
                return true;
            }
            else return false;
        }
    }
}
