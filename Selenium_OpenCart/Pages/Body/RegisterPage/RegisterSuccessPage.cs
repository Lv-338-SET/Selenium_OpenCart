using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;

namespace Selenium_OpenCart.Pages.Body.RegisterPage
{
    class RegisterSuccessPage : IRegisterPage
    {
        protected ISearch Search { get; private set; }

        public IWebElement ButtonSuccess
        { get { return  Search.ElementByCssSelector("a.btn.btn-primary"); } }

        public RegisterSuccessPage()
        {

            Search = Application.Get().Search;
            VerifyRegisterSuccessPage();
        }
        private void VerifyRegisterSuccessPage()
        {
            IWebElement temp;
            temp = ButtonSuccess;
        }

        public MyAccountPage ClickButtonsuccess()
        {
            ButtonSuccess.Click();
            return new MyAccountPage();
        }
    }
}
