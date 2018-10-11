using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.EditAccount;

namespace Selenium_OpenCart.Pages.Body.MyAccountPage
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }
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
            ChangePassword.Click();
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
