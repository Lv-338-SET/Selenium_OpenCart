using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.MyAccountPage;



namespace Selenium_OpenCart.Logic
{
    class LoginPageMethods
    {
        protected ISearch Search { get; private set; }
        

        public LoginPageMethods()
        {
            Search = Application.Get(ApplicationSourceRepository.Default()).Search;
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
<<<<<<< HEAD
            LoginAcountElements login = new LoginAcountElements();
=======
            NotLoginedUserAcountElements login = new NotLoginedUserAcountElements(driver);
>>>>>>> 6a5eada33258a5b5f24ae8e625e633a2ef549d8d
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
