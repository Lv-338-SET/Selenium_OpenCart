using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddNewAddressPage:AddressForm
    {
        private IWebDriver driver;

        private const string PAGE_NAME = "Add Address";

        protected IWebElement PageName { get; private set; }

        public AddNewAddressPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

            PageName = driver.FindElement(By.CssSelector("#content + h2"));

            if (PageName.Text.Contains(PAGE_NAME))
            {
                throw new AddressBookException("The 'Add Address' page cannot be found");
            }

        }
    }
}
