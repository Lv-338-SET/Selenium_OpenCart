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
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
                search.ElementByXPath("//a[contains(@href,'/logout')]");
                //driver.FindElement(By.XPath("//div[contains(@id, 'content') and contains(//h1, 'Your Account Has Been Created!')]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
