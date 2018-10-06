using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddressBook : Account
    {
        
        protected IWebElement BackButton { get; private set; }

        private IWebElement pageName;
        private List<IWebElement> pageMessages;
        private IWebElement newAddressButton;
        private bool isTable;        

        private const string PAGE_NAME = "Address Book Entries";
        private const string NO_ADDRESSES_MESSAGE = "You have no addresses in your account.";

        public AddressBook(IWebDriver driver) : base(driver)
        {
            pageName = driver.FindElement(By.CssSelector("#content + h2"));

            Tools.VerifyPageName(pageName, PAGE_NAME);

            pageMessages.AddRange(driver.FindElements(By.CssSelector("#content ~ p")));
            isTable = driver.FindElements(By.CssSelector("#content ~ table")).Count > 0;
        }

        /// <summary>
        /// Verifies if "no addresses" message visible
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAddressesMessage()
        {
            return Tools.isElementInList(pageMessages, NO_ADDRESSES_MESSAGE);
        }
        public Entries adresses = new Entries(this);
    }
}
