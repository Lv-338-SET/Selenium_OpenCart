using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    class AddToCartMetods
    {
        IWebDriver webDriver;
        public void n()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.GetListProduct();
            foreach (var s in homePage.GetListProduct())
            {
                s.ClickCartButton();
            }
        }
       

    }
}
