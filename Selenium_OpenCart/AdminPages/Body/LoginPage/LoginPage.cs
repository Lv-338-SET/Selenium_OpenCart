using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.Data.User;

namespace Selenium_OpenCart.AdminPages
{
    public class LoginPage : LoginPageLogic
    {
        #region Properties
        protected IWebElement UsernameInput
        {
            get
            {
                return Search.ElementById("input-username");
            }
        }

        protected IWebElement PasswordInput
        {
            get
            {
                return Search.ElementById("input-password");
            }
        }

        protected IWebElement LoginButton
        {
            get
            {
                return Search.ElementByXPath(".//form//div//button[@type='submit']");
            }
        }
        #endregion

        #region Initialization And Verifycation
        public LoginPage()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = UsernameInput;
            tmp = PasswordInput;
            tmp = LoginButton;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsLoginPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for UsernameInput
        public void ClickOnUsernameInput()
        {
            UsernameInput.Click();
        }

        public void ClearUsernameInput()
        {
            UsernameInput.Clear();
        }

        /// <summary>
        /// Inputs username to Username Input on page
        /// </summary>
        /// <param name="user">User data in IUser format</param>
        public void InputTextInUsernameInput(IUser user)
        {
            UsernameInput.SendKeys(user.GetUsername());
        }
        #endregion

        #region Atomic operations for PasswordInput
        public void ClickOnPasswordInput()
        {
            PasswordInput.Click();
        }

        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        /// <summary>
        /// Inputs user password to Password Input on page
        /// </summary>
        /// <param name="user">User data in IUser format</param>
        public void InputTextInPasswordInput(IUser user)
        {
            PasswordInput.SendKeys(user.GetPassword());
        }
        #endregion

        #region Atomic operations for LoginButton
        public string GetTextFromLoginButton()
        {
            return LoginButton.Text;
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }
        #endregion
        #endregion
    }
}
