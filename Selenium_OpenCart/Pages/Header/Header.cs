using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Pages.Header
{
    public class Header
    {
        protected IWebDriver driver;

        protected IWebElement searchTextBox
        { get { return driver.FindElement(By.XPath(".//div[@id='search']/input")); } }
        protected IWebElement searchButton
        { get { return driver.FindElement(By.XPath(".//div[@id='search']/span")); } }
        protected IWebElement CartBox
        { get { return driver.FindElement(By.Id("cart-total")); } }

        public Header(IWebDriver driver)
        {
            this.driver = driver;
            Initialize();
        }
        #region Initialization

        private void Initialize()
        {
            IWebElement element = this.searchTextBox;
            element = this.searchButton;
            element = this.CartBox;
        }

        #endregion

        #region AtomicOperation
        //TextBox
        public Header ClearSearchTextBox()
        {
            searchTextBox.Clear();
            return this;
        }
        public Header ClickSearchTextBox()
        {
            searchTextBox.Click();
            return this;
        }
        public Header SetTextInSearchTextBox(string text)
        {
            searchTextBox.SendKeys(text);
            return this;
        }
        public string GetTextFromSearchTextBox()
        {
            return this.searchTextBox.Text;
        }

        //Button
        public SearchPage ClickSearchButton()
        {
            this.searchButton.Click();
            return new SearchPage(driver);
        }
        public CartBox ClickCartBox()
        {
            CartBox.Click();
            return new CartBox(driver);
        }
        public string CartPriceSum()
        {
            return CartBox.Text;
        }

        #endregion

        #region BusinessLogic

        #endregion
    }
}
