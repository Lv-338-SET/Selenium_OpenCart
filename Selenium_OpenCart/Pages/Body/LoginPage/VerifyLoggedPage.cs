using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.LoginPage
{
    public class VerifyLoggedPage
    {
        public static bool VerifyLoggedUser(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.XPath("//a[contains(@href,'/logout')]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
