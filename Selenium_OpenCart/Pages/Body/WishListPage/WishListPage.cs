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
    public class WishListPage : Header.Header
    {
        protected IWebElement Label { get { return driver.FindElement(By.CssSelector(".col-sm-9 h2")); }}
        protected IWebElement ContinueButton { get { return driver.FindElement(By.LinkText("Continue")); }}
        
        

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
        public bool IsEmpty()
        {
            if (driver.FindElement(By.CssSelector("#content p")).Enabled)
            {
                return true;
            }
            else return false;
        }
        public bool IsNotEmpty()
        {
            if (driver.FindElement(By.XPath("//div[@class='table-responsive']")).Enabled)
            {
                return true;
            }
            else return false;
        }
        }
    }