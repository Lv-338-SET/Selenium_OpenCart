using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.ChangePasswordPage
{
    public class VerifyChangedPassword
    {
        public static bool VerifyChangedPasswordUser()
        {

            try
            {
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
                search.ElementByCssSelector("div.alert.alert-success.alert-dismissible");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
