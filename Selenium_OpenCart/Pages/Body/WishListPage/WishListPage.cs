using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Header;


namespace Selenium_OpenCart
{
    class WishListPage : Header
    {
        protected IWebElement Table { get; private set; }
        protected IWebElement ContinueButton { get; private set; }
        protected List<WishListTableItem> productList { get; private set; }
        protected IWebElement SuccessMessage { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }

        public WishListPage(IWebDriver driver) : base(driver)
        {
            this.Table = driver.FindElement(By.XPath("//div[@class='table-responsive']"));
            this.ContinueButton = driver.FindElement(By.LinkText("Continue"));
            productList = InitializeProductList(driver.FindElements(By.XPath("//div[@class='table-responsive']//tbody")));

        }

        public List<WishListTableItem> InitializeProductList(IReadOnlyCollection<IWebElement> elements)
        {
            List<WishListTableItem> list = new List<WishListTableItem>();

            foreach (var current in elements)
            {
                list.Add(new WishListTableItem(driver, current));
            }
            return list;
        }

        public List<WishListTableItem> GetProductList()
        {
            return this.productList;
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public WishListTableItem GetRequiredProduct(string product)
        {
            foreach (var item in GetProductList())
            {
                if (item.ProductNameIsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }
        public WishListPage RemoveProductFromWishList(string product)
        {
            GetRequiredProduct(product).ClickRemoveFromWishListButton();
            return this;
        }
        public WishListPage AddToCartFromWishList(string product)
        {
            GetRequiredProduct(product).ClickAddToCartButton();
            return this;
        }

        public bool ProductExistsInWishList(string product)
        {
            if (GetRequiredProduct(product) == null)
            {
                return false;
            }
            else return true;
        }
        public bool SuccessMessageIsDisplayed()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return SuccessMessage.Displayed;
        }
    }
}