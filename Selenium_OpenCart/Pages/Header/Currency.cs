using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Header
{
    public class Currency
    {
        protected ISearch search;

        private string CurrentCurrency{ get; set; }

        public IWebElement Euro
        { get { return search.ElementByName("EUR"); } }
        public IWebElement PoundSterling
        { get { return search.ElementByName("GBP"); } }
        public IWebElement USDolar 
        { get { return search.ElementByName("USD"); } }

        public Currency()
        {
            search = Application.Get().Search;
        }

        public void ClickButtonEuro()
        {
            CurrentCurrency = Euro.Text;
            Euro.Click();
        }

        public void ClickButtonPoundSterling()
        {
            CurrentCurrency = PoundSterling.Text;
            PoundSterling.Click();
        }

        public void ClickButtonUSDolar()
        {
            CurrentCurrency = USDolar.Text;
            USDolar.Click();
        }

        public string GetCurrencyFromMenu()
        {
            return CurrentCurrency[0].ToString();
        }
    }
}
