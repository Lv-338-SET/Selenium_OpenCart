using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.ContactPage;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.CheckoutPage;

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
            WishListButton.Click();
            return new WishListPage(driver);
        }

        public ShopingCardPage ShopingCardButtonClick()
        {
            ShopingCardButton.Click();
            return new ShopingCardPage(driver);
        }

        public CheckoutPage CheckoutButtonClick()
        {
            CheckoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}