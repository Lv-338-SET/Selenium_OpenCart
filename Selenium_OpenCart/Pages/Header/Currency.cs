using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Header
{
    public class Currency
    {
        private IWebDriver driver;

        public IWebElement Euro
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Register']"));
            }
        }
        public IWebElement PoundSterling
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Register']"));
            }
        }
        public IWebElement USDolar
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='Register']"));
            }
        }

        public Currency(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
