using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages
{
    class Header
    {
        protected IWebDriver driver;

        protected IWebElement searchTextBox
            { get { return driver.FindElement(By.XPath(".//div[@id='search']/input")); } }
        protected IWebElement searchButton
            { get { return driver.FindElement(By.XPath(".//div[@id='search']/span")); } }

        public Header(IWebDriver driver) {
            this.driver = driver;
            Initialize();
        }
        #region Initialization

        private void Initialize() {
            IWebElement element = this.searchTextBox;
            element = this.searchButton;
        }

        #endregion

        #region AtomicOperation
        //TextBox
        public Header ClearSearchTextBox() {
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
        #endregion

        #region BusinessLogic
        public SearchPage Search(string textSearch)
        {
            Header item = new Header(this.driver);
            item.ClickSearchTextBox();
            item.ClearSearchTextBox();
            item.SetTextInSearchTextBox(textSearch);
            SearchPage page = item.ClickSearchButton();

            return page;
        }
        #endregion
    }
}
