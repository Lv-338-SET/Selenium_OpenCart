using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MyAccount;
using Selenium_OpenCart.Data.Constants;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
	      
{
    public class AddressBookPage
    {
        //IWebDriver driver;
        protected ISearch Search
        {
            get
            {
                return Application.Get(ApplicationSourceRepository.ChromeNew()).Search;
            }
        }

        IJavaScriptExecutor js;        

        private const string NEW_ADDRESS_BUTTON_TEXT = "New Address"; //TODO
        private const string PAGE_NAME = "Address Book Entries"; //TODO
        private const string NO_ADDRESSES_MESSAGE = "Your shopping cart is empty!"; //TODO

        public IWebElement PageName { get; private set; }
        public IWebElement BackButton
            { get {return Search.ElementByCssSelector("form[action*='account/address']");} } //TODO
        public List<AddressComponent> AddressesTable
        {
            get
            {
                List<AddressComponent> addresses = new List<AddressComponent>();
                foreach (IWebElement address in Search.ElementsByCssSelector("#content tr"))
                {
                    addresses.Add(new AddressComponent(address));
                }
                return addresses;
            } 
        }

        public AddressComponent Address { get; private set; }        
        public IWebElement NewAddressButton
            { get { return Search.ElementByLinkText(NEW_ADDRESS_BUTTON_TEXT);} }
        public bool IsNoAddressMessage 
            { get { return Search.ElementByXPath("//p[ . = '"+ NO_ADDRESSES_MESSAGE +"']").Enabled;} }
        public bool IsTable
            { get { return Search.ElementByCssSelector("#content table").Enabled;} }

        public AddressBookPage()
        {            
            PageName = Search.ElementByCssSelector("#content h2");                   
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
<<<<<<< HEAD
=======

>>>>>>> develop
        public MyAccountPage ClickToBackButton ()
        {
            BackButton.Click();
            return new MyAccountPage(Application.Get().Browser.Driver);
        }
<<<<<<< HEAD

=======
>>>>>>> develop

        /// <summary>
        /// Redirects to "add new Address" page  
        /// </summary>
        /// <returns>AddNewAddressPage</returns>
        public AddNewAddressPage GoToNewAddressPage()
        {
            js = Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.Driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down

            NewAddressButton.Click();
            return new AddNewAddressPage();
        }
        /// <summary>
        /// Redirects to "edit Address" page, by the Address 
        /// </summary>
        /// <returns>EditAddressPage</returns>
        public EditAddressPage EditAddress(string shortAddress)
        {
            js = Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.Driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down
            GetAddressByShortAddress(shortAddress).EditButton.Click();
            return new EditAddressPage();
        }
    }
}
