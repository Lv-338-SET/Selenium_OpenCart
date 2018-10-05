using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSite.Pages
{
    class WishListPage 
    {

        protected IWebElement Table { get; private set; }
        protected IWebElement ContinueButton { get; private set; }
        //protected List<WishListProduct> productList { get; private set; }
        protected IWebElement RemoveButton { get; private set; }
        protected IWebElement AddToCartButton { get; private set; }
        protected IWebElement Product { get; private set; }
        protected IWebElement ProductName { get; private set; }

        public WishListPage(IWebDriver driver) 
        { 
            this.Table = driver.FindElement(By.CssSelector(".table-responsive"));
            this.ContinueButton = driver.FindElement(By.LinkText("Continue"));
            this.ProductName = Table.FindElement(By.XPath("//td[@class='text-left']//a"));
            this.Product = ProductName.FindElement(By.XPath("//ancestor::tr"));
            this.RemoveButton = Product.FindElement(By.XPath("//button[@data-original-title='Add to Cart']"));
            this.AddToCartButton = Product.FindElement(By.XPath("//a[@data-original-title='Remove']"));
        }

        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }
        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }
        public string GetProductName(string product)
        {
            return ProductName.Text;
        }
        public IWebElement GetProduct(string product)
        {
            if (GetProductName(product).ToLower() == product.ToLower())
            {
                return Product;
            }
            else return null;
        }

        //public WishListProduct FindProductInWishList(string expectedProduct)
        //{
        //    foreach (var product in productList)
        //    {
        //        if (product.ProductExists(expectedProduct))
        //        {
        //            return product;
        //        }
        //        else continue;
        //    }
        //    return null;
        //}
        public void AddToCartFromWishListButtonClick(string product)
        {
            GetProduct(product).FindElement(By.XPath("//button[@data-original-title='Add to Cart']")).Click();
        }
        public void RemoveFromWishListClick(string product)
        {
            GetProduct(product).FindElement(By.XPath("//a[@data-original-title='Remove']")).Click();
        }
        public bool IsProductAdded(string product)
        {
            if (GetProduct(product) == null)
            {
                return false;
            }
            else return true;
        }
    }
    }

