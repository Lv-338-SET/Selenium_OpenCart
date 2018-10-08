using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    class ShopingCartTableItem
    {
        protected IWebElement Image { get; private set; }
        protected IWebElement ProductName { get; private set; }
        protected IWebElement Model { get; private set; }
        protected IWebElement Quantity { get; private set; }
        protected IWebElement UnitPrice { get; private set; }
        protected IWebElement Total{ get; private set; }
        protected IWebElement RemoveFromWishlistButton { get; private set; }



    }
}
