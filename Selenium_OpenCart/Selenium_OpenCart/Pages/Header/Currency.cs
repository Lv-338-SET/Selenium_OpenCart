using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Header
{
    public class Currency
    {
        private ISearch search;

        public IWebElement Euro
        { get { return search.ElementByXPath("//li/button[@name='EUR']"); } }
        public IWebElement PoundSterling
        { get { return search.ElementByXPath("//li/button[@name='GBP']"); } }
        public IWebElement USDolar 
        { get { return search.ElementByXPath("//li/button[@name='GBP']"); } }
        public IWebElement CurrencyTextLabel
        { get { return search.ElementByXPath("//div[@class='btn-group']/button/strong"); } }

        public Currency()
        {
            search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }

        public void ClickButtonEuro()
        {
            Euro.Click();
        }

        public void ClickButtonPoundSterling()
        {
            PoundSterling.Click();
        }

        public void ClickButtonUSDolar()
        {
            USDolar.Click();
        }

        public string GetCurrencyFromMenu()
        {
            return CurrencyTextLabel.Text;
        }
    }
}
