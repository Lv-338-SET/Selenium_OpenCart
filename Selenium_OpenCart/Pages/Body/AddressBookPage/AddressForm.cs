using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    public abstract class AddressForm
    {
        private IWebDriver driver;
        private IWebElement AddressFormTag
            { get {return driver.FindElement(By.CssSelector("form[action*='account/address']"));} }
        protected IWebElement FirstNameInput
            { get { return driver.FindElement(By.Name("firstname")); } }
        protected IWebElement LastNameInput
            { get {return driver.FindElement(By.Name("lastname")); } }
        protected IWebElement CompanyInput
            { get { return driver.FindElement(By.Name("company")); } }
        protected IWebElement Address1Input
            { get { return driver.FindElement(By.Name("address_1")); } }
        protected IWebElement Address2Input
            { get { return driver.FindElement(By.Name("address_2")); } }
        protected IWebElement CityInput
            { get { return driver.FindElement(By.Name("city")); } }
        protected IWebElement PostCodeInput
            { get { return driver.FindElement(By.Name("postcode")); ; } }
        protected IWebElement CountryInput
            { get { return driver.FindElement(By.Name("country_id")); } }
        protected IWebElement RegionStateInput
            { get { return driver.FindElement(By.Name("zone_id")); } }
        protected IWebElement DefaultAddressYesInput
            { get { return driver.FindElement(By.CssSelector("input[name='default'][value='1']")); } }
        protected IWebElement DefaultAddressNoInput
            { get { return driver.FindElement(By.CssSelector("input[name='default'][value='0']")); } }
          
        public AddressForm(IWebDriver driver)
        {
            this.driver = driver;
           
            //if(AddressFormTag.Enabled);
            
        }
        
      //  //FirstNameInput methods
      //  #region
      //  public string GetFirstNameInputText()
      //  {
      //      return FirstNameInput.Text;
      //  }

      //  public AddressForm ClearFirstNameInput()
      //  {
      //      FirstNameInput.Clear();
      //      return this;
      //  }

      //  public AddressForm ClickFirstNameInput()
      //  {
      //      FirstNameInput.Click();
      //      return this;
      //  }

      //  public AddressForm TypeInFirstName(string text)
      //  {
      //      LastNameInput.SendKeys(text);
      //      return this;
      //  }
      //  #endregion

      //  //LastNameInput methods
      //  #region
      //  public string GetLastNameInputText()
      //  {
      //      return LastNameInput.Text;
      //  }

      //  public AddressForm ClearLastNameInput()
      //  {
      //      LastNameInput.Clear();
      //      return this;
      //  }

      //  public AddressForm ClickLastNameInput()
      //  {
      //      LastNameInput.Click();
      //      return this;
      //  }

      //  public AddressForm TypeInLastNameInput(string text)
      //  {
      //      LastNameInput.SendKeys(text);
      //      return this;
      //  }
      //  #endregion

      //  //Address1Input methods
      //  #region
      //  public string GetAddress1InputText()
      //  {
      //      return Address1Input.Text;
      //  }

      //  public AddressForm ClearAddress1Input()
      //  {
      //      Address1Input.Clear();
      //      return this;
      //  }

      //  public AddressForm ClickAddress1Input()
      //  {
      //      Address1Input.Click();
      //      return this;
      //  }

      //  public AddressForm TypeInAddress1Input(string text)
      //  {
      //      Address1Input.SendKeys(text);
      //      return this;
      //  }
      //  #endregion

      //  //CityInput methods
      //  #region
      //  public string GetCityInputText()
      //  {
      //      return CityInput.Text;
      //  }

      //  public AddressForm ClearCityInput()
      //  {
      //      CityInput.Clear();
      //      return this;
      //  }

      //  public AddressForm ClickCityInput()
      //  {
      //      CityInput.Click();
      //      return this;
      //  }

      //  public AddressForm TypeInCityInput(string text)
      //  {
      //      CityInput.SendKeys(text);
      //      return this;
      //  }
      //  #endregion

      //  //CountryInput methods
      //  #region
      //  public string GetCountryInputText()
      //  {
      //      return CityInput.Text;
      //  }        

      //  public AddressForm ClickCountryInput()
      //  {
      //      CountryInput.Click();
      //      return this;
      //  }

      //  public AddressForm ChooseCountry(string country)
      //  {
      //      Tools.SetAddressSelectElement(new SelectElement(CountryInput), country);            
      //      return this;
      //  }
      //  #endregion

      //  //RegionStateInput methods
      //  #region
      //  public string GetRegionStateInputText()
      //  {
      //      return RegionStateInput.Text;
      //  }

      //  public AddressForm ClickRegionStateInput()
      //  {
      //      RegionStateInput.Click();
      //      return this;
      //  }

      //  public AddressForm ChooseRegionState(string region)
      //  {
      //      Tools.SetAddressSelectElement(new SelectElement(RegionStateInput), region);
      //      return this;
      //  }
      //  #endregion

      //  //DefaultAddressYesInputRadio methods
      //  #region
      //  public string GetDefaultAddressYesInputRadio()
      //  {
      //      return DefaultAddressYesInputRadio.Text;
      //  }

      //  public AddressForm ClickDefaultAddressYesInputRadio()
      //  {
      //      DefaultAddressYesInputRadio.Click();
      //      return this;
      //  }

      //  public bool isCheckedDefaultAddressYesInputRadio()
      //  {
      //      return DefaultAddressYesInputRadio.Selected;
            
      //  }
      //  #endregion

      //  //DefaultAddressNoputRadio methods
      //  #region
      ////  public string GetDefaultAddressNoInputRadio()
      //  {
      //     // return DefaultAddressNoInputRadio.Text;
      //  }

      //  public AddressForm ClickDefaultAddressNoInputRadio()
      //  {
      //     // DefaultAddressYesInputRadio.Click();
      //      return this;
      //  }

      // // public bool isCheckedDefaultAddressNoInputRadio()
      //  {
      //     // return DefaultAddressNoInputRadio.Selected;

      //  }
      //  #endregion

    }
}
