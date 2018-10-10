using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    class EditAccountMetod
    {
        IWebDriver driver;


        public EditAccountMetod(IWebDriver driver)
        {
            this.driver = driver;
        }

        public EditAccountPage GoToEditAccountPage(string Email, string password)
        {
            LoginPageMethods login = new LoginPageMethods(driver);
            login.GoToLoginPage();
            login.FillingUserNamePassword(Email, password);
            MyAccountPage page = new MyAccountPage(driver);
            page.ClickEditAccount();           
            return new EditAccountPage(driver);
        }

        public MyAccountPage InputFieldsEditAccount(string NewFirstName, string NewLastName, string NewEmail, string NewTelephone)
        {
            EditAccountPage items = new EditAccountPage(driver);
            items.ClearClickInputEditFirstName(NewFirstName);
            items.ClearClickInputEditLastName(NewLastName);
            items.ClearClickInputEditEmail(NewEmail);
            items.ClearClickInputEditTelephone(NewTelephone);            
            items.ClickEditButtonContinue();
            //items.ClickEditButtonContinueHome();
            return new MyAccountPage(driver);
        }
        public MyAccountPage ValidEditAccount(string Email, string password, string NewFirstName, string NewLastName, string NewEmail, string NewTelephone)
        {
            GoToEditAccountPage(Email, password);
            InputFieldsEditAccount(NewFirstName, NewLastName, NewEmail, NewTelephone);
            return new MyAccountPage(driver);
        }

    }
}
