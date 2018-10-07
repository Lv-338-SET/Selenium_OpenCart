using OpenQA.Selenium;

using Selenium_OpenCart.AdminPages;
using Selenium_OpenCart.Data.User;

namespace Selenium_OpenCart.AdminLogic
{
    public class LoginPageLogic
    {
        readonly IWebDriver driver;

        public LoginPage LoginPage
        {
            get
            {
                return new LoginPage(driver);
            }
        }

        public LoginPageLogic(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPageLogic ClickClearAndInputTextToUsernameInput(IUser user)
        {
            LoginPage.ClickOnUsernameInput();
            LoginPage.ClearUsernameInput();
            LoginPage.InputTextToUsernameInput(user);
            return this;
        }

        public LoginPageLogic ClickClearAndInputTextToPasswordInput(IUser user)
        {
            LoginPage.ClickOnPasswordInput();
            LoginPage.ClearPasswordInput();
            LoginPage.InputTextToPasswordInput(user);
            return this;
        }

        public AdminPageLogic InputValidUserAndLogin(IUser user)
        {
            ClickClearAndInputTextToUsernameInput(user);
            ClickClearAndInputTextToPasswordInput(user);
            LoginPage.ClickOnLoginButton();
            return new AdminPageLogic(driver);
        }
    }
}
