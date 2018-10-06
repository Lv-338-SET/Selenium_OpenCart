using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartPageObject
{
    class Account
    {
        public Account(IWebDriver driver)
        {
            AddressBook book = new AddressBook(driver);
            
            book = new Entries(driver);

            Entries entries = new Entries(driver);
            entries.GetAdresses();
            


        }

    }
}
