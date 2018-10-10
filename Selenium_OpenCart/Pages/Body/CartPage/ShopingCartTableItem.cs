using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Body.ProductPage;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    class ShopingCartTableItem
    {
        protected IWebDriver driver;
        public IWebElement Image { get; private set; }
        protected IWebElement ProductName { get; private set; }
        protected IWebElement Model { get; private set; }
        protected IWebElement CountsTextBox { get; private set; }
        protected IWebElement UpdateButton { get; private set; }
        protected IWebElement RemoveButton { get; private set; }
        protected IWebElement UnitPrice { get; private set; }
        protected IWebElement TotalPrice { get; private set; }

        public ShopingCartTableItem(IWebElement element)
        {
            Initialize(element);
        }

        private void Initialize(IWebElement element)
        {
            Image = element.FindElement(By.XPath("//td[1]"));
            ProductName = element.FindElement(By.CssSelector("tr > td:nth-child(2) > a"));
            Model = element.FindElement(By.XPath("//td[3]"));
            CountsTextBox = element.FindElement(By.XPath("//td[4]/div/input[@class='form-control']"));
            UpdateButton = element.FindElement(By.XPath("//td[4]/div//i[@class='fa fa-refresh']"));
            RemoveButton = element.FindElement(By.XPath("//td[4]/div//i[@class='fa fa-times-circle']"));
            UnitPrice = element.FindElement(By.XPath("//td[5]"));
            TotalPrice = element.FindElement(By.XPath("//td[6]"));
        }

        //Image
        public ProductPage.ProductPage ImageClick()
        {
            Image.Click();
            return new ProductPage.ProductPage(driver);
        }

        //ProductName
        public string GetProductName()
        {
            return this.ProductName.Text;
        }
        public void ClickProductName()
        {
            ProductName.Click();
        }

        //Model
        public string GetProductModel()
        {
            return this.Model.Text;
        }



        //CountsTextBox
        public string GetCountText()
        {
            return CountsTextBox.Text;
        }
        public void ClickCountsTextBox()
        {
            CountsTextBox.Click();
        }
        public void ClearCountsTextBox()
        {
            CountsTextBox.Clear();
        }
        public void SetCountsTextBox(string count)
        {
            CountsTextBox.SendKeys(count);
        }


        //UpdateButton
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        //RemoveButton
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }

        //UnitPrice
        public string GetProductPrice()
        {
            return this.UnitPrice.Text;
        }

        //TotalPrice
        public string GetProductTotalPrice()
        {
            return this.TotalPrice.Text;
        }


        public bool ProductNameIsTheSame(string product)
        {
            return product.ToLower() == GetProductName().ToLower();

        }
    }
}
