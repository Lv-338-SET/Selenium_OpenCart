using Selenium_OpenCart.Pages.Body.ChangePasswordPage;
using Selenium_OpenCart.Pages.Body.MyAccountPage;

namespace Selenium_OpenCart.Logic
{
    class ChangePasswordMethods
    {

        public ChangePasswordMethods()
        {
            
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
