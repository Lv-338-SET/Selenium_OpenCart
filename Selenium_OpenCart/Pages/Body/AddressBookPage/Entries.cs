using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class Entries:AddressBook
    {
        
        protected List<IWebElement> Addresses
        {
            get { return this.Addresses; }
            set
            {
                if(value.Count>0)
                {
                    this.Addresses.AddRange(value);
                }
                else
                {
                    this.Addresses = null;
                    Console.WriteLine("Error! Table empty");//????
                }
            }
        }
        
        public Entries(IWebDriver driver) : base(driver)
        {
            Addresses = new List<IWebElement>(driver.FindElements(By.CssSelector("#content tr")));
        }

        public List<IWebElement> GetAdresses()
        {
            return Addresses;
        }

    }
}
