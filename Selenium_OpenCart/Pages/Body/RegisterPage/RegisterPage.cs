﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestSite.Pages.RegisterPage
{
    class RegisterPage
    {
        protected IWebDriver driver;

        public IWebElement LebleRegister
        {
            get
            {
                return driver.FindElement(By.XPath("//div[contains(@id, 'content') and contains(//h1, 'Register Account')]"));
            }
        }

        public IWebElement FirstNameField
        {
            get
            {
                return driver.FindElement(By.Id("input-firstname"));
            }
        }
        public IWebElement LastNameField
        {
            get
            {
                return driver.FindElement(By.Id("input-lastname"));
            }
        }
        public IWebElement EMailField
        {
            get
            {
                return driver.FindElement(By.Id("input-email"));
            }
        }
        public IWebElement TelephoneField
        {
            get
            {
                return driver.FindElement(By.Id("input-telephone"));
            }
        }
        public IWebElement FaxField
        {
            get
            {
                return driver.FindElement(By.Id("input-fax"));
            }
        }
        public IWebElement CompanyField
        {
            get
            {
                return driver.FindElement(By.Id("input-company"));
            }
        }
        public IWebElement Address1Field
        {
            get
            {
                return driver.FindElement(By.Id("input-address-1"));
            }
        }
        public IWebElement Address2Field
        {
            get
            {
                return driver.FindElement(By.Id("input-address-2"));
            }
        }
        public IWebElement CityField
        {
            get
            {
                return driver.FindElement(By.Id("input-city"));
            }
        }
        public IWebElement PostCodeField
        {
            get
            {
                return driver.FindElement(By.Id("input-postcode"));
            }
        }
        public IWebElement CountryField
        {
            get
            {
                return driver.FindElement(By.Id("input-country"));
            }
        }
        public IWebElement RegionField
        {
            get
            {
                return driver.FindElement(By.Id("input-zone"));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                return driver.FindElement(By.Id("input-password"));
            }
        }
        public IWebElement PasswordConfirmField
        {
            get
            {
                return driver.FindElement(By.Id("input-confirm"));
            }
        }
        public bool NewsletterSubscribe { get; private set; } = false;
        public IWebElement PrivacyPolicy
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='pull-right']//input[@type='checkbox' and @name='agree']"));
            }
        }
        public IWebElement ButtonContinue
        {
            get
            {
                return driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            }
        }

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickFirstName()
        {
            FirstNameField.Click();
        }
        public void InputFirstName(string firstName)
        {
            FirstNameField.SendKeys(firstName);
        }
        public void ClickLastName()
        {
            LastNameField.Click();
        }
        public void InputLastName(string lastName)
        {
            LastNameField.SendKeys(lastName);
        }
        public void ClickEmail()
        {
            EMailField.Click();
        }
        public void InputEmail(string email)
        {
            EMailField.SendKeys(email);
        }
        public void ClickTelephone()
        {
            TelephoneField.Click();
        }
        public void InputTelephone(string telephone)
        {
            TelephoneField.SendKeys(telephone);
        }
        public void ClickFax()
        {
            FaxField.Click();
        }
        public void InputFax(string fax)
        {
            FaxField.SendKeys(fax);
        }
        public void ClickCompany()
        {
            CompanyField.Click();
        }
        public void InputCompanyName(string companyName)
        {
            CompanyField.SendKeys(companyName);
        }
        public void ClickAddress1()
        {
            Address1Field.Click();
        }
        public void InputAddress1(string address1)
        {
            Address1Field.SendKeys(address1);
        }
        public void ClickAddress2()
        {
            Address2Field.Click();
        }
        public void InputAddress2(string address2)
        {
            Address2Field.SendKeys(address2);
        }
        public void ClickCity()
        {
            CityField.Click();
        }
        public void InputCity(string city)
        {
            CityField.SendKeys(city);
        }
        public void ClickPostCode()
        {
            PostCodeField.Click();
        }
        public void InputPostCode(string postCode)
        {
            PostCodeField.SendKeys(postCode);
        }
        public void ClickCountry()
        {
            CountryField.Click();
        }
        public void InputCountry(string country)
        {
            CountryField.SendKeys(country);
        }
        public void CkickRegion()
        {
            RegionField.Click();
        }
        public void InputRegion(string region)
        {
            RegionField.SendKeys(region);
        }

        public void ClickPassword()
        {
            PasswordField.Click();
        }
        public void InputPassword(string password)
        {
            PasswordField.SendKeys(password);
        }
        public void ClickPasswordConfirm()
        {
            PasswordConfirmField.Click();
        }
        public void InputPasswordConfirm(string passwordConfirm)
        {
            PasswordConfirmField.SendKeys(passwordConfirm);
        }

        public void CheckNewsletterSubscribe()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.ClassName("radio-inline")), 1, 1).Click().Perform();
            NewsletterSubscribe = true;
        }
        public void ClickPrivacyPolicy()
        {
            PrivacyPolicy.Click();
        }
    }

}

