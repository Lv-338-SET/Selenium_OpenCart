using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Logic;
using System.Threading;

namespace Selenium_OpenCart.Tests
{

    [TestFixture]
    public class WishListTests
    {
        bool addedToWishList = false;

        IWebDriver driver;

        [TestCase("iPhone")]
        [Order(0)]
        public void WishListWorks_AddingIphone_IsAdded(string product)
        {
            TopBar topBar = new TopBar(driver);
            bool IsEmptyBeforeAdding = topBar.WishListButtonClick().IsEmpty();
            SearchMethods search = new SearchMethods(driver);
            search.Search(product).AddAppropriateItemToWishList(product);
            bool IsNotEmptyAfterAdding = topBar.WishListButtonClick().IsNotEmpty();
            Assert.AreEqual(IsEmptyBeforeAdding,IsNotEmptyAfterAdding,"Expected element is not added to wishlist");
            addedToWishList = true;
        }
        [TestCase("iPhone")]
        [Order(1)]
        public void SuccessAlertMessageIsDisplayedAfterAdding(string product)
        {
            SearchMethods search = new SearchMethods(driver);
            bool result = search.Search(product).AddAppropriateItemToWishList(product).isSuccessMessageDisplayed();
            Assert.IsTrue(result, "Success message is not displayed");
        }


        [TestCase]
        [Order(2)]

        public void AddToCartFromWishList_AddIphone_IsAdded()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topbar = new TopBar(driver);
            topbar.WishListButtonClick();
            WishListWithProducts wishlist = new WishListWithProducts(driver);
            string productNameFromWishList = wishlist.GetProduct().GetProductName();
            wishlist.GetProduct().ClickAddToCartButton();
            string productNameFromCart = topbar.ShopingCartButtonClick().GetProduct().GetProductPrice();
            Assert.AreEqual(productNameFromWishList,productNameFromCart,"Element is not added to cart from wishlist");
        }


        [TestCase]
        [Order(3)]

        public void RemoveFromWishList_RemoveIphone_IsRemoved()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topBar = new TopBar(driver);
            topBar.WishListButtonClick();
            WishListWithProducts wishList = new WishListWithProducts(driver);
            wishList.GetProduct().ClickRemoveFromWishListButton();
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