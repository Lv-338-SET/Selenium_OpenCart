using System;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Body.AddressBookPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Data.Address;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;
using Selenium_OpenCart.Logic;
using NLog;
using Selenium_OpenCart.Data.Constants;


namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class AddressBookTest
    {
        //Logger
        public static Logger log = LogManager.GetCurrentClassLogger();

        //Test data       
        const string LOGOUT = "http://40.118.125.245/index.php?route=common/home";
        const string EMAIL = "zinko@mail.com";
        const string PASSWORD = "querty";
        const string NEW_SHORT_ADDRESS = "Victor Zinko\r\nGrinchenko, 7\r\nLviv 11001\r\nL\'vivs\'ka Oblast\'\r\nUkraine"; 
        const string EDIT_SHORT_ADDRESS = "Victor Zinko\r\nSoftServe\r\nGrinchenko, 7\r\nNaukova, 5\r\nLviv 11001\r\nL'vivs'ka Oblast'\r\nUkraine";
        IAdress adressInput = new XMLDataParser().GetInputAddress();
        IAdress invalidAdressInput = new XMLDataParser().GetInputAddress("invalidAddress.xml");

        [SetUp]
        public void BeforeEachTests()
        {           

            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew()).Browser.Driver.Manage().Cookies.DeleteAllCookies();            
            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew()).Browser.OpenUrl(Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew()).ApplicationSource.HomePageUrl);

            //LogIn to the site
            MyAccountPage myAccountPage = new LoginPageMethods().LogIntoAccount(EMAIL, PASSWORD);
            //Click on "Address Book" link
            myAccountPage.ClickLinkAddressBook();           
            
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
            log.Info("Test finished!");
        }

        [TestCase(NEW_SHORT_ADDRESS, EDIT_SHORT_ADDRESS)]
        public void SmokeAddressTest(string newAddress, string editNewAddress)        
        {            
            AddressBookPage addressBook = new AddressBookPage();
            
            //Add new address test
            AddNewAddressPage newAddressPage = addressBook.GoToNewAddressPage();
            addressBook = newAddressPage.FillAllRequareField(adressInput.GetFirstName(), 
                    adressInput.GetLastName(), adressInput.GetAddress1(), adressInput.GetCity(),
                         adressInput.GetPostCode(), adressInput.GetCountry(), adressInput.GetZone())
            .Continue();
            try
            {
                Assert.IsTrue(addressBook.IsAddressInTableByShortAddress(newAddress), "Create new address Test, FAIL");
            }
            catch(AssertionException)
            {
                log.Info("\"Create new address Test\" FAIL");
                new AddressBookException("Create new address Test, FAIL");                
            }

            //Edit address test
            EditAddressPage editAddress = addressBook.EditAddress(newAddress);                        
            addressBook = editAddress.FillAllNotRequareField(adressInput.GetCompany(), 
                adressInput.GetAddress2(), adressInput.GetPostCode()).Continue();

            try
            {
                Assert.True(addressBook.IsAddressInTableByShortAddress(editNewAddress));
            }
            catch (AssertionException)
            {
                log.Info("\"Edit Address Test\" FAIL");
                new AddressBookException("Edit address Test, FAIL");                
            }            
            log.Info("\"Edit Address Test\" pass"); 
            
            //Delete address test
            while (addressBook.IsAddressInTableByShortAddress(editNewAddress))
            {
                addressBook.GetAddressByShortAddress(editNewAddress).DeleteButton.Click();
                if (addressBook.GetAddressesTableLength()==1)
                {
                    log.Info("\""+editNewAddress+" - The last address in table \" FAIL");
                    throw new AddressBookException("Delete address Test, FAIL");                    
                }
            }
            try
            {
                Assert.IsFalse(addressBook.IsAddressInTableByShortAddress(editNewAddress));
            }
            catch (AssertionException)
            {
                log.Info("\"Delete Address Test\" FAIL");
                new AddressBookException("Delete address Test, FAIL");                
            }           
            log.Info("\"All Test\" pass");            
        }

        [Test]
        public void CreateFailedNewAddressTest()
        {
            //Arrange
            AddressBookPage addressBook = new AddressBookPage();
            AddNewAddressPage newAddressPage = addressBook.GoToNewAddressPage();
            newAddressPage.FillAllRequareField(invalidAdressInput.GetFirstName(), invalidAdressInput.GetLastName(),
                    invalidAdressInput.GetAddress1(), invalidAdressInput.GetCity(), invalidAdressInput.GetPostCode(),
                        invalidAdressInput.GetCountry(), invalidAdressInput.GetZone()).ClickContinueButton(); 

            //Act
            bool actual = newAddressPage.AddressForm.IsEmptyInputErrorMessage();          

            //Assert
            Assert.IsTrue(actual);
            log.Info("\"Create Failed New Address Test\" pass");
        }
    }
}
