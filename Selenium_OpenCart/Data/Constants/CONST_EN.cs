using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Constants
{
    public static class CONST_EN
    {
        //WebDriver constantr
        public const string SELENIUM_HUB_URL = "http://35.195.16.18:4444/wd/hub";
        public const string TEST_SITE_URL = "http://40.118.125.245/";

        //Test constants
        #region
        public const int TEST_IMPLISIT_WAIT = 5;
        public const int TEST_NO_IMPLISIT_WAIT = 0;
        public const int TEST_EXPLISIT_WAIT = 1;
        #endregion
        
       
        //Address Page constants
        #region
        public const string ADDRESS_PAGE_NAME = "Address Book Entries";
        public const string ADDRESS_PAGE_NEW_ADDRESS_BUTTON_TEXT = "New Address";
        public const string ADDRESS_PAGE_NO_ADDRESSES_MESSAGE = "Your shopping cart is empty!";
        public const string ADDRESS_PAGE_EDIT_BUTTON_TEXT = "Edit";
        public const string ADDRESS_PAGE_DELETE_BUTTON_TEXT = "Delete";
        public const string ADDRESS_EDIT_PAGE_NAME = "Edit Address";
        public const string ADDRESS_NEW_ADDRESS_PAGE_NAME = "Add Address";
        #endregion


    }
}
