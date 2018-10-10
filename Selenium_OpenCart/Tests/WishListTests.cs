using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Data.Application;
using System.Threading;
using Selenium_OpenCart.Tools;
using OpenQA.Selenium.Support.UI;

namespace Selenium_OpenCart.Tests
{

    [TestFixture]
    public class WishListTests
    {
        bool addedToWishList = false;

        [TestCase("iPhone")]
        [Order(0)]
        public void WishListWorks_AddingIphone_IsAdded(string product)
        {
            TopBar topBar = new TopBar(Application.Get().Browser.Driver);
            bool IsEmptyBeforeAdding = topBar.WishListButtonClick().IsEmpty();
            SearchMethods search = new SearchMethods(Application.Get().Browser.Driver);
            search.Search(product).AddAppropriateItemToWishList(product);
            bool IsEmptyAfterAdding = topBar.WishListButtonClick().IsEmpty();
            Assert.AreNotEqual(IsEmptyBeforeAdding,IsEmptyAfterAdding,"Expected element is not added to wishlist");
            addedToWishList = true;
        }
        [TestCase("iPhone")]
        [Order(1)]
        public void SuccessAlertMessageIsDisplayedAfterAdding(string product)
        {
            SearchMethods search = new SearchMethods(Application.Get().Browser.Driver);
            bool result = search.Search(product).AddAppropriateItemToWishList(product).isSuccessMessageDisplayed();
            Assert.IsTrue(result, "Success message is not displayed");
        }


        [TestCase]
        [Order(2)]

        public void AddToCartFromWishList_AddIphone_IsAdded()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topbar = new TopBar(Application.Get().Browser.Driver);
           
            topbar.WishListButtonClick();
            WishListWithProducts wishlist = new WishListWithProducts(Application.Get().Browser.Driver);
            string productNameFromWishList = wishlist.GetProduct().GetProductName();
            wishlist.GetProduct().ClickAddToCartButton();
            string productNameFromCart = topbar.ShopingCartButtonClick().GetProduct().GetProductName();
            Assert.AreEqual(productNameFromWishList, productNameFromCart, "Element is not added to cart from wishlist");
        }


        [TestCase]
        [Order(3)]

        public void RemoveFromWishList_RemoveIphone_IsRemoved()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topBar = new TopBar(Application.Get().Browser.Driver);
            topBar.WishListButtonClick();
            WishListWithProducts wishList = new WishListWithProducts(Application.Get().Browser.Driver);
            wishList.GetProduct().ClickRemoveFromWishListButton();
            bool result = wishList.SuccessMessageIsDisplayed();
            Assert.IsTrue(result, "Product still exists");
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            TopBar topBar = new TopBar(Application.Get().Browser.Driver);
            topBar.ShopingCartButtonClick().GetProduct().ClickRemoveButton();
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Remove();
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            Application.Get().Browser.OpenUrl("http://40.118.125.245/");

            //Login page opening
            Application.Get().Search.ElementByClassName("caret").Click();
            Application.Get().Search.ElementByLinkText("Login").Click();

            //LOGGING IN
            Application.Get().Search.ElementById("input-email").SendKeys("test@gmail.com");
            Application.Get().Search.ElementById("input-password").SendKeys("testtest");
            Application.Get().Search.ElementByXPath("//input[@type='submit' and @value='Login']").Click();
        }
        

    }
}