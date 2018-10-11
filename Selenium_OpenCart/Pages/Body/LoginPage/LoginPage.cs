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
    public class LoginPage
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

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public string LoginLable()
        {
            return LabelReturningCustomer.Text;
        }

        public void ClickLabel()
        {
            LabelReturningCustomer.Click();
        }

        public void ClearLoginEmail()
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

        public void ClickLoginPassword()
        {
            LoginPasswordFile.Click();
        }

        public void InputLoginPassword(string password)
        {
            LoginPasswordFile.SendKeys(password);
        }

        ///Email
        public void ClickClearInputLoginEmail(string Email)
        {
            LoginEmailFile.Clear();
            LoginEmailFile.Click();
            LoginEmailFile.SendKeys(Email);

        }
        //Functional Password
        public void ClickClearInputLoginPassword(string password)
        {
            LoginPasswordFile.Clear();
            LoginPasswordFile.Click();
            LoginPasswordFile.SendKeys(password);
        }

        public string GetLoginButtonText()
        {
            return LoginButton.Text;
        }
       
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public static bool VerifyLoginPage(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.XPath("//form[contains(@method,'post')]/../../div[@class = 'well']/h2"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static LoginPage UserLoginPage(IWebDriver driver)
        {
            if (VerifyLoginPage(driver))
            {
                return new LoginPage(driver);
            }
            else
            {
                return null;
            }
        }
    }
}

