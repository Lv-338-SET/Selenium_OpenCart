using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.ChangePasswordPage
{
    class VerifyChangedPassword
    {
        static bool VerifyChangedPasswordUser(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.CssSelector("div.alert.alert-success"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
