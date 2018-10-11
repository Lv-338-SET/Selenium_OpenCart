using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.LogoutPage
{
    public class LogoutPage
    {
        protected ISearch search;

        private IWebElement LabelLogout
        { get { return search.ElementByXPath(("//div[contains(@id, 'content') and contains(//h1, 'Account Logout')]"); } }

        private IWebElement ButtonContinue
        { get { return search.ElementByCssSelector("a.btn.btn-primary"); } }

        public LogoutPage()
        {
            search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }

        public HomePage ButtonContinueClick()
        {
            ButtonContinue.Click();
            return new HomePage(Application.Get(ApplicationSourceRepository.Default()).Browser.Driver);
        }
    }
}
