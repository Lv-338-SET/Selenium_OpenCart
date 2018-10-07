using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;


namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    class WishListPage : Header.Header
    {
        protected IWebElement Label { get { return driver.FindElement(By.CssSelector(".col - sm - 9 h2}; private set;")); }}
        protected IWebElement ContinueButton { get { return driver.FindElement(By.LinkText("Continue")); } }
        

        public WishListPage(IWebDriver driver) : base(driver)
        {

        }
        
        public string GetLabel()
        {
            return this.Label.Text;
        }
       

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }
        

    }
}