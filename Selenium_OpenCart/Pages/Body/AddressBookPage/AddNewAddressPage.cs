using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddNewAddressPage
    {
        private IWebDriver driver;
        IJavaScriptExecutor js;

        private const string PAGE_NAME = "Add Address";

        public IWebElement PageName { get; private set; }
        public AddressFormComponent AddressForm { get; private set; }
        public IWebElement ContinueButton
        { get { return driver.FindElement(By.CssSelector("input[type ='submit']")); } }

        public AddNewAddressPage(IWebDriver driver)
        {
            this.driver = driver;

            PageName = driver.FindElement(By.CssSelector("#content h2"));

            AddressForm = new AddressFormComponent(driver);
        }


        public AddNewAddressPage FillAllRequareField(string firstName, string lastName, string Address1,
                string city, string postCode, string country, string regionState)
        {
            js = driver as IJavaScriptExecutor;

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
            return new AddressBookPage(driver);
        }
    }
}
