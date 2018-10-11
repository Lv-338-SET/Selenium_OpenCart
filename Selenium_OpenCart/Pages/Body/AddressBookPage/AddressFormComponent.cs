using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{

    class AddressFormComponent:AddressFormErrorMessages
    {
        //private IWebDriver driver;
        protected ISearch Search
        {
            get
            {
                return Application.Get(ApplicationSourceRepository.ChromeNew()).Search;
            }
        }

        //Searching elements in the form 
        #region
        protected IWebElement AddressFormTag
            { get {return Search.ElementByCssSelector("#content form");} }
        public IWebElement FirstNameInput
            { get { return Search.ElementByName("firstname"); } }
        public IWebElement LastNameInput
            { get {return Search.ElementByName("lastname"); } }
        public IWebElement CompanyInput
            { get { return Search.ElementByName("company"); } }
        public IWebElement Address1Input
            { get { return Search.ElementByName("address_1"); } }
        public IWebElement Address2Input
            { get { return Search.ElementByName("address_2"); } }
        public IWebElement CityInput
            { get { return Search.ElementByName("city"); } }
        public IWebElement PostCodeInput
            { get { return Search.ElementByName("postcode"); } }
        public IWebElement CountryInput
            { get { return Search.ElementByName("country_id"); } }
        public IWebElement RegionStateInput
            { get { return Search.ElementByName("zone_id"); } }
        public IWebElement DefaultAddressYesInputRadio
            { get { return Search.ElementByCssSelector("input[name='default'][value='1']"); } }
        public IWebElement DefaultAddressNoInputRadio
            { get { return Search.ElementByCssSelector("input[name='default'][value='0']"); } }
        
        #endregion

        public AddressFormComponent()
        {
                                  
        }

        //FirstNameInput methods
        #region
        public string GetFirstNameInputText()
        {
            return FirstNameInput.Text;
        }

        public AddressFormComponent ClearFirstNameInput()
        {
            FirstNameInput.Clear();
            return this;
        }

        public AddressFormComponent ClickFirstNameInput()
        {
            FirstNameInput.Click();
            return this;
        }

        public AddressFormComponent TypeInFirstName(string text)
        {
            FirstNameInput.Click();
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(text);
            return this;
        }
        #endregion

        //LastNameInput methods
        #region
        public string GetLastNameInputText()
        {
            return LastNameInput.Text;
        }

        public AddressFormComponent ClearLastNameInput()
        {
            LastNameInput.Clear();
            return this;
        }

        public AddressFormComponent ClickLastNameInput()
        {
            LastNameInput.Click();
            return this;
        }

        public AddressFormComponent TypeInLastNameInput(string text)
        {
            LastNameInput.Click();
            LastNameInput.Clear();
            LastNameInput.SendKeys(text);
            return this;
        }
        #endregion

        //Address1Input methods
        #region
        public string GetAddress1InputText()
        {
            return Address1Input.Text;
        }

        public AddressFormComponent ClearAddress1Input()
        {
            Address1Input.Clear();
            return this;
        }

        public AddressFormComponent ClickAddress1Input()
        {
            Address1Input.Click();
            return this;
        }

        public AddressFormComponent TypeInAddress1Input(string text)
        {
            Address1Input.Click();
            Address1Input.Clear();
            Address1Input.SendKeys(text);
            return this;
        }
        #endregion

        //CityInput methods
        #region
        public string GetCityInputText()
        {
            return CityInput.Text;
        }

        public AddressFormComponent ClearCityInput()
        {
            CityInput.Clear();
            return this;
        }

        public AddressFormComponent ClickCityInput()
        {
            CityInput.Click();
            return this;
        }

        public AddressFormComponent TypeInCityInput(string text)
        {
            CityInput.Click();
            CityInput.Clear();
            CityInput.SendKeys(text);
            return this;
        }
        #endregion

        //PostCodeInput methods
        #region
        public string GetPostCodeInputText()
        {
            return PostCodeInput.Text;
        }

        public AddressFormComponent ClearPostCodeInput()
        {
            PostCodeInput.Clear();
            return this;
        }

        public AddressFormComponent ClickPostCodeInput()
        {
            PostCodeInput.Click();
            return this;
        }

        public AddressFormComponent TypeInPostCodeInput(string text)
        {
            PostCodeInput.Click();
            PostCodeInput.Clear();
            PostCodeInput.SendKeys(text);
            return this;
        }
        #endregion

        //CountryInput methods
        #region
        public string GetCountryInputText()
        {
            return CityInput.Text;
        }

        public AddressFormComponent ClickCountryInput()
        {
            CountryInput.Click();
            return this;
        }

        public AddressFormComponent ChooseCountry(string country)
        {
            SetAddressSelectElement(new SelectElement(CountryInput), country);
            return this;
        }
        #endregion

        //RegionStateInput methods
        #region
        public string GetRegionStateInputText()
        {
            return RegionStateInput.Text;
        }

        public AddressFormComponent ClickRegionStateInput()
        {
            RegionStateInput.Click();
            return this;
        }

        public AddressFormComponent ChooseRegionState(string region)
        {
            SetAddressSelectElement(new SelectElement(RegionStateInput), region);
            return this;
        }
        #endregion

        //DefaultAddressYesInputRadio methods
        #region
        public string GetDefaultAddressYesInputRadioText()
        {
            return DefaultAddressYesInputRadio.Text;
        }

        public AddressFormComponent ClickDefaultAddressYesInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool IsCheckedDefaultAddressYesInputRadio()
        {
            return DefaultAddressYesInputRadio.Selected;

        }
        #endregion

        //DefaultAddressNoInputRadio methods
        #region
        public string GetDefaultAddressNoInputRadioText()
        {
           return DefaultAddressNoInputRadio.Text;
        }

        public AddressFormComponent ClickDefaultAddressNoInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool IsCheckedDefaultAddressNoInputRadio()
        {
           return DefaultAddressNoInputRadio.Selected;
        }
        #endregion
                
        //Tools
        #region
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
            catch (NoSuchElementException)
            {
                select.SelectByText(defaultValue);
                Console.WriteLine("Error!Cannot find \"{0}\"!", value);
            }
        }
        #endregion        
    }
}
