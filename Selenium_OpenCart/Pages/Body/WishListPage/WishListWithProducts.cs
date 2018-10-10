using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    public class WishListWithProducts:WishListPage
    {
        protected IWebElement Table { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']")); } }
        protected IWebElement TableRow { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']//tbody")); } }
        protected WishListTableItem product { get { return GetProduct(GetTableRow()); } }
        protected IWebElement SuccessMessage { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); }}

        public WishListWithProducts(IWebDriver driver) : base(driver)
        {

        }

        #region Initialization
        public WishListTableItem GetProduct(IWebElement element)
        {
            return new WishListTableItem(driver, element);
        }
        #endregion

        #region Atomic Operations
        public IWebElement GetTable()
        {
            return this.Table;
        }
        public IWebElement GetTableRow()
        {
            return this.TableRow;
        }
        public WishListTableItem GetProduct()
        {
            return this.product;
        }
        public bool SuccessMessageIsDisplayed()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return SuccessMessage.Displayed;
        }

        #endregion

        #region Business Logic

        
        #endregion
    }
}
