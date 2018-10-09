using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using Selenium_OpenCart.Pages.Body.ProductPage;

namespace Selenium_OpenCart.Logic.ProductPageLogic
{
    public class ProductPageLogic
    {
        protected IWebDriver driver;

        public ProductPage ProductPage
        {
            get
            {
                return new ProductPage(driver);
            }
        }

        public ProductPageInfo ProductPageInfo
        {
            get
            {
                return new ProductPageInfo(driver);
            }
        }
    }
}
