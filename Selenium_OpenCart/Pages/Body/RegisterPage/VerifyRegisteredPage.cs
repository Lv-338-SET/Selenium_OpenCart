using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Body.RegisterPage
{
    public class VerifyRegisteredUser
    {
        public static bool VerifyRegisteredPage(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.XPath("//a[contains(@href,'/logout')]"));
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
