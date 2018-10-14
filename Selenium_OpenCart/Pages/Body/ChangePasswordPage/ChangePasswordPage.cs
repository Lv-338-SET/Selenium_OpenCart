using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.ChangePasswordPage
{
    public class ChangePasswordPage
    {
        protected ISearch Search { get; private set; }

        public IWebElement ChangePassword
        { get { return Search.ElementById("input-password"); } }

        public IWebElement ChangePasswordConfirm
        { get { return Search.ElementById("input-confirm"); } }

        public IWebElement ChangeButton
        { get { return Search.ElementByCssSelector("input.btn.btn-primary"); } }

        public IWebElement CheckButton
        { get { return Search.ElementByCssSelector("a.btn.btn-default"); } }

        public ChangePasswordPage()
        {
            Search = Application.Get().Search;

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

        static bool VerifyChangePasswordPage()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByCssSelector("a.btn.btn-default");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public static ChangePasswordPage UserRVerifyChangePasswordPage()
        {
            if (VerifyChangePasswordPage())
            {
                return new ChangePasswordPage();
            }
            else
            {
                return null;
            }
        }

    }
}
