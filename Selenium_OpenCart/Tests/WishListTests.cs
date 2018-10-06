using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body;
using Selenium_OpenCart.Logic;


namespace Selenium_OpenCart
{

    [TestFixture]
    public class WishListTests
    {

        IWebDriver driver;

        [TestCase("iPhone")]
        [Order(0)]
        public void WishListWorks_AddingIphone_IsAdded(string product)
        {
            SearchMethods search = new SearchMethods(driver);
            search.Search(product).AddAppropriateItemToWishList(product);

            //use top-bar wishlist button   
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/wishlist");
            WishListPage wishList = new WishListPage(driver);
            bool result = wishList.ProductExistsInWishList(product);
            Assert.IsTrue(result, "Expected element is not added to wishlist");
        }


        //[TestCase("iPhone")]
        //[Order(1)]

        //public void AddToCartFromWishList_AddIphone_IsAdded(string product)
        //{
        //    driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/wishlist");
        //    //WishListPage wishList = new WishListPage(driver);
        //    //wishList.AddToCartFromWishList(product);
        //}


        [TestCase("iPhone")]
        [Order(1)]

        public void RemoveFromWishList_RemoveIphone_IsRemoved(string product)
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/wishlist");
            WishListPage wishList = new WishListPage(driver);
            wishList.RemoveProductFromWishList(product);
            bool result = wishList.SuccessMessageIsDisplayed();
            Assert.IsTrue(result, "Product still exists");
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            driver.Quit();
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");

            //Login page opening
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();

            //LOGGING IN
            driver.FindElement(By.Id("input-email")).SendKeys("iwilltestyounow@gmail.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty12345");
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Login']")).Click();
        }
        [SetUp]
        public void BeforeMethod()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }

    }
}