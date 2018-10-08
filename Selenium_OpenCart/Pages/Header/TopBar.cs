using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.CheckoutPage;
using Selenium_OpenCart.Pages.Body.ContactPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using System;

namespace Selenium_OpenCart.Pages.Header
{
     class TopBar
    {
        private IWebDriver driver;

        //Properties
        private IWebElement CurrencyButton
        { get { return driver.FindElement(By.XPath("//div/button/strong[text()='$']")); } }
        private IWebElement PhoneButton
        { get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-phone')]")); } }
        private IWebElement MyAccountButton
        { get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-user')]")); } }
        private IWebElement WishListButton
        { get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-heart')]")); } }
        private IWebElement WishListButtonContent
        { get { return driver.FindElement(By.CssSelector("#wishlist-total > span")); } }
        private IWebElement ShopingCardButton
        { get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-shopping-cart')]")); } }
        private IWebElement CheckoutButton
        { get { return driver.FindElement(By.XPath("//li/a/i[contains(@class, 'fa fa-share')]")); } }

        //Constructor
        public TopBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Methods
        public Currency ReturnCurrencyList()
        {
            CurrencyButton.Click();
            return new Currency(driver);
        }

        public ContactPage PhoneButtonClick()
        {
            PhoneButton.Click();
            return new ContactPage(driver);
        }

        public MyAccount MyAccountButtonClick()
        {
            MyAccountButton.Click();
            return MyAccount.MyAccountMenu(driver);
        }

        public WishListPage WishListButtonClick()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            WishListButton.Click();
            return new WishListPage(driver);
        }
        public string GetWishListButtonContent()
        {
            return WishListButtonContent.Text; 
        }

        public ShopingCartPage ShopingCartButtonClick()
        {
            ShopingCardButton.Click();
            return new ShopingCartPage(driver);
        }

        public CheckoutPage CheckoutButtonClick()
        {
            CheckoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}