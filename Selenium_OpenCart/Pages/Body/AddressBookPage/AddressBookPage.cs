using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MyAccountPage;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
	      
{
    class AddressBookPage
    {
        IWebDriver driver;

        IJavaScriptExecutor js;
        private const string NEW_ADDRESS_BUTTON_TEXT = "New Address";
        private const string PAGE_NAME = "Address Book Entries";
        private const string NO_ADDRESSES_MESSAGE = "Your shopping cart is empty!";
        
        public IWebElement PageName { get; private set; }
        public IWebElement BackButton
            { get {return driver.FindElement(By.CssSelector("form[action*='account/address']"));} }
        public List<AddressComponent> AddressesTable
        {
            get
            {
                List<AddressComponent> addresses = new List<AddressComponent>();
                foreach (IWebElement address in driver.FindElements(By.CssSelector("#content tr")))
                {
                    addresses.Add(new AddressComponent(address));
                }
                return addresses;
            } 
        }

        public AddressComponent Address { get; private set; }        
        public IWebElement NewAddressButton
            { get { return driver.FindElement(By.LinkText(NEW_ADDRESS_BUTTON_TEXT));} }
        public bool IsNoAddressMessage 
            { get { return driver.FindElement(By.XPath("//p[ . = '"+ NO_ADDRESSES_MESSAGE +"']")).Enabled;} }
        public bool IsTable
            { get { return driver.FindElement(By.CssSelector("#content table")).Enabled;} }

        public AddressBookPage(IWebDriver driver)
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
            return AddressesTable.Count;
        }

        /// <summary>
        /// Returns first row from Address Table
        /// </summary>
        /// <returns>Address</returns>
        public AddressComponent GetFirstAddress()
        { 
            return AddressesTable[0]; ;
        }
        
        /// <summary>
        /// Returns last row from Address Table
        /// </summary>
        /// <returns>Address</returns>
        public AddressComponent GetLastAddress()
        {            
            return AddressesTable[AddressesTable.Count];
        }

        /// <summary>
        /// Returns row from Address Table by short address
        /// </summary>
        /// <returns>Address</returns>
        public AddressComponent GetAddressByShortAddress(string text)
        {
            return AddressesTable.Find(row => row.LeftCell.Text.Contains(text));
        }

        /// <summary>
        /// Returns row index from Address Table by short address
        /// </summary>
        /// <returns>int</returns>
        public int GetAddressIndexByShortAddress(string text)
        {   
            return AddressesTable.IndexOf(GetAddressByShortAddress(text));
        }

        /// <summary>
        /// Verifies if address is in adress table
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAddressInTableByShortAddress(string text)
        {
            Console.WriteLine(AddressesTable.Count);
            if (AddressesTable.Count > 0)
            {                 
                foreach (AddressComponent row in AddressesTable)
                {                   
                    if (row.LeftCell.Text.Contains(text)) return true;
                }
            }
            return false;            
        }

        /// <summary>
        /// Returning to My Account Page
        /// </summary>
        /// <returns>MyAccountPage.MyAccountPage</returns>
        public MyAccountPage.MyAccountPage ClickToBackButton ()
        {
            BackButton.Click();
            return new MyAccountPage.MyAccountPage(driver);
        }

        /// <summary>
        /// Redirects to "add new Address" page  
        /// </summary>
        /// <returns>AddNewAddressPage</returns>
        public AddNewAddressPage getNewAddress()
        {
            js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down

            NewAddressButton.Click();
            return new AddNewAddressPage(driver);
        }
        /// <summary>
        /// Redirects to "edit Address" page, by the Address 
        /// </summary>
        /// <returns>EditAddressPage</returns>
        public EditAddressPage EditAddress(string shortAddress)
        {
            js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down
            GetAddressByShortAddress(shortAddress).EditButton.Click();
            return new EditAddressPage(driver);
        }
    }
}
