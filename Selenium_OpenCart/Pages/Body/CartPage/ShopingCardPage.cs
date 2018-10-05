using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    class ShopingCardPage
    {
        private IWebDriver driver;

        public ShopingCardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
