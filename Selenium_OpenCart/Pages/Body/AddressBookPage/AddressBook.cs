using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MyAccountPage;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
	      
{
    class AddressBook
    {
        IWebDriver driver;
        private const string NEW_ADDRESS_BUTTON_TEXT = "New Address";
        private const string PAGE_NAME = "Address Book Entries";
        private const string NO_ADDRESSES_MESSAGE = "Your shopping cart is empty!";

        public IWebElement PageName { get; private set; }
        public IWebElement BackButton
            { get {return driver.FindElement(By.CssSelector("form[action*='account/address']"));} }
        protected AddressesTable AddressesTable
            { get; private set; }
        public IWebElement NewAddressButton
            { get { return driver.FindElement(By.LinkText(NEW_ADDRESS_BUTTON_TEXT));} }
        public bool IsNoAddressMessage 
            { get { return driver.FindElement(By.XPath("//p[ . = '"+ NO_ADDRESSES_MESSAGE +"']")).Enabled;} }
        public bool IsTable
            { get { return driver.FindElement(By.CssSelector("#content ~ table")).Enabled;} }

        public AddressBook(IWebDriver driver)
        {
            this.driver = driver;

            PageName = driver.FindElement(By.CssSelector("#content h2"));

            if (!PageName.Text.Contains(PAGE_NAME))
            {
                throw new AddressBookException("The 'Address Book' page cannot be found");
            }         
        }
                
        /// <summary>
        /// Addresses table lenght
        /// </summary>
        /// <returns>IWebElement</returns>
        public int GetAddressesTableLength()
        {
            AddressesTable = new AddressesTable(driver);
            return AddressesTable.GetLength();
        }

        /// <summary>
        /// Returns first row from Address Table
        /// </summary>
        /// <returns>Address</returns>
        public Address GetFirstAddress()
        {
            AddressesTable = new AddressesTable(driver);            
            return new Address(AddressesTable.Rows[0]);
        }
        
        /// <summary>
        /// Returns last row from Address Table
        /// </summary>
        /// <returns>Address</returns>
        public Address GetLastAddress()
        {
            AddressesTable = new AddressesTable(driver);
            return new Address(AddressesTable.Rows[AddressesTable.GetLength()]);
        }

        /// <summary>
        /// Returns row from Address Table by short address
        /// </summary>
        /// <returns>Address</returns>
        public Address GetAddressByShortAddress(string text)
        {
            AddressesTable = new AddressesTable(driver);
            return new Address(AddressesTable.Rows.Find(row => row.Text.Contains(text)));
        }

        /// <summary>
        /// Returns row index from Address Table by short address
        /// </summary>
        /// <returns>int</returns>
        public int GetAddressIndexByShortAddress(string text)
        {
            AddressesTable = new AddressesTable(driver);
            IWebElement findAdress = AddressesTable.Rows.Find(row => row.Text.Contains(text));
            return AddressesTable.Rows.IndexOf(findAdress);
        }

        /// <summary>
        /// Verifies if address is in adress table
        /// </summary>
        /// <returns>bool</returns>
        public bool isAddressInTable(string text)
        {
            AddressesTable = new AddressesTable(driver);
            if (AddressesTable.Rows.Capacity > 0)
            {                 
                foreach (IWebElement row in AddressesTable.Rows)
                {
                    if (new Address(row).RightCell.Text == text) return true;
                }
            }
            return false;            
        }

        /// <summary>
        /// Returning to My Account Page
        /// </summary>
        /// <returns>MyAccountPage.MyAccountPage</returns>
        public MyAccountPage.MyAccountPage ClickToBackButton (IWebDriver driver)
        {
            BackButton.Click();
            return new MyAccountPage.MyAccountPage(driver);
        }
    }
}
