using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    public abstract class AddressFormErrorMessages
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get(ApplicationSourceRepository.ChromeNew()).Search;
            }
        }
       
        public IWebElement FirstNameInputErrorMessage
        { get { return Search.ElementByCssSelector("input[name='lastname'] + div"); } }
        public IWebElement LastNameInputErrorMessage
        { get { return Search.ElementByCssSelector("input[name='lastname'] + div"); } }
        public IWebElement Address1InputErrorMessage
        { get { return Search.ElementByCssSelector("input[name='address_1'] + div"); } }
        public IWebElement CityInputErrorMessage
        { get { return Search.ElementByCssSelector("input[name='city'] + div"); } }
        public IWebElement CountryInputErrorMessage
        { get { return Search.ElementByCssSelector("select[name='country_id'] + div"); } }
        public IWebElement RegionStateInputErrorMessage
        { get { return Search.ElementByCssSelector("select[name='zone_id'] + div"); } }
                
        public bool IsFirstNameInputErrorMessage()
        {
            try
            {
                return FirstNameInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsLastNameInputErrorMessage()
        {
            try
            {
                return LastNameInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsAddress1InputErrorMessage()
        {
            try
            {               
                return Address1InputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsCityInputErrorMessage()
        {
            try
            {                
                return CityInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsCountryInputErrorMessage()
        {
            try
            {
                return CountryInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsRegionStateInputErrorMessage()
        {
            try
            {
                return RegionStateInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsAllInputErrorMessage()
        {
            try
            {
                return IsFirstNameInputErrorMessage() &&
                       IsLastNameInputErrorMessage() &&
                       IsAddress1InputErrorMessage() &&
                       IsCityInputErrorMessage() &&
                       IsCountryInputErrorMessage() &&
                       IsRegionStateInputErrorMessage();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsEmptyInputErrorMessage()
        {
            try
            {
                return FirstNameInputErrorMessage.Enabled &&
                       LastNameInputErrorMessage.Enabled &&
                       Address1InputErrorMessage.Enabled &&
                       CityInputErrorMessage.Enabled &&
                       RegionStateInputErrorMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
