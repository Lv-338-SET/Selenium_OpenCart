using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Selenium_OpenCart.Pages.Body.LoginPage
{
    class LoginPage
    {
        protected IWebDriver driver;
        public IWebElement LabelReturningCustomer
        {
            get
            {
                return driver.FindElement(By.XPath("//form[contains(@method,'post')]/../../div[@class = 'well']/h2"));
            }

        }
        public IWebElement LoginEmailFile
        {
            get
            {
                return driver.FindElement(By.Id("input-email"));
            }
        }
        public IWebElement LoginPasswordFile
        {
            get
            {
                return driver.FindElement(By.Id("input-password"));

            }
        }
        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            }
        }

        public LoginPage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClrearLoginEmail()        
        {
            LoginEmailFile.Clear();
        }

        public void ClickLoginEmail()
        {
            LoginEmailFile.Click();
        }

        public void InputLoginEmail(string Email)
        {
            LoginEmailFile.SendKeys(Email);
        }

        public void ClearLoginPassword()
        {
            LoginPasswordFile.Clear();
        }

        public void ClikLoginPassword()
        {
            LoginPasswordFile.Click();
        }

        public void InputLoginPassword(string password)
        {
            LoginPasswordFile.SendKeys(password);
        }
    }
}
