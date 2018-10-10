using Selenium_OpenCart.AdminPages;
using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.AdminLogic
{
    public class LoginPageLogic
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                return new LoginPage();
            }
        }

        public LoginPageLogic()
        {

        }

        /// <summary>
        /// Click, Clear and Input Text to Username Input on page
        /// Using Fluent Inteface
        /// </summary>
        /// <param name="user">User data in IUser format</param>
        /// <returns>Itself so you can countinue using this page</returns>
        public LoginPageLogic ClickClearAndInputTextInUsernameInput(IUser user)
        {
            LoginPage.ClickOnUsernameInput();
            LoginPage.ClearUsernameInput();
            LoginPage.InputTextInUsernameInput(user);
            return this;
        }

        /// <summary>
        /// Click, Clear and Input Text to Password Input on page
        /// Using Fluent Inteface
        /// </summary>
        /// <param name="user">User data in IUser format</param>
        /// <returns>Itself so you can countinue using this page</returns>
        public LoginPageLogic ClickClearAndInputTextInPasswordInput(IUser user)
        {
            LoginPage.ClickOnPasswordInput();
            LoginPage.ClearPasswordInput();
            LoginPage.InputTextInPasswordInput(user);
            return this;
        }

        /// <summary>
        /// Click, Clear and Input Text to Username Input on page
        /// Click, Clear and Input Text to Password Input on page
        /// Using Fluent Inteface
        /// </summary>
        /// <param name="user">Valid user data in IUser format</param>
        /// <returns>AdminPageLogic page</returns>
        public AdminPageLogic InputValidUserAndLogin(IUser user)
        {
            ClickClearAndInputTextInUsernameInput(user);
            ClickClearAndInputTextInPasswordInput(user);
            LoginPage.ClickOnLoginButton();
            return new AdminPageLogic();
        }
    }
}
