using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.LogoutPage;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Pages.Body.RegisterPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;


namespace Selenium_OpenCart.Pages.Header
{
    public class MyAccount
    {
        private static MyAccount Account = null;
        //private MyAccount() { }

        public static MyAccount MyAccountMenu()
        {
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
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
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
            search = Application.Get(ApplicationSourceRepository.Default()).Search;
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
        { get { return search.ElementByXPath("//a[text()='Logout']"); } }

        public LoginedUSerAcountElements()
        {
            search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }

        public MyAccountPage MyAccountClick()
        {
            MyAccount.Click();
            return new MyAccountPage();
        }

        public LogoutPage LogoutClick()
        {
            Logout.Click();
            return new LogoutPage();
        }
    }
}