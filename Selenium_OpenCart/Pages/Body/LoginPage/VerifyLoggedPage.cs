using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.LoginPage
{
    public class VerifyLoggedPage
    {
        public static bool VerifyLoggedUser()
        {

            try
            {
                var search = Application.Get(ApplicationSourceRepository.Default()).Search;
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
