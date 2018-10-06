using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartPageObject
{
    class EditAddress
    {
        private const string PAGE_NAME = "Edit Address";
        

        EditAddress(IWebDriver driver) : base(driver)
        {
            Tools.VerifyPageName(PageName, PAGE_NAME);
        }
    }
}
