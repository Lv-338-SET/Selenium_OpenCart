using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Selenium_OpenCart.Pages.Body.ListGroup
{
    class ListGroup
    {
        protected IWebDriver driver;
        public IWebElement MyAccount
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/account')]"));
            }
                
        }
        public IWebElement EditAccount
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/edit')]"));
            }
        }
        public IWebElement ChangePassword
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/password')]"));
            }
        }
        public IWebElement AddressBook
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/address')]"));
            }
        }
        public IWebElement WishList
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/wishlist')]"));
            }
        }
        public IWebElement Logout
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@href,'/logout')]"));
            }
        }

        public ListGroup(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }
        public void ClickEditAccount()
        {
            EditAccount.Click();
        }
        public void ClickChangePassword()
        {
            EditAccount.Click();
        }
        public void ClickAddressBook()
        {
            AddressBook.Click();
        }
        public void ClickLogout()
        {
            Logout.Click();
        }
    }
}
