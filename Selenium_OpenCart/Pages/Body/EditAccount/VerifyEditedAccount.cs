using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.EditAccount
{
    class VerifyEditedAccount
    {
        public static bool VerifyEditedUser()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByCssSelector(".alert.alert-success.alert-dismissible");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
