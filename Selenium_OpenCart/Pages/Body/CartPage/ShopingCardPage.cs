using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.WishListPage;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    public class ShoppingCartPage : Header.Header
    {
        private IWebDriver driver;
        protected IWebElement Table { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']")); } }
        protected IWebElement ButtonContinue { get { return driver.FindElement(By.XPath("//a[text() = 'Continue']")); } }
        protected List<ShopingCartTableItem> ListShopingCartProducts { get { return ListProductFromHomePage(driver.FindElements(By.XPath("//div[@class='table-responsive']//tbody"))); } }

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        { }

        public List<ShopingCartTableItem> ListProductFromHomePage(IReadOnlyCollection<IWebElement> cartPageElements)
        {
            List<ShopingCartTableItem> listElements = new List<ShopingCartTableItem>();

            foreach (var currents in cartPageElements)
            {
                listElements.Add(new ShopingCartTableItem(driver, currents));
            }
            return listElements;
        }

        public HomePage GoToMainPageIfCartIsEmpty()
        {
            ButtonContinue.Click();
            return new HomePage(driver);
        }

        public List<ShopingCartTableItem> GetProductList()
        {
            return this.ListShopingCartProducts;
        }
        public IWebElement GetTable()
        {
            return this.Table;
        }

        public bool IsCardEmpty(IWebElement element)
        {
            try
            {
                return ButtonContinue != null || ButtonContinue.Enabled || ButtonContinue.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
    }
}
