using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Pages.Body.AddressBookPage;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.MyAccount
{
    public class MyAccountPage
    {
        private IWebDriver driver;
        //private ISearch Search;

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

        public MyAccountPage ClikLinkMyAccount()
        {
            MyAccount.Click();
            return new MyAccountPage(driver);
        }
        public EditAccountPage ClickLinkEditAccount()
        {
            EditAccount.Click();
            return new EditAccountPage(driver);
        }
        public ChangePasswordPage.ChangePasswordPage ClickLinkChangePassword()
        {
            ChangePassword.Click();
            return new ChangePasswordPage.ChangePasswordPage(driver);
        }
        public AddressBookPage.AddressBookPage ClickLinkAddressBook()
        {
            AddressBook.Click();
            return new AddressBookPage.AddressBookPage(driver);
        }

        public LogoutPage.LogoutPage ClickLinkLogout()
        {
            Logout.Click();
            return new LogoutPage.LogoutPage();
        }
    }
}
