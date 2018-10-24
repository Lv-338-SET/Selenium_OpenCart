using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.EditAccount
{
    public class EditAccountPage
    {
        protected ISearch Search { get; private set; }

        public IWebElement EditFirstName
        {
            get
            {
                return Search.ElementById("input-firstname");
            }

        }
        public IWebElement EditLastName
        {
            get
            {
                return Search.ElementById("input-lastname");
            }
        }
        public IWebElement EditEmail
        {
            get
            {
                return Search.ElementById("input-email");
            }
        }
        public IWebElement EditTelephone
        {
            get
            {
                return Search.ElementById("input-telephone");
            }
        }
        public IWebElement EditButtonContinue
        {
            get
            {
                return Search.ElementByCssSelector("input.btn.btn-primary");
            }
        }
       
        public EditAccountPage()
        {

            Search = Application.Get().Search;
            VeryfyEditAccountWebElements();
        }

        private void VeryfyEditAccountWebElements()
        {
            IWebElement temp = EditFirstName;
            temp = EditLastName;
            temp = EditEmail;
            temp = EditTelephone;      
            temp = EditButtonContinue;
        }

        public void ClearEditFirstNane()
        {
            EditFirstName.Clear();
        }
        public void ClickrEditFirstNane()
        {
            EditFirstName.Clear();
        }
        public void InputEditFirstNane(string NewFirstName)
        {
            EditFirstName.SendKeys(NewFirstName);
        }
        public void ClickEditLastName()
        {
            EditLastName.Click();
        }
        public void ClearEditLastName()
        {
            EditLastName.Clear();
        }
        public void InputEdinFalstName(string NewLastName)
        {
            EditLastName.SendKeys(NewLastName);
        }
        public void ClickEditEmail()
        {
            EditEmail.Click();
        }
        public void ClrearEditEmail()
        {
            EditEmail.Clear();
        }
        public void InputEditEmail(string NewEmail)
        {
            EditEmail.SendKeys(NewEmail);
        }
       


        public void ClearClickInputEditFirstName(string NewFirstName)
        {
            EditFirstName.Clear();
            EditFirstName.Click();
            EditFirstName.SendKeys(NewFirstName);

        }
        public void ClearClickInputEditLastName(string NewLastName)
        {
            EditLastName.Clear();
            EditLastName.Click();
            EditLastName.SendKeys(NewLastName);
        }
        public void ClearClickInputEditEmail(string NewEmail)
        {
            EditEmail.Clear();
            EditEmail.Click();
            EditEmail.SendKeys(NewEmail);
        }
        public void ClearClickInputEditTelephone(string NewTelephone)
        {
            EditTelephone.Clear();
            EditTelephone.Click();
            EditTelephone.SendKeys(NewTelephone);
        }
       

        public MyAccountPage ClickEditButtonContinue()
        {
            EditButtonContinue.Click();
            return new MyAccountPage();
        }
        

        public static bool VerifyEditAccountPage()
        {

            try
            {
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
                search.ElementByLinkText("Your Personal Details");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static EditAccountPage UserEditPage()
        {
            if (VerifyEditAccountPage())
            {
                return new EditAccountPage();
            }
            else
            {
                return null;
            }
        }
    }
}

