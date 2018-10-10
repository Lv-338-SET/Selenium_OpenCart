using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    class ShopingCartPageWithProducts:ShopingCartPage
    {
        protected IWebElement Table { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']")); } }
        protected IWebElement TableRow { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']//tbody")); } }
        protected ShopingCartTableItem product { get { return GetProduct(GetTableRow()); } }
        protected IWebElement SuccessMessage { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }

        public ShopingCartTableItem GetProduct(IWebElement element)
        {
            return new ShopingCartTableItem(driver, element);
        }

        public IWebElement GetTableRow()
        {
            return this.TableRow;
        }

        public ShopingCartTableItem GetProduct()
        {
            return this.product;
        }

        ShopingCartPageWithProducts(IWebDriver driver) : base(driver)
        {

        }
    }
}
