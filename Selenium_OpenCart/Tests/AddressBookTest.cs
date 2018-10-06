using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Body.AddressBookPage;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class AddressBookTest
    {
        IWebDriver driver;
        const string URL = "http://set-338.000webhostapp.com";
        const string EMAIL = "zinko@mail.com";
        const string PASSWORD = "querty";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        [SetUp]
        public void BeforeEachTest()
        {
            driver.Navigate().GoToUrl(URL);
            //LogIn to the site
            //My Acount link
            driver.FindElement(By.CssSelector("#top-links a.dropdown-toggle")).Click();
            
            //Login link
            driver.FindElement(By.CssSelector("#top-links a[href$='/login']")).Click();

            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys(EMAIL);//Type Login
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(PASSWORD);//Type Password
            driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();//Login button
            
            //Click on "Address Book" link
            driver.FindElement(By.CssSelector("#column-right a[href$='/address']")).Click();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        [Test]
        public void FirstTest()
        {
            AddressBook addressBook = new AddressBook(driver);
            Assert.IsTrue(addressBook.IsNoAddressMessage);
        }
    }
}
