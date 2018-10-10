using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MainPage;

namespace Selenium_OpenCart.Pages.Body.LogoutPage
{
    public class LogoutPage
    {
        private IWebDriver driver;

        private IWebElement LabelLogout
        { get { return driver.FindElement(By.XPath("//div[contains(@id, 'content') and contains(//h1, 'Account Logout')]")); } }

        private IWebElement ButtonContinue
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }

        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage ButtonContinueClick()
        {
            ButtonContinue.Click();
            return new HomePage(driver);
        }
    }
}
