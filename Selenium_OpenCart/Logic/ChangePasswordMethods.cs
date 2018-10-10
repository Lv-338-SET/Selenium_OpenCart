using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.ChangePasswordPage;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    class ChangePasswordMethods
    {
        protected IWebDriver driver;


        public ChangePasswordMethods(IWebDriver driver)
        {
            this.driver = driver;
        }


        public MyAccountPage FillingNewPasswords(string password, string passwordConfirm)
        {
            ChangePasswordPage items = new ChangePasswordPage(driver);
            items.CleraClickInputNewPassword(password);
            items.CleraClickInputNewPasswordConfirm(passwordConfirm);
            items.ClickChangeButton();
            return new MyAccountPage(driver);
        }

       public ChangePasswordPage GoToChangePasswordPage(string Email, string loginpassword)
        {
            LoginPageMethods login = new LoginPageMethods(driver);
            login.ValidLogin(Email, loginpassword);
            MyAccountPage account = new MyAccountPage(driver);
            account.ClickChangePassword();
            return new ChangePasswordPage(driver);
        }

        public MyAccountPage ValidChangePassword(string password, string passwordConfirm,string Email, string loginpassword)
        {
            LoginPageMethods login = new LoginPageMethods(driver);
            login.ValidLogin(Email, loginpassword);
            MyAccountPage account = new MyAccountPage(driver);
            account.ClickChangePassword();
            FillingNewPasswords(password, passwordConfirm);
            return new MyAccountPage(driver);
        }
    }
}
