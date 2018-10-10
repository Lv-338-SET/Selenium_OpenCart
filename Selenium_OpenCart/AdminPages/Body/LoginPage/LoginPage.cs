using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.User;

namespace Selenium_OpenCart.AdminPages
{
    public class LoginPage
    {
        private IWebDriver driver;
        #region Properties
        protected IWebElement UsernameInput
        {
            get
            {
                return driver.FindElement(By.Id("input-username"));
            }
        }

        protected IWebElement PasswordInput
        {
            get
            {
                return driver.FindElement(By.Id("input-password"));
            }
        }

        protected IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.XPath(".//form//div//button[@type='submit']"));
            }
        }
        #endregion

        #region Initialization And Verifycation
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
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
