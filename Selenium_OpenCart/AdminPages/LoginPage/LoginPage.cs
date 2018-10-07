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

        private void VerifyPage()
        {
            IWebElement tmp = this.UsernameInput;
            tmp = this.PasswordInput;
            tmp = this.LoginButton;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for UsernameInput
        public void ClickOnUsernameInput()
        {
            this.UsernameInput.Click();
        }

        public void ClearUsernameInput()
        {
            this.UsernameInput.Clear();
        }

        public void InputTextToUsernameInput(IUser user)
        {
            this.UsernameInput.SendKeys(user.GetUsername());
        }
        #endregion

        #region Atomic operations for PasswordInput
        public void ClickOnPasswordInput()
        {
            this.PasswordInput.Click();
        }

        public void ClearPasswordInput()
        {
            this.PasswordInput.Clear();
        }

        public void InputTextToPasswordInput(IUser user)
        {
            this.PasswordInput.SendKeys(user.GetPassword());
        }
        #endregion

        #region Atomic operations for LoginButton
        public string GetTextFromLoginButton()
        {
            return this.LoginButton.Text;
        }

        public void ClickOnLoginButton()
        {
            this.LoginButton.Click();
        }
        #endregion
        #endregion
    }
}
