using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;


namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    class WishListPage : Header.Header
    {
        protected IWebElement Label { get { return driver.FindElement(By.CssSelector(".col - sm - 9 h2}; private set;")); }}
        protected IWebElement Table { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']")); }}
        protected IWebElement ContinueButton { get { return driver.FindElement(By.LinkText("Continue")); }}
        protected List<WishListTableItem> productList { get { return InitializeProductList(driver.FindElements(By.XPath("//div[@class='table-responsive']//tbody")));}}
        protected IWebElement SuccessMessage { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); }}

        public WishListPage(IWebDriver driver) : base(driver)
        {

        }

        #region Initialization
        public List<WishListTableItem> InitializeProductList(IReadOnlyCollection<IWebElement> elements)
        {
            List<WishListTableItem> list = new List<WishListTableItem>();

            foreach (var current in elements)
            {
                list.Add(new WishListTableItem(driver, current));
            }
            return list;
        }
        #endregion

        #region Atomic Operations

        public string GetLabel()
        {
            return this.Label.Text;
        }
        public IWebElement GetTable()
        {
            return this.Table;
        }
        public List<WishListTableItem> GetProductList()
        {
            return this.productList;
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }
        public bool SuccessMessageIsDisplayed()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return SuccessMessage.Displayed;
        }

        #endregion

        #region Business Logic
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

        public bool ProductExistsInWishList(string product)
        {
            if (GetRequiredProduct(product) == null)
            {
                return false;
            }
            else return true;
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
        #endregion


    }
}