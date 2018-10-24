using OpenQA.Selenium;
using Selenium_OpenCart.Data.Search;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;
using Selenium_OpenCart.Pages.Body.RegisterPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_OpenCart.Logic
{

    class RegisterPageMethod
    {


        public RegisterPageMethod()
        {
            
        }

        public RegisterPage GoToRegisterPage()
        {
            TopBar item = new TopBar();
            item.MyAccountButtonClick();
            NotLoginedUserAcountElements register = new NotLoginedUserAcountElements();
            register.RegisterButtonClick();            
            return new RegisterPage();
        }

        public RegisterPage FillingFieldsRegister(string firstName, string lastName, string email, 
            string telephone, string password, string passwordConfirm)
        {
            RegisterPage filling = new RegisterPage();
            filling.ClickInputFirstNameField(firstName);
            filling.ClickInputLastNameField(lastName);
            filling.ClickInputEMailField(email);
            filling.ClickInputTelephoneField(telephone);
            filling.ClickInputPasswordField(password);
            filling.ClickInputPasswordConfirmField(passwordConfirm);
            filling.CheckNewsletterSubscribe();
            filling.ClickPrivacyPolicy();
            //filling.ClickButtonContinue();
            return filling;
            
        }
        public MyAccountPage ValidRegister(string firstName, string lastName, string email,
            string telephone, string password, string passwordConfirm)
        {
            GoToRegisterPage();

            RegisteredUser(FillingFieldsRegister(firstName, lastName, email, telephone, password, passwordConfirm));
            return new MyAccountPage();
        }

        public RegisterSuccessPage RegisteredUser(RegisterPage regPage)
        {
            return (RegisterSuccessPage)regPage.ClickButtonContinue();
        }

        public MyAccountPage RegisteredUser(RegisterSuccessPage regPage)
        {
            return regPage.ClickButtonsuccess();
        }

    }
}
