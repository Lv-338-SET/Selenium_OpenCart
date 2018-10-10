using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    public class WishListWithProducts
    {
        protected IWebElement Table { get { return Application.Get().Search.ElementByXPath("//div[@class='table-responsive']"); } }
        protected IWebElement TableRow { get { return Application.Get().Search.ElementByXPath("//div[@class='table-responsive']//tbody"); } }
        protected WishListTableItem product { get { return GetProductElement(GetTableRow()); } }
        protected IWebElement SuccessMessage { get { return Application.Get().Search.ElementByCssSelector(".alert.alert-success"); }}

        public WishListWithProducts(IWebDriver driver)
        {

        }

        #region Initialization
        public WishListTableItem GetProductElement(IWebElement element)
        {
            return new WishListTableItem(element);
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
            return SuccessMessage.Displayed;
        }

        #endregion

        #region Business Logic

        
        #endregion
    }
}
