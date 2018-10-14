using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.CheckoutPage;
using Selenium_OpenCart.Pages.Body.ContactPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using System;
using System.Threading;

namespace Selenium_OpenCart.Pages.Header
{
    class TopBar
    {
        protected ISearch search;
            
        //Properties
        private IWebElement CurrencyButton
        { get { return search.ElementByXPath("//form[@id='form-currency']/div/button"); } }
        private IWebElement PhoneButton
        { get { return search.ElementByXPath("//li/a/i[@class='fa fa-phone']"); } }
        private IWebElement MyAccountButton
        { get { return search.ElementByXPath("//li/a/i[@class='fa fa-user']"); } }
        private IWebElement WishListButton
        { get { return search.ElementByXPath("//li/a/i[@class='fa fa-heart']"); } }
        private IWebElement WishListButtonContent
        { get { return search.ElementByCssSelector("#wishlist-total"); } }
        private IWebElement ShopingCardButton
        { get { return search.ElementByXPath("//li/a/i[@class='fa fa-shopping-cart']"); } }
        private IWebElement CheckoutButton
        { get { return search.ElementByXPath("//li/a/i[@class='fa fa-share']"); } }

        //Constructor
        public TopBar()
        {
            search = Application.Get().Search;
            //driver = Application.Get().Browser.Driver.SwitchTo().Frame(search.ElementByXPath("//nav[@id='top']"));
        }

        //Methods
        public Currency ReturnCurrencyList()
        {
            //IWebElement currencyForm = search.ElementById("form-currency");
            //driver = Application.Get().Browser.Driver.SwitchTo().Frame(currencyForm);
            CurrencyButton.Click();
            return new Currency();
        }

        public ContactPage PhoneButtonClick()
        {
            PhoneButton.Click();
            return new ContactPage();
        }

        public MyAccount MyAccountButtonClick()
        {
            MyAccountButton.Click();
            Thread.Sleep(500);
            return MyAccount.MyAccountMenu();
        }

        public WishListPage WishListButtonClick()
        {
            WishListButton.Click();
            Thread.Sleep(500);
            return new WishListPage();
        }

        public string GetWishListButtonContent()
        {
            return WishListButtonContent.Text; 
        }
      
        public ShopingCartPage ShoppingCartButtonClick()
        {
            ShopingCardButton.Click();
            Thread.Sleep(500);
            return new ShopingCartPage();
        }

        public CheckoutPage CheckoutButtonClick()
        {
            CheckoutButton.Click();
            return new CheckoutPage();
        }

        public static bool Verify()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByXPath("//strong[text()='$']");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}