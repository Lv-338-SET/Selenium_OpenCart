using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    public abstract class Tools
    {
        /// <summary>
        /// Selects some value from slecet input in Address form        
        public static void SetAddressSelectElement(SelectElement select, string value)
        {
            try
            {
                select.SelectByText(value);
            }
            catch
            {
                select.SelectByText(" --- Please Select --- ");
                Console.WriteLine("Error!Cannot find \"{0}\"!", value);

            }            
        }

        public static void SetSelectElement(SelectElement select, string value, string defaultValue)
        {
            try
            {
                select.SelectByText(value);
            }
            catch(NoSuchElementException)
            {
                select.SelectByText(defaultValue);
                Console.WriteLine("Error!Cannot find \"{0}\"!", value);
            }
        }

        public static void VerifyPageName(IWebElement actual, string expected)
        {
            Assert.AreEqual(actual.Text, expected);            
        }

        public static bool isElementInList(List<IWebElement> elements, string text)
        {
            if (elements.Capacity > 0)
            {
                foreach(IWebElement element in elements)
                {
                    string trimElement = element.Text.Trim();
                    return trimElement.Contains(text);
                }
            }            
            return false;   
        }
    }
}
