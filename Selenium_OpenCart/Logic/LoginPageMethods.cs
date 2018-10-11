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
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Data.Search;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Logic
{
    class LoginPageMethods
    {
        protected ISearch Search { get; private set; }


        public LoginPageMethods()
        {
            
        }

        public MyAccountPage FillingUserNamePassword(string username, string password)
        {
            LoginPage items = new LoginPage();
            items.ClickClearInputLoginEmail(username);
            items.ClickClearInputLoginPassword(password);
            items.ClickLoginButton();
            return new MyAccountPage();
        }

        public LoginPage GoToLoginPage()
        {
            TopBar item = new TopBar();
            item.MyAccountButtonClick();
            NotLoginedUserAcountElements login = new NotLoginedUserAcountElements();
            login.LoginButtomClick();
            return new LoginPage();            
        }

        public MyAccountPage ValidLogin(string username, string password)
        {
            GoToLoginPage();
            FillingUserNamePassword(username, password);            
            return new MyAccountPage();
        }
    }
}
