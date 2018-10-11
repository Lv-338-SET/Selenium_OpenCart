using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.ContactPage
{
    public class ContactPage
    {
        private ISearch search;

        public ContactPage()
        {
            search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }
    }
}
