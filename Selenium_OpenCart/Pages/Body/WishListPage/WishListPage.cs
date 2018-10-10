using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart;
using Selenium_OpenCart.Tools;


namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    public class WishListPage
    {
        protected IWebElement Label { get { return Application.Get().Search.ElementByCssSelector(".col-sm-9 h2"); }}
        protected IWebElement ContinueButton { get { return Application.Get().Search.ElementByLinkText("Continue"); }}
        
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
            IWebElement element;
            try
            {
                element= Application.Get().Search.ElementByCssSelector("#content p");
            }
            catch(Exception)
            {
                return false;
            }

            if (element.Enabled)
            {
                return true;
            }
            else return false;
        }
        
        }
    }