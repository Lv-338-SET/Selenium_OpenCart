using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    public class ShopingCartTableItem
    {
        protected IWebElement Image { get; private set; }
        protected IWebElement ProductName { get; private set; }
        protected IWebElement Model { get; private set; }
        protected IWebElement CountsTextBox { get; private set; }
        protected IWebElement UpdateButton { get; private set; }
        protected IWebElement RemoveButton { get; private set; }
        protected IWebElement UnitPrice { get; private set; }

        public ShopingCartTableItem(IWebDriver driver, IWebElement element)
        {
            Image = element.FindElement(By.XPath("//tr/td[@class='text-center']//img"));
            ProductName = element.FindElement(By.CssSelector(".text-left >a"));
            Model = element.FindElement(By.XPath("//td[@class='text-left' and string-length(text()) > 0]"));
            CountsTextBox = element.FindElement(By.XPath("td[@class='input-group btn-block']"));
            UpdateButton = element.FindElement(By.XPath("//td[@class='btn btn-primary'"));
            RemoveButton = element.FindElement(By.XPath("//td[@class='btn btn-danger'"));
            UnitPrice = element.FindElement(By.XPath("//div[@class='price']"));
        }

        //Image
        public void ImageClick()
        {
            Image.Click();
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


        public bool ProductNameIsTheSame(string product)
        {
            return product.ToLower() == GetProductName().ToLower();

        }
    }
}
