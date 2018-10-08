using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.CartPage
{
    public class ShopingCardPage : Header.Header
    {
        protected IWebElement Table { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']")); } }
        public ShopingCardPage(IWebDriver driver) : base(driver)
        { }
        
    }

    
}