using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Body.MainPage
{
    public class ProductItemFromHomePage
    {
        protected IWebElement productBox { get; private set; }
        protected IWebElement productImage { get; private set; }
        protected IWebElement productName { get; private set; }
        protected IWebElement productDescription { get; private set; }
        protected IWebElement productPrice { get; private set; }
        protected IWebElement productExTax { get; private set; }
        protected IWebElement productIconCart { get; private set; }
        protected IWebElement productIconFavourite { get; private set; }
        protected IWebElement productIconCompare { get; private set; }


        private IWebDriver driver;

        public ProductItemFromHomePage(IWebDriver driver, IWebElement current)
        {
            this.driver = driver;


            this.productBox = current;
            this.productImage = current.FindElement(By.ClassName("image"));
            this.productName = current.FindElement(By.CssSelector(".caption>h4>a"));
            this.productDescription = current.FindElements(By.CssSelector(".caption p"))[0];
            this.productPrice = current.FindElement(By.CssSelector(".caption .price"));
            this.productExTax = current.FindElement(By.CssSelector(".caption .price .price-tax"));
            var listIcons = current.FindElements(By.CssSelector(".button-group>button"));
            this.productIconCart = listIcons[0];
            this.productIconFavourite = listIcons[1];
            this.productIconCompare = listIcons[2];

        }

        #region AtomicOperations
            
        //GetTextFromLabel
        public string GetTextFromProductName()
        {
            return this.productName.Text;
        }
        public string GetTextFromProductDescription()
        {
            return this.productDescription.Text;
        }
        public string GetTextFromProductPrice()
        {
            return this.productPrice.Text;
        }
        public string GetTextFromProductExTax()
        {
            return this.productExTax.Text;
        }

        //Buttons
        public HomePage ClickCartButton()
        {
            productIconCart.Click();
            return new HomePage(driver);
        }
        public HomePage ClickCartfavourite()
        {
            productIconFavourite.Click();
            return new HomePage(driver);
        }
        public HomePage ClickCompareButton()
        {
            productIconCompare.Click();
            return new HomePage(driver);
        }
        public bool IsAppropriate(string product)
        {
            return (product.ToLower() == GetTextFromProductName().ToLower());
        }

        #endregion
    }
}
