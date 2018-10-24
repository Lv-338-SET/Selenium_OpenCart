using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.RegisterPage
{
    public class VerifyRegisteredUser
    {
        public static bool VerifyRegisteredPage()
        {

            try
            {
                var search = Application.Get().Search;
                search.ElementByXPath("//a[contains(@href,'/logout')]");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
