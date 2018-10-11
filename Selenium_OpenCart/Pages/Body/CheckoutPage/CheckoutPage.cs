using OpenQA.Selenium;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.CheckoutPage
{
    public class CheckoutPage
    {
        private ISearch search;

        public CheckoutPage()
        {
            search = Application.Get().Search;

        }
    }
}
