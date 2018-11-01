using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;
using Selenium_OpenCart.Tools;


namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    public class WishListPage
    {
        protected IWebElement Label { get { return Application.Get().Search.ElementByCssSelector(".col-sm-9 h2"); }}
        protected IWebElement ContinueButton { get { return Application.Get().Search.ElementByLinkText("Continue"); }}
        protected IWebElement Table { get { return Application.Get().Search.ElementByXPath("//div[@class='table-responsive']"); } }
        protected IWebElement TableRow { get { System.Threading.Thread.Sleep(150); return Application.Get().Search.ElementByXPath("//div[@class='table-responsive']//tbody"); } }
        protected WishListTableItem product { get { System.Threading.Thread.Sleep(150); return GetProductElement(GetTableRow()); } }
        protected IWebElement SuccessMessage { get { return Application.Get().Search.ElementByCssSelector(".alert.alert-success"); } }

        #region Initialization
        public WishListTableItem GetProductElement(IWebElement element)
        {
            return new WishListTableItem(element);
        }
        public IWebElement GetTableRow()
        {
            return this.TableRow;
        }
        #endregion

        #region Atomic Operations
        public IWebElement GetTable()
        {
            return this.Table;
        }
        
        public WishListTableItem GetProduct()
        {
            return this.product;
        }
        public bool SuccessMessageIsDisplayed()
        {
            return SuccessMessage.Displayed;
        }
        public string GetLabel()
        {
            return this.Label.Text;
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        #endregion
        #region Business Logic
        public bool IsEmpty()
        {
            IWebElement element;
            try
            {
                element= Application.Get().Search.ElementByCssSelector("#content p");
            }
            catch(Exception)
            {
                return false;
            }

            if (element.Enabled)
            {
                return true;
            }
            else return false;
        }
        #endregion

    }
}