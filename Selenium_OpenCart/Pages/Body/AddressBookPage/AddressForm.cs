using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartPageObject
{
    public sealed class AddressForm
    {
        //private IWebElement AddressFormTag { get; set; }
        //protected IWebElement FirstNameInput { get; private set; }//TODO required field
        //protected IWebElement LastNameInput { get; private set; }//TODO required field
        //protected IWebElement CompanyInput { get; private set; }
        //protected IWebElement Address1Input { get; private set; }//TODO required field
        //protected IWebElement Address2Input { get; private set; }
        //protected IWebElement CityInput { get; private set; }//TODO required field
        //protected IWebElement PostCodeInput { get; private set; }
        //protected IWebElement CountryInput { get; private set; }//TODO required field
        //protected IWebElement RegionStateInput { get; private set; }//TODO required field
        //protected IWebElement DefaultAddressYesInput { get; private set; }
        //protected IWebElement DefaultAddressNoInput { get; private set; }

        private IWebElement AddressFormTag;//TODO
        private IWebElement FirstNameInput;//Required field
        private IWebElement LastNameInput;//Required field
        private IWebElement CompanyInput;//TODO
        private IWebElement Address1Input;//Required field
        private IWebElement Address2Input;//TODO
        private IWebElement CityInput;//Required field
        private IWebElement PostCodeInput;//TODO
        private IWebElement CountryInput;//Required field
        private IWebElement RegionStateInput;//Required field
        private IWebElement DefaultAddressYesInputRadio;//TODO
        private IWebElement DefaultAddressNoInputRadio;//TODO

        public AddressForm(IWebDriver driver)
        {
            //AddressForm = driver.FindElement(By.CssSelector(".content form"));
            AddressFormTag = driver.FindElement(By.CssSelector("form[action*='account/address']"));

            FirstNameInput = AddressFormTag.FindElement(By.Name("firstname"));
            LastNameInput = AddressFormTag.FindElement(By.Name("lastname"));
            CompanyInput = AddressFormTag.FindElement(By.Name("company"));
            Address1Input = AddressFormTag.FindElement(By.Name("address_1"));
            Address2Input = AddressFormTag.FindElement(By.Name("address_2"));
            CityInput = AddressFormTag.FindElement(By.Name("city"));
            PostCodeInput = AddressFormTag.FindElement(By.Name("postcode"));
            CountryInput = AddressFormTag.FindElement(By.Name("country_id"));
            RegionStateInput = AddressFormTag.FindElement(By.Name("zone_id"));
            DefaultAddressYesInputRadio = AddressFormTag.FindElement(By.CssSelector("input[name='default'][value='1']"));
            DefaultAddressNoInputRadio = AddressFormTag.FindElement(By.CssSelector("input[name='default'][value='1']"));           
        }

        //FirstNameInput methods
        #region
        public string GetFirstNameInputText()
        {
            return FirstNameInput.Text;
        }

        public AddressForm ClearFirstNameInput()
        {
            FirstNameInput.Clear();
            return this;
        }

        public AddressForm ClickFirstNameInput()
        {
            FirstNameInput.Click();
            return this;
        }

        public AddressForm TypeInFirstName(string text)
        {
            LastNameInput.SendKeys(text);
            return this;
        }
        #endregion

        //LastNameInput methods
        #region
        public string GetLastNameInputText()
        {
            return LastNameInput.Text;
        }

        public AddressForm ClearLastNameInput()
        {
            LastNameInput.Clear();
            return this;
        }

        public AddressForm ClickLastNameInput()
        {
            LastNameInput.Click();
            return this;
        }

        public AddressForm TypeInLastNameInput(string text)
        {
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

        public AddressForm ClearAddress1Input()
        {
            Address1Input.Clear();
            return this;
        }

        public AddressForm ClickAddress1Input()
        {
            Address1Input.Click();
            return this;
        }

        public AddressForm TypeInAddress1Input(string text)
        {
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

        public AddressForm ClearCityInput()
        {
            CityInput.Clear();
            return this;
        }

        public AddressForm ClickCityInput()
        {
            CityInput.Click();
            return this;
        }

        public AddressForm TypeInCityInput(string text)
        {
            CityInput.SendKeys(text);
            return this;
        }
        #endregion

        //CountryInput methods
        #region
        public string GetCountryInputText()
        {
            return CityInput.Text;
        }        

        public AddressForm ClickCountryInput()
        {
            CountryInput.Click();
            return this;
        }

        public AddressForm ChooseCountry(string country)
        {
            Tools.SetAddressSelectElement(new SelectElement(CountryInput), country);            
            return this;
        }
        #endregion

        //RegionStateInput methods
        #region
        public string GetRegionStateInputText()
        {
            return RegionStateInput.Text;
        }

        public AddressForm ClickRegionStateInput()
        {
            RegionStateInput.Click();
            return this;
        }

        public AddressForm ChooseRegionState(string region)
        {
            Tools.SetAddressSelectElement(new SelectElement(RegionStateInput), region);
            return this;
        }
        #endregion

        //DefaultAddressYesInputRadio methods
        #region
        public string GetDefaultAddressYesInputRadio()
        {
            return DefaultAddressYesInputRadio.Text;
        }

        public AddressForm ClickDefaultAddressYesInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool isCheckedDefaultAddressYesInputRadio()
        {
            return DefaultAddressYesInputRadio.Selected;
            
        }
        #endregion

        //DefaultAddressNoputRadio methods
        #region
        public string GetDefaultAddressNoInputRadio()
        {
            return DefaultAddressNoInputRadio.Text;
        }

        public AddressForm ClickDefaultAddressNoInputRadio()
        {
            DefaultAddressYesInputRadio.Click();
            return this;
        }

        public bool isCheckedDefaultAddressNoInputRadio()
        {
            return DefaultAddressNoInputRadio.Selected;

        }
        #endregion

    }
}
