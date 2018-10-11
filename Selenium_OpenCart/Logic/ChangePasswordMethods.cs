using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.ChangePasswordPage;
<<<<<<< HEAD
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
=======
using Selenium_OpenCart.Pages.Body.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 6a5eada33258a5b5f24ae8e625e633a2ef549d8d

namespace Selenium_OpenCart.Logic
{
    class ChangePasswordMethods
    {
        protected ISearch Search { get; private set; }


        public ChangePasswordMethods()
        {
            Search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }


        public MyAccountPage FillingNewPasswords(string password, string passwordConfirm)
        {
            ChangePasswordPage items = new ChangePasswordPage();
            items.CleraClickInputNewPassword(password);
            items.CleraClickInputNewPasswordConfirm(passwordConfirm);
            items.ClickChangeButton();
            return new MyAccountPage();
        }

       public ChangePasswordPage GoToChangePasswordPage(string Email, string loginpassword)
        {
            LoginPageMethods login = new LoginPageMethods();
            login.ValidLogin(Email, loginpassword);
            MyAccountPage account = new MyAccountPage();
            account.ClickLinkChangePassword();
            return new ChangePasswordPage();

        }

        public MyAccountPage ValidChangePassword(string password, string passwordConfirm,string Email, string loginpassword)
        {
            LoginPageMethods login = new LoginPageMethods();
            login.ValidLogin(Email, loginpassword);
            MyAccountPage account = new MyAccountPage();
            account.ClickLinkChangePassword();
            FillingNewPasswords(password, passwordConfirm);
            return new MyAccountPage();
        }
    }
}
