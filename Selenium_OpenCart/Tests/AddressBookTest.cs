using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.AddressBookPage;
using Selenium_OpenCart.Tools;
using System.Threading;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Data.Address;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class AddressBookTest
    {
        IAdress adressInput = new XMLDataParser().GetInputAddress();
        //IWebDriver driver;
        const string URL = "http://40.118.125.245/";
        const string LOGOUT = "http://40.118.125.245/index.php?route=common/home";
        const string EMAIL = "zinko@mail.com";
        const string PASSWORD = "querty";

        //Test data        
        const string FIRST_NAME = "Victor";
        const string LAST_NAME = "Zinko";
        const string ADDRESS1 = "Grinchenko, 7";
        const string CITY = "Lviv";
        const string POST_CODE = "11001";
        const string COUNTRY = "Ukraine";
        const string REGION_STATE = "L'vivs'ka Oblast'";
        const string NEW_SHORT_ADDRESS = "Victor Zinko\r\nGrinchenko, 7\r\nLviv 11001\r\nL\'vivs\'ka Oblast\'\r\nUkraine";
                
        const string COMPANY = "SoftServe";        
        const string ADDRESS2 = "Naukova, 5";
        const string EDIT_POST_CODE = "11000";
        const string EDIT_SHORT_ADDRESS = "Victor Zinko\r\nSoftServe\r\nGrinchenko, 7\r\nNaukova, 5\r\nLviv 11000\r\nL'vivs'ka Oblast'\r\nUkraine";

        [SetUp]
        public void BeforeEachTests()
        {            
            Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.OpenUrl(Application.Get(ApplicationSourceRepository.ChromeNew()).ApplicationSource.HomePageUrl);
            //LogIn to the site
            //My Acount link
            IWebDriver temp_driver = Application.Get(ApplicationSourceRepository.ChromeNew()).Browser.Driver;
            temp_driver.FindElement(By.CssSelector("#top-links a.dropdown-toggle")).Click();
            //Login link
            temp_driver.FindElement(By.CssSelector("#top-links a[href$='/login']")).Click();
            temp_driver.FindElement(By.Id("input-email")).Clear();
            temp_driver.FindElement(By.Id("input-email")).SendKeys(EMAIL);//Type Login
            temp_driver.FindElement(By.Id("input-password")).Clear();
            temp_driver.FindElement(By.Id("input-password")).SendKeys(PASSWORD);//Type Password
            temp_driver.FindElement(By.CssSelector("form input[type ='submit']")).Click();//Login button

            //Click on "Address Book" link
            temp_driver.FindElement(By.CssSelector("#column-right a[href$='/address']")).Click();
        }        

        [TearDown]
        public void AfterEachTests()
        {
           Application.Get().Browser.OpenUrl(LOGOUT);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Application.Remove();
        }

        [TestCase(NEW_SHORT_ADDRESS)]
        public void Test1CreateNewAddressTest(string expected)        
        {
            //Arrange
            AddressBookPage addressBook = new AddressBookPage();                
            AddNewAddressPage newAddressPage = addressBook.GoToNewAddressPage();
            addressBook = newAddressPage.FillAllRequareField(adressInput.GetFirstName(), 
                    adressInput.GetLastName(), adressInput.GetAddress1(), adressInput.GetCity(),
                         adressInput.GetPostCode(), adressInput.GetCountry(), adressInput.GetZone())
            .Continue();
            
            //Act
            bool actual = addressBook.IsAddressInTableByShortAddress(expected);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestCase(NEW_SHORT_ADDRESS, EDIT_SHORT_ADDRESS)]
        public void Test2EditAddressTest(string oldAddress, string expected)
        {
            //Arrange
            AddressBookPage addressBook = new AddressBookPage();
            EditAddressPage editAddress = addressBook.EditAddress(oldAddress);                        
            addressBook = editAddress.FillAllNotRequareField(adressInput.GetCompany(), 
                adressInput.GetAddress2(), adressInput.GetPostCode()).Continue();            

            //Act
            bool actual = addressBook.IsAddressInTableByShortAddress(expected);

            //Assert
            Assert.True(actual);
        }

        [TestCase(EDIT_SHORT_ADDRESS)]
        public void Test3DeleteAddressTest(string expected)
        {
            //Arrange
            AddressBookPage addressBook = new AddressBookPage();            
            addressBook.GetAddressByShortAddress(expected).DeleteButton.Click();

            
            //Act
            bool actual = addressBook.IsAddressInTableByShortAddress(expected);
            
            //Assert
            Assert.IsFalse(actual);
        }

        [TestCase("", "", "1", "a", "222", " --- Please Select --- ", " --- Please Select --- ")]
        public void CreateFailedNewAddressTest(string firstName, string lastName, string address1,
                string city, string postCode, string country, string region)
        {
            //Arrange
            AddressBookPage addressBook = new AddressBookPage();
            AddNewAddressPage newAddressPage = addressBook.GoToNewAddressPage();
            newAddressPage.FillAllRequareField(firstName, lastName, address1,
                        city, postCode, country, region).ClickContinueButton();
            

            //Act
            bool actual = newAddressPage.AddressForm.IsEmptyInputErrorMessage();          

            //Assert
            Assert.IsTrue(actual);
        }
    }
}
