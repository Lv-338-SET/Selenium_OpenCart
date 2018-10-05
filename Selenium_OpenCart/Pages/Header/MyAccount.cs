using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Header
{
    public class MyAccount
    {
        private static MyAccount Account = null;
        //private MyAccount() { }

        public static MyAccount MyAccountMenu(IWebDriver driver)
        {
            if (IsLogined(driver))
            {
                Account = new LoginAcountElements(driver);
            }
            else
            {
                Account = new NotLoginetAcountElements(driver);
            }
            return Account;
        }

        private static bool IsLogined(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//a[text()='Register']")).Displayed;
        }
    }

    public class LoginAcountElements: MyAccount
    {
        private IWebDriver driver;

        public IWebElement Register
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Register']"));
            }
        }

        public IWebElement Login
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Login']"));
            }
        }

        public LoginAcountElements(IWebDriver driver)
        {
            this.driver = driver;
        }
    }

    public class NotLoginetAcountElements: MyAccount
    {
        private IWebDriver driver;

        public IWebElement MyAccount
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='My Account']"));
            }
        }
        public IWebElement OrderHistory
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Order History']"));
            }
        }
        public IWebElement Transaction
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Transactions']"));
            }
        }
        public IWebElement Downloads
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Downloads']"));
            }
        }
        public IWebElement Logout
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Logout']"));
            }
        }

        public NotLoginetAcountElements(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}