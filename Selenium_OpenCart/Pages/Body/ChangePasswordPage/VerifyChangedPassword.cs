using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.ChangePasswordPage
{
    class VerifyChangedPassword
    {
        static bool VerifyChangedPasswordUser()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByCssSelector("div.alert.alert-success");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
