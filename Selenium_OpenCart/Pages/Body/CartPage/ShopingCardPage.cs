using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    public class ShopingCartPage
    {
        private IWebDriver driver;

        public ShopingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
