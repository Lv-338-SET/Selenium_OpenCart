using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class Address
    {
        private IWebElement address;

        private const string EDIT_BUTTON_TEXT = "Edit";
        private const string DELETE_BUTTON_TEXT = "Delete";

        public IWebElement LeftCell
            { get { return address.FindElement(By.ClassName("text-left")); } }

        public IWebElement RightCell
            { get { return address.FindElement(By.ClassName("text-right")); } }

        public IWebElement EditButton
            { get { return RightCell.FindElement(By.LinkText(EDIT_BUTTON_TEXT)); } }

        public IWebElement DeleteButton
            { get { return RightCell.FindElement(By.LinkText(DELETE_BUTTON_TEXT)); } }

        public Address(IWebElement address)
        {
            this.address = address;
        }
    }
}
