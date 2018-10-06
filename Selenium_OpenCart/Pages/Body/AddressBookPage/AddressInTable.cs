using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartPageObject
{
    class AddressInTable:Entries
    {
        protected IWebElement EntriesTableShortAddress { get; private set; }
        protected IWebElement EntriesTableButtons { get; private set; }
        protected IWebElement EntriesTableEditButton { get; private set; }
        protected IWebElement EntriesTableDeleteButton { get; private set; }
    }
}
