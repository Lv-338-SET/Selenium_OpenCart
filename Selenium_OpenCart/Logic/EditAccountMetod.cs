using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Pages.Body.MyAccountPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Logic
{
    class EditAccountMetod
    {
        protected ISearch Search { get; private set; }


        public EditAccountMetod()
        {
            Search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }

        public EditAccountPage GoToEditAccountPage(string Email, string password)
        {
            LoginPageMethods login = new LoginPageMethods();
            login.GoToLoginPage();
            login.FillingUserNamePassword(Email, password);
            MyAccountPage page = new MyAccountPage();
            page.ClickLinkEditAccount();           
            return new EditAccountPage();
        }

        public MyAccountPage InputFieldsEditAccount(string NewFirstName, string NewLastName, string NewEmail, string NewTelephone)
        {
            EditAccountPage items = new EditAccountPage();
            items.ClearClickInputEditFirstName(NewFirstName);
            items.ClearClickInputEditLastName(NewLastName);
            items.ClearClickInputEditEmail(NewEmail);
            items.ClearClickInputEditTelephone(NewTelephone);            
            items.ClickEditButtonContinue();
            //items.ClickEditButtonContinueHome();
            return new MyAccountPage();
        }
        public MyAccountPage ValidEditAccount(string Email, string password, string NewFirstName, string NewLastName, string NewEmail, string NewTelephone)
        {
            GoToEditAccountPage(Email, password);
            InputFieldsEditAccount(NewFirstName, NewLastName, NewEmail, NewTelephone);
            return new MyAccountPage();
        }

    }
}
