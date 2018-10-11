using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.LoginPage
{
    public class LoginPage //: Header
    {
        protected ISearch Search { get; private set; }

        public IWebElement LabelReturningCustomer
        {
            get
            {
                return Search.ElementByXPath("//form[contains(@method,'post')]/../../div[@class = 'well']/h2");
            }
        }
        public IWebElement LoginEmailFile
        {
            get
            {
                return Search.ElementById("input-email");
            }
        }
        public IWebElement LoginPasswordFile
        {
            get
            {
                return Search.ElementById("input-password");
            }
        }
        public IWebElement LoginButton
        {
            get
            {
                return Search.ElementById("input.btn.btn-primary");
            }
        }

        public LoginPage()
        {
            Search = Application.Get(ApplicationSourceRepository.Default()).Search;
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

        public static bool VerifyLoginPage()
        {

            try
            {
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
                search.ElementByXPath("//form[contains(@method,'post')]/../../div[@class = 'well']/h2");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static LoginPage UserLoginPage()
        {
            if (VerifyLoginPage())
            {
                return new LoginPage();
            }
            else
            {
                return null;
            }
        }
    }
}

