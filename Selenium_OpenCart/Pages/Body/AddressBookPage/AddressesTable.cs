using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddressesTable
    {
        public List<IWebElement> Rows
        {
            get { return this.Rows; }
            set
            {
                if (value.Count > 0)
                {
                    this.Rows.AddRange(value);
                }
                else
                {
                    this.Rows = null;
                    Console.WriteLine("Error! Table empty");//????
                }
            }
        }

        public AddressesTable(IWebDriver driver)
        {
            Rows = new List<IWebElement>(driver.FindElements(By.CssSelector("#content tr")));
        }
        
        /// <summary>
        /// Returns Address Table length
        /// </summary>
        /// <returns>IWebElement</returns>
        public int GetLength()
        {
            return Rows.Capacity;
        }
    }
}
