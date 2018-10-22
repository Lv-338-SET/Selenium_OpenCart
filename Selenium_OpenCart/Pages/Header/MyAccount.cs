using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.LogoutPage;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;
using Selenium_OpenCart.Pages.Body.RegisterPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using System.Threading;

namespace Selenium_OpenCart.Pages.Header
{
    public class MyAccount
    {
        private static MyAccount Account = null;
        //private MyAccount() { }

        public static MyAccount MyAccountMenu()
        {
            Thread.Sleep(1000);
            if (IsLogedIn())
            {
                Account = new NotLoginedUserAcountElements();
            }
            else
            {
                Account = new LoginedUSerAcountElements();
            }
            return Account;
        }

        public static bool IsLogedIn()
        {
            try
            {
                var search = Application.Get().Search;
                IWebElement registerButton = search.ElementByXPath("//a[text()='Register']");
                return registerButton != null || registerButton.Enabled || registerButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    public class NotLoginedUserAcountElements: MyAccount
    {
        protected ISearch search;

        private IWebElement RegisterButton
        { get { return search.ElementByXPath("//a[text()='Register']"); } }

        private IWebElement LoginButton
        { get { return search.ElementByXPath("//a[text()='Login']"); } }

        public NotLoginedUserAcountElements()
        {
            search = Application.Get().Search;
        }

        public RegisterPage RegisterButtonClick()
        {
            RegisterButton.Click();
            return new RegisterPage();
        }

        public LoginPage LoginButtomClick()
        {
            LoginButton.Click();
            return new LoginPage();
        }
    }

    public class LoginedUSerAcountElements: MyAccount
    {
        protected ISearch search;

        private IWebElement MyAccount
        { get { return search.ElementByXPath("//a[text()='My Account']"); } }
        private IWebElement OrderHistory
        { get { return search.ElementByXPath("//a[text()='Order History']"); } }
        private IWebElement Transaction
        { get { return search.ElementByXPath("//a[text()='Transactions']"); } }
        private IWebElement Downloads
        { get { return search.ElementByXPath("//a[text()='Downloads']"); } }
        private IWebElement Logout
        { get { return search.ElementByXPath("//li/a[text()='Logout']"); } }

        public LoginedUSerAcountElements()
        {
            search = Application.Get().Search;
        }

        public MyAccountPage MyAccountClick()
        {
            MyAccount.Click();
            return new MyAccountPage();
        }

        public LogoutPage LogoutClick()
        {
            Thread.Sleep(500);
            Logout.Click();
            return new LogoutPage();
        }
    }
}