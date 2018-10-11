using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{

        public class AddNewAddressPage
        {        
          protected ISearch Search
          {
            get
            {
                return Application.Get(ApplicationSourceRepository.ChromeNew()).Search;
            }
        }
        
        IJavaScriptExecutor js;
        
        private const string PAGE_NAME = "Add Address";

        public IWebElement PageName { get; private set; }
        public AddressFormComponent AddressForm { get; private set; }
        public IWebElement ContinueButton
        { get { return Search.ElementByCssSelector("input[type ='submit']"); } } //TO DO

        public AddNewAddressPage()
        {
            PageName = Search.ElementByCssSelector("#content h2");
            AddressForm = new AddressFormComponent();
        }


        public AddNewAddressPage FillAllRequareField(string firstName, string lastName, string Address1,
                string city, string postCode, string country, string regionState)
        {
            js = Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.Driver as IJavaScriptExecutor;

            AddressForm.TypeInFirstName(firstName);
            AddressForm.TypeInLastNameInput(lastName);
            AddressForm.TypeInAddress1Input(Address1);

            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down

            AddressForm.TypeInCityInput(city);
            AddressForm.TypeInPostCodeInput(postCode);

            js.ExecuteScript("window.scrollBy(0,200)"); //Moving scrollbar down againe

            AddressForm.ChooseCountry(country);
            AddressForm.ChooseRegionState(regionState);
            return this;
        }
        public AddressBookPage Continue()
        {
            ContinueButton.Click();
            return new AddressBookPage();
        }
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

    }
}
