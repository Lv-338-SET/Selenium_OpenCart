using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.LogoutPage;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using TestSite.Pages.RegisterPage;

namespace Selenium_OpenCart.Pages.Header
{
    public class MyAccount
    {
        private static MyAccount Account = null;
        //private MyAccount() { }

        public static MyAccount MyAccountMenu(IWebDriver driver)
        {
            if (IsLogedIn(driver))
            {
                Account = new LoginAcountElements(driver);
            }
            else
            {
                Account = new NotLoginetAcountElements(driver);
            }
            return Account;
        }

        private static bool IsLogedIn(IWebDriver driver)
        {
            try
            { 
                driver.FindElement(By.XPath("//a[text()='Register']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    public class LoginAcountElements: MyAccount
    {
        private IWebDriver driver;

        private IWebElement RegisterButton
        { get { return driver.FindElement(By.XPath("//a[text()='Register']")); } }

        private IWebElement LoginButton
        { get { return driver.FindElement(By.XPath("//a[text()='Login']")); } }

        public LoginAcountElements(IWebDriver driver)
        {
            this.driver = driver;
        }

        public RegisterPage RegisterButtonClick()
        {
            RegisterButton.Click();
            return new RegisterPage(driver);
        }

        public LoginPage LoginButtomClick()
        {
            LoginButton.Click();
            return new LoginPage(driver);
        }
    }

    public class NotLoginetAcountElements: MyAccount
    {
        private IWebDriver driver;

        private IWebElement MyAccount
        { get { return driver.FindElement(By.XPath("//a[text()='My Account']")); } }
        private IWebElement OrderHistory
        { get { return driver.FindElement(By.XPath("//a[text()='Order History']")); } }
        private IWebElement Transaction
        { get { return driver.FindElement(By.XPath("//a[text()='Transactions']")); } }
        private IWebElement Downloads
        { get { return driver.FindElement(By.XPath("//a[text()='Downloads']")); } }
        private IWebElement Logout
        { get { return driver.FindElement(By.XPath("//a[text()='Logout']")); } }

        public NotLoginetAcountElements(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MyAccountPage MyAccountClick()
        {
            MyAccount.Click();
            return new MyAccountPage(driver);
        }

        public LogoutPage LogoutClick()
        {
            Logout.Click();
            return new LogoutPage(driver);
        }
    }
}