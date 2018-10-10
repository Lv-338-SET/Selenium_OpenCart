using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ContactPage
{
    public class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
