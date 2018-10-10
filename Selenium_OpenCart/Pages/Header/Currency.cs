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
        { get { return search.ElementByXPath("//*[@name='EUR']"); } }
        public IWebElement PoundSterling
        { get { return search.ElementByXPath("//*[@name='GBP']"); } }
        public IWebElement USDolar 
        { get { return search.ElementByXPath("//*[@name='USD']"); } }

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
    }
}
