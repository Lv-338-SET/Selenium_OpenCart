using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.RegisterPage
{
    public class RegisterPage: IRegisterPage
    {

        protected ISearch Search { get; private set; }

        public IWebElement FirstNameField
        { get { return Search.ElementById("input-firstname"); } }
         
        public IWebElement LastNameField
        { get { return Search.ElementById("input-lastname");} }

        public IWebElement EMailField
        {get { return Search.ElementById("input-email"); } }

        public IWebElement TelephoneField
        { get { return Search.ElementById("input-telephone"); } }
        
      
        public IWebElement PasswordField
        { get { return Search.ElementById("input-password"); } }
        
        public IWebElement PasswordConfirmField
        { get { return Search.ElementById("input-confirm"); } }        

        public bool NewsletterSubscribe { get; private set; } = false;

        public IWebElement PrivacyPolicy
        { get { return Search.ElementByXPath(".//div[@class='pull-right']//input[@type='checkbox' and @name='agree']"); } }
        
        public IWebElement ButtonContinue
        { get { return Search.ElementByCssSelector("input.btn.btn-primary"); } }

        //public IWebElement ButtonSuccess
        //{ get { return Search.ElementByCssSelector("a.btn.btn-primary"); } }

        public RegisterPage()
        {

            Search = Application.Get().Search;
            VeryfyRegisterWebElements();
        }

    

        private void VeryfyRegisterWebElements()
        {
            IWebElement temp;
            temp = FirstNameField;
            temp = LastNameField;
            temp = EMailField;
            temp = TelephoneField;
            temp = PasswordField;
            temp = PasswordConfirmField;
            temp = PrivacyPolicy;
            temp = ButtonContinue;            
        }

        public void ClickFirstName()
        {
            FirstNameField.Click();
        }
        public void InputFirstName(string firstName)
        {
            FirstNameField.SendKeys(firstName);
        }
        public void ClickLastName()
        {
            LastNameField.Click();
        }
        public void InputLastName(string lastName)
        {
            LastNameField.SendKeys(lastName);
        }
        public void ClickEmail()
        {
            EMailField.Click();
        }
        public void InputEmail(string email)
        {
            EMailField.SendKeys(email);
        }
        public void ClickTelephone()
        {
            TelephoneField.Click();
        }
        public void InputTelephone(string telephone)
        {
            TelephoneField.SendKeys(telephone);
        }
       
        
        public void ClickPassword()
        {
            PasswordField.Click();
        }
        public void InputPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickPasswordConfirm()
        {
            PasswordConfirmField.Click();
        }
        public void InputPasswordConfirm(string passwordConfirm)
        {
            PasswordConfirmField.SendKeys(passwordConfirm);
        }
        public void CheckNewsletterSubscribe()
        {
            IWebElement element = Search.ElementByClassName("radio-inline");
            IWebDriver driver = Application.Get().Browser.Driver;
            Actions action = new Actions(driver);
            action.MoveToElement(element, 1, 1).Click().Perform();
            NewsletterSubscribe = true;
        }
        public void ClickPrivacyPolicy()
        {
            PrivacyPolicy.Click();
        }
        public IRegisterPage ClickButtonContinue()
        {
            ButtonContinue.Click();
            if (SuccesRegister())
            {
                return new RegisterSuccessPage();
            }
            else
            {
                return this;
            }
        }

        private bool SuccesRegister()
        {
            try
            {
                var search = Application.Get().Search;
                search.ElementByCssSelector("a.btn.btn-primary");
                return true;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickInputFirstNameField(string firstName)
        {
            FirstNameField.Click();
            FirstNameField.SendKeys(firstName);
        }
        public void ClickInputLastNameField(string lastName)
        {
            LastNameField.Click();
            LastNameField.SendKeys(lastName);
        }
        public void ClickInputEMailField(string email)
        {
            EMailField.Click();
            EMailField.SendKeys(email);
        }
        public void ClickInputTelephoneField(string telephone)
        {
            TelephoneField.Click();
            TelephoneField.SendKeys(telephone);
        }
        public void ClickInputPasswordField(string password)
        {
            PasswordField.Click();
            PasswordField.SendKeys(password);
        }
        public void ClickInputPasswordConfirmField(string passwordConfirm)
        {
            PasswordConfirmField.Click();
            PasswordConfirmField.SendKeys(passwordConfirm);
        }

       


        static bool VerifyRegistrationPage()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByXPath("//div[contains(@id, 'content') and contains(//h1, 'Register Account')]");
                return true;

            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public static RegisterPage UserRegisterPage()
        {
            if (VerifyRegistrationPage())
            {
                return new RegisterPage();
            }
            else
            {
                return null;
            }
        }
    }
}

