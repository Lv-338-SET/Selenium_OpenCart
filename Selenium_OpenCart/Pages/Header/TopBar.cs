using System.Threading;
using OpenQA.Selenium;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.CheckoutPage;
using Selenium_OpenCart.Pages.Body.ContactPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Header
{
     class TopBar
    {
        private IWebDriver driver;
        private ISearch search;

        //Properties
        private IWebElement CurrencyButton
        //{ get { return driver.FindElement(By.XPath("//div/button/strong[text()='$']")); } }
        { get { return search.ElementByXPath("//div/button/strong[text()='$']"); } }
        private IWebElement PhoneButton
        //{ get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-phone')]")); } }
        { get { return search.ElementByXPath("//li/a/i[contains(@class, 'fa fa-phone')]"); } }
        private IWebElement MyAccountButton
        //{ get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-user')]")); } }
        { get { return search.ElementByXPath("//li/a/i[contains(@class, 'fa fa-user')]"); } }
        private IWebElement WishListButton
        //{ get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-heart')]")); } }
        { get { return search.ElementByXPath("//li/a/i[contains(@class, 'fa fa-heart')]"); } }
        private IWebElement WishListButtonContent
        //{ get { return driver.FindElement(By.CssSelector("#wishlist-total")); } }
        { get { return search.ElementByCssSelector("#wishlist-total"); } }
        private IWebElement ShopingCardButton
        //{ get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-shopping-cart')]")); } }
        { get { return search.ElementByXPath("//li/a/i[contains(@class, 'fa fa-shopping-cart')]"); } }
        private IWebElement CheckoutButton
        //{ get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-share')]")); } }
        { get { return search.ElementByXPath("//li/a/i[contains(@class, 'fa fa-share')]"); } }

        //Constructor
        public TopBar(IWebDriver driver)
        {
            search = Application.Get().Search;
            //this.driver = driver;
            this.driver = Application.Get().Browser.Driver;
        }

        //Methods
        public Currency ReturnCurrencyList()
        {
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
            return MyAccount.MyAccountMenu(driver);
        }

        public WishListPage WishListButtonClick()
        {
            WishListButton.Click();
            Thread.Sleep(1500);
            return new WishListPage();
        }

        public string GetWishListButtonContent()
        {
            return WishListButtonContent.Text; 
        }

        public ShopingCartPage ShoppingCartButtonClick()
        {
            ShopingCardButton.Click();
            Thread.Sleep(2000);
            return new ShopingCartPage(driver);
        }

        public CheckoutPage CheckoutButtonClick()
        {
            CheckoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}