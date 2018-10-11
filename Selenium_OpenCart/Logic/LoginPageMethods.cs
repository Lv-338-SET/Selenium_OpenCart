using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.SearchPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.MyAccount;

namespace Selenium_OpenCart.Logic
{
    class LoginPageMethods
    {
        protected IWebDriver driver;
        

        public LoginPageMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MyAccountPage FillingUserNamePassword(string username, string password)
        {
            LoginPage items = new LoginPage(driver);
            items.ClickClearInputLoginEmail(username);
            items.ClickClearInputLoginPassword(password);
            items.ClickLoginButton();
            return new MyAccountPage(driver);
        }

        public LoginPage GoToLoginPage()
        {
            TopBar item = new TopBar();
            item.MyAccountButtonClick();
            NotLoginedUserAcountElements login = new NotLoginedUserAcountElements();
            login.LoginButtomClick();
            return new LoginPage(driver);            
        }

        public MyAccountPage LogIntoAccount(string username, string password)
        {
            GoToLoginPage();
            FillingUserNamePassword(username, password);            
            return new MyAccountPage(driver);
        }
    }
}
