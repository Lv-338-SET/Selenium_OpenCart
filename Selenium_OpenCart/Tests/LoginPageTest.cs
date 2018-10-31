using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.ChangePasswordPage;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.RegisterPage;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    [Parallelizable]
    class LoginPageTest
    {        

        //const string URL = "http://40.118.125.245/";
        //const string URL_LOGOUT = "http://40.118.125.245/index.php?route=account/logout";
        ////const string URL_HOME = "http://atqc-shop.epizy.com/index.php?route=common/home";

        [OneTimeSetUp]
        public void SetUp()
        {
            Application.Get();
            Application.Get().Browser.OpenUrl(Application.Get().ApplicationSource.HomePageUrl);
        }

        [TearDown]
        public void DeleteCookies()
        {
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Get().Browser.OpenUrl(Application.Get().ApplicationSource.LogoutPageUrl);
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {                        
            Application.Remove();
            DBDataReader name = new DBDataReader();
            name.DeleteUsers("Clll7y@gmail.com");
        }

        [Test, Order(0)]
        [TestCase("test", "test", "Orest777Test1@gmail.com", "067544321", "settest", "settest")]
        public void  RegisterNewUsersTest(string firstName, string lastName, string email,
            string telephone, string password, string passwordConfirm)
        {
            RegisterPageMethod register = new RegisterPageMethod();
            register.ValidRegister(firstName, lastName, email, telephone, password, passwordConfirm);            
            Assert.IsTrue(VerifyRegisteredUser.VerifyRegisteredPage());      
        }

        [Test, Order(1)]
        [TestCase("Orest777Test1@gmail.com", "settest")]
        public void LoginedUserTest(string email, string password)
        {
            //LoginPageMethods login = new LoginPageMethods();
            //login.LogIntoAccount(email, password);
            //Assert.IsTrue(VerifyLoggedPage.VerifyLoggedUser());
            new LoginPageMethods()
                .LogIntoAccount(email, password);
            Assert.IsTrue(VerifyLoggedPage.VerifyLoggedUser());
        }

        [Test, Order(2)]
        [TestCase("Orest777Test1@gmail.com", "settest", "settest", "settest", "Clll7y@gmail.com", "0678765234")]
        public void EditUserAccountTest(string Email, string password, string NewFirstName
            , string NewLastName, string NewEmail, string NewTelephone)
        {
            EditAccountMetod edit = new EditAccountMetod();
            edit.GoToEditAccountPage(Email, password);            
            edit.InputFieldsEditAccount(NewFirstName, NewLastName, NewEmail, NewTelephone);
            Assert.IsTrue(VerifyEditedAccount.VerifyEditedUser());         
        }

        [Test, Order(3)]
        [TestCase("Clll7y@gmail.com", "settest", "settest", "settest")]
        public void ChangePasswordTest(string email, string password
            , string Newpassword, string NewpasswordConfirm)
        {
            ChangePasswordMethods changePassword = new ChangePasswordMethods();
            changePassword.GoToChangePasswordPage(email, password);
            changePassword.FillingNewPasswords(Newpassword, NewpasswordConfirm);
            Assert.IsTrue(VerifyChangedPassword.VerifyChangedPasswordUser());            
        }

       
    }
}
