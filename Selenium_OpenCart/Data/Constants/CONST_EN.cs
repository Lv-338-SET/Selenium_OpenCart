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
        public const string LEMM_SELENIUM_HUB_URL = "http://23.97.238.112:4444/wd/hub";
        public const string OREST_SELENIUM_HUB_URL = "http://18.225.19.120:4444/wd/hub";
        public const string ANDRII_SELENIUM_HUB_URL = "http://35.204.216.209:4444/wd/hub";

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

        //Product Comparison constants
        #region 
        public const string PHONE = "iPhone";
        public const string SUCCESSFUL_COMPARISON_MESSAGE = "Success: You have added iPhone to your product comparison!\r\n×";
        public const string DESKTOP = "Mac";
        public const string DESKTOP_FIRST = "MacBook";
        public const string DESKTOP_SECOND = "MacBook Air";
        public const string EMPTY_TABLE_COMPARISON_MESSAGE = "Your shopping cart is empty!";
        public const string EDIT_TABLE_COMPARISON_MESSAGE = "Success: You have modified your product comparison!\r\n×"; 
        #endregion

    }
}
