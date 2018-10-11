using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ChangePasswordPage;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Pages.Body.RegisterPage;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    [SingleThreaded]
    class LoginPageTest
    {
        protected IWebDriver driver;

        const string URL = "http://40.118.125.245/";
        const string URL_LOGOUT = "http://40.118.125.245/index.php?route=account/logout";
        //const string URL_HOME = "http://atqc-shop.epizy.com/index.php?route=common/home";

        [OneTimeSetUp]
        public void SetUp()
        {
            Application.Get();
            Application.Get().Browser.OpenUrl(URL);
        }

        [TearDown]
        public void DeleteCookies()
        {
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            Application.Remove();
        }

        [Test, Order(0)]
        [TestCase("test", "test", "soryv@gmail.com", "067544321", "settest", "settest")]
        public void  RegisterNewUsersTest(string firstName, string lastName, string email,
            string telephone, string password, string passwordConfirm)
        {

            RegisterPageMethod register = new RegisterPageMethod();
            register.ValidRegister(firstName, lastName, email, telephone, password, passwordConfirm);            
            Assert.IsTrue(VerifyRegisteredUser.VerifyRegisteredPage());      
        }

        [Test, Order(1)]
        [TestCase("soryv@gmail.com", "settest")]
        public void LoginedUserTest(string email, string password)
        {
            LoginPageMethods login = new LoginPageMethods();
            login.ValidLogin(email, password);
            Assert.IsTrue(VerifyLoggedPage.VerifyLoggedUser());          
        }
        [Test, Order(2)]
        [TestCase("soryv@gmail.com", "settest", "settest", "settest", "seedmer@gmail.com", "0678765234")]
        public void EditUserAccountTest(string Email, string password, string NewFirstName
            , string NewLastName, string NewEmail, string NewTelephone)
        {
            EditAccountMetod edit = new EditAccountMetod();
            edit.GoToEditAccountPage(Email, password);            
            edit.InputFieldsEditAccount(NewFirstName, NewLastName, NewEmail, NewTelephone);
            Assert.IsTrue(VerifyEditedAccount.VerifyEditedUser());         
        }

        [Test, Order(3)]
        [TestCase("seedter@gmail.com", "settest", "settest", "settest")]
        public void ChangePasswordTest(string email, string password
            , string Newpassword, string NewpasswordConfirm)
        {
            ChangePasswordMethods changePassword = new ChangePasswordMethods();
            changePassword.GoToChangePasswordPage(email, password);
            changePassword.FillingNewPasswords(Newpassword, NewpasswordConfirm);
        }
    }
}
