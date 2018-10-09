using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddressFormComponent
    {
        private IWebDriver driver;

        //Searching elements in the form 
        #region
        private IWebElement AddressFormTag
            { get {return driver.FindElement(By.CssSelector("form[action*='account/address']"));} }
        public IWebElement FirstNameInput
            { get { return driver.FindElement(By.Name("firstname")); } }
        public IWebElement LastNameInput
            { get {return driver.FindElement(By.Name("lastname")); } }
        public IWebElement CompanyInput
            { get { return driver.FindElement(By.Name("company")); } }
        public IWebElement Address1Input
            { get { return driver.FindElement(By.Name("address_1")); } }
        public IWebElement Address2Input
            { get { return driver.FindElement(By.Name("address_2")); } }
        public IWebElement CityInput
            { get { return driver.FindElement(By.Name("city")); } }
        public IWebElement PostCodeInput
            { get { return driver.FindElement(By.Name("postcode")); } }
        public IWebElement CountryInput
            { get { return driver.FindElement(By.Name("country_id")); } }
        public IWebElement RegionStateInput
            { get { return driver.FindElement(By.Name("zone_id")); } }
        public IWebElement DefaultAddressYesInputRadio
        { get { return driver.FindElement(By.CssSelector("input[name='default'][value='1']")); } }
        public IWebElement DefaultAddressNoInputRadio
        { get { return driver.FindElement(By.CssSelector("input[name='default'][value='0']")); } }
        
        #endregion

        public AddressFormComponent(IWebDriver driver)
        {
            this.driver = driver;

            if (!AddressFormTag.Enabled)
            {
                throw new AddressBookException("The 'Address' form cannot be found");
            }            
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
        public string GetDefaultAddressYesInputRadio()
        {
            return DefaultAddressYesInputRadio.Text;
        }

        public AddressFormComponent ClickDefaultAddressYesInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool isCheckedDefaultAddressYesInputRadio()
        {
            return DefaultAddressYesInputRadio.Selected;

        }
        #endregion

        //DefaultAddressNoInputRadio methods
        #region
        public string GetDefaultAddressNoInputRadio()
        {
           return DefaultAddressNoInputRadio.Text;
        }

        public AddressFormComponent ClickDefaultAddressNoInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool isCheckedDefaultAddressNoInputRadio()
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
