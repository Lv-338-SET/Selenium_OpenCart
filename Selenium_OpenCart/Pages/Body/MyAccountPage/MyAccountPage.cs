using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.EditAccount;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.MyAccountPage
{
    public class MyAccountPage
    {

        //private IWebDriver driver;
        private ISearch Search;
        public MyAccountPage()
        {
            Search = Application.Get(ApplicationSourceRepository.Default()).Search;
        }
        public IWebElement MyAccount
        {
            get
            {
                
                return Search.ElementByXPath("//a[contains(@href,'/account')]");
            }

        }
        public IWebElement EditAccount
        {
            get
            {
                return Search.ElementByXPath("//a[contains(@href,'/edit')]");
            }
        }
        public IWebElement ChangePassword
        {
            get
            {
                return Search.ElementByXPath("//a[contains(@href,'/password')]");
            }
        }
        public IWebElement AddressBook
        {
            get
            {
                return Search.ElementByXPath("//a[contains(@href,'/address')]");
            }
        }
        public IWebElement WishList
        {
            get
            {
                return Search.ElementByXPath("//a[contains(@href,'/wishlist')]");
            }
        }
        public IWebElement Logout
        {
            get
            {
                return Search.ElementByXPath("//a[contains(@href,'/logout')]");
            }
        }

        public MyAccountPage ClikLinkMyAccount()
        {
            MyAccount.Click();
            return new MyAccountPage();
        }
        public EditAccountPage ClickLinkEditAccount()
        {
            EditAccount.Click();
            return new EditAccountPage();
        }
        public ChangePasswordPage.ChangePasswordPage ClickLinkChangePassword()
        {
            ChangePassword.Click();
            return new ChangePasswordPage.ChangePasswordPage();
        }
        public AddressBookPage.AddressBookPage ClickLinkAddressBook()
        {
            AddressBook.Click();
            return new AddressBookPage.AddressBookPage();
        }

        public LogoutPage.LogoutPage ClickLinkLogout()
        {
            Logout.Click();
            return new LogoutPage.LogoutPage();
        }
    }
}
