using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Body.MyAccount;

namespace Selenium_OpenCart.Pages.Body.ChangePasswordPage
{
    class ChangePasswordPage
    {
        protected IWebDriver driver;

        public IWebElement ChangePassword
        { get { return driver.FindElement(By.Id("input-password")); } }

        public IWebElement ChangePasswordConfirm
        { get { return driver.FindElement(By.Id("input-confirm")); } }

        public IWebElement ChangeButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }

        public IWebElement CheckButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-default")); } }
        public ChangePasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public void CleraClickInputNewPassword(string password)
        {
            ChangePassword.Clear();
            ChangePassword.Click();
            ChangePassword.SendKeys(password);
        }
        public void CleraClickInputNewPasswordConfirm(string passwordConfirm)
        {
            ChangePasswordConfirm.Clear();
            ChangePasswordConfirm.Click();
            ChangePasswordConfirm.SendKeys(passwordConfirm);
        }

        public void ClickChangeButton()
        {
            ChangeButton.Click();            
        }

        static bool VerifyChangePasswordPage(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.CssSelector("a.btn.btn-default"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public static ChangePasswordPage UserRVerifyChangePasswordPage(IWebDriver driver)
        {
            if (VerifyChangePasswordPage(driver))
            {
                return new ChangePasswordPage(driver);
            }
            else
            {
                return null;
            }
        }

    }
}
