using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Header
{
    public class Header
    {
        #region Parameters
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        protected IWebElement searchTextBox
        { get { System.Threading.Thread.Sleep(50); return Search.ElementByXPath(".//div[@id='search']/input"); } }
        protected IWebElement searchButton
        { get { return Search.ElementByXPath(".//div[@id='search']/span"); } }
        protected IWebElement CartBox
        { get { return Search.ElementById("cart-total"); } }

        public Header()
        {
            Initialize();
        }
    #endregion

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
            return new SearchPage();
        }
        public CartBox ClickCartBox()
        {
            CartBox.Click();
            return new CartBox();
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
