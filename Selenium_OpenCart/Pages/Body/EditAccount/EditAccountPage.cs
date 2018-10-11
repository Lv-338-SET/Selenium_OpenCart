﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.MyAccount;

namespace Selenium_OpenCart.Pages.Body.EditAccount
{
    public class EditAccountPage
    {
        protected IWebDriver driver;
        public IWebElement EditFirstName
        {
            get
            {
                return driver.FindElement(By.Id("input-firstname"));
            }

        }
        public IWebElement EditLastName
        {
            get
            {
                return driver.FindElement(By.Id("input-firstname"));
            }
        }
        public IWebElement EditEmail
        {
            get
            {
                return driver.FindElement(By.Id("input-email"));
            }
        }
        public IWebElement EditTelephone
        {
            get
            {
                return driver.FindElement(By.Id("input-telephone"));
            }
        }
        public IWebElement EditFax
        {
            get
            {
                return driver.FindElement(By.Id("input-fax"));
            }
        }
        public IWebElement EditButtonContinue
        {
            get
            {
                return driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            }
        }
        public IWebElement EditButtonContinueHome
        {
            get
            {
                return driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            }
        }
        public EditAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClearEditFirstNane()
        {
            EditFirstName.Clear();
        }
        public void ClickrEditFirstNane()
        {
            EditFirstName.Clear();
        }
        public void InputEditFirstNane(string NewFirstName)
        {
            EditFirstName.SendKeys(NewFirstName);
        }
        public void ClickEditLastName()
        {
            EditLastName.Click();
        }
        public void ClearEditLastName()
        {
            EditLastName.Clear();
        }
        public void InputEdinFalstName(string NewLastName)
        {
            EditLastName.SendKeys(NewLastName);
        }
        public void ClickEditEmail()
        {
            EditEmail.Click();
        }
        public void ClrearEditEmail()
        {
            EditEmail.Clear();
        }
        public void InputEditEmail(string NewEmail)
        {
            EditEmail.SendKeys(NewEmail);
        }
        public void ClickEditFax()
        {
            EditFax.Click();
        }
        public void ClearEditFax()
        {
            EditFax.Clear();
        }
        public void InputEditFax(string NewFax)
        {
            EditFax.SendKeys(NewFax);
        }
       

        public void ClearClickInputEditFirstName(string NewFirstName)
        {
            EditFirstName.Clear();
            EditFirstName.Click();
            EditFirstName.SendKeys(NewFirstName);

        }
        public void ClearClickInputEditLastName(string NewLastName)
        {
            EditLastName.Clear();
            EditLastName.Click();
            EditLastName.SendKeys(NewLastName);
        }
        public void ClearClickInputEditEmail(string NewEmail)
        {
            EditEmail.Clear();
            EditEmail.Click();
            EditEmail.SendKeys(NewEmail);
        }
        public void ClearClickInputEditTelephone(string NewTelephone)
        {
            EditTelephone.Clear();
            EditTelephone.Click();
            EditTelephone.SendKeys(NewTelephone);
        }
        public void ClearClickInputEditFax(string NewFax)
        {
            EditFax.Clear();
            EditFax.Click();
            EditFax.SendKeys(NewFax);
        }

        public MyAccountPage ClickEditButtonContinue()
        {
            EditButtonContinue.Click();
            return new MyAccountPage(driver);
        }

        public void ClickEditButtonContinueHome()
        {
            EditButtonContinueHome.Click();
        }

        public static bool VerifyEditAccountPage(IWebDriver driver)
        {

            try
            {
                driver.FindElement(By.LinkText("Your Personal Details"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static EditAccountPage UserEditPage(IWebDriver driver)
        {
            if (VerifyEditAccountPage(driver))
            {
                return new EditAccountPage(driver);
            }
            else
            {
                return null;
            }
        }
    }
}

