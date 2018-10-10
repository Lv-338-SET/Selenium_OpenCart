using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Body.EditAccount
{
    class VerifyEditedAccount
    {
        public static bool VerifyEditedUser(IWebDriver driver)
        {

            try
            {
                //driver.FindElement(By.CssSelector("#content.col-sm-9 h1"));
                driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}
