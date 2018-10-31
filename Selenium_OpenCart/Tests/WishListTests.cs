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
using Selenium_OpenCart.Data.Product;
using Selenium_OpenCart.Data.User;

namespace Selenium_OpenCart.Tests
{
    
    [TestFixture]
    [Parallelizable]
    public class WishListTests
    {
        IProduct inputProduct = new XMLDataParser().GetInputProduct();
        IUser user = new XMLDataParser().GetUserInputData();
        readonly Uri Grid = new System.Uri("http://40.124.42.236:4444/wd/hub");
        bool addedToWishList = false;

        [Test]
        [Order(0)]
        public void WishListWorks_AddingIphone_IsAdded()
        {
            TopBar topBar = new TopBar();
            bool IsEmptyBeforeAdding = topBar.WishListButtonClick().IsEmpty();
            SearchMethods search = new SearchMethods();
            search.Search(inputProduct.GetName()).AddAppropriateItemToWishList(inputProduct.GetName());
            bool IsEmptyAfterAdding = topBar.WishListButtonClick().IsEmpty();
            Assert.AreNotEqual(IsEmptyBeforeAdding,IsEmptyAfterAdding,"Expected element is not added to wishlist");
            addedToWishList = true;
        }

        [Test]
        [Order(1)]
        public void SuccessAlertMessageIsDisplayedAfterAdding()
        {
            SearchMethods search = new SearchMethods();
            bool result = search.Search(inputProduct.GetName()).AddAppropriateItemToWishList(inputProduct.GetName()).isSuccessMessageDisplayed();
            Assert.IsTrue(result, "Success message is not displayed");
        }

        [Test]
        [Order(2)]
        public void AddToCartFromWishList_AddIphone_IsAdded()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topbar = new TopBar();
            string productNameFromWishList = topbar.WishListButtonClick()
                .GetProduct().ClickAddToCartButton()
                .GetProduct().GetProductName();
            string productNameFromCart = topbar.ShoppingCartButtonClick().GetProduct().GetProductName();
            Assert.AreEqual(productNameFromWishList, productNameFromCart, "Element is not added to cart from wishlist");
        }

        [Test]
        [Order(3)]

        public void RemoveFromWishList_RemoveIphone_IsRemoved()
        {
            Assert.IsTrue(addedToWishList, "Blocked : precondition failed");
            TopBar topBar = new TopBar();
            bool result = topBar.WishListButtonClick().GetProduct().ClickRemoveFromWishListButton().SuccessMessageIsDisplayed();
            Assert.IsTrue(result, "Product still exists");
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            TopBar topBar = new TopBar();
            topBar.ShoppingCartButtonClick().GetProduct().ClickRemoveButton();
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Remove();
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew(Grid)).Browser.OpenUrl(Application.Get().ApplicationSource.HomePageUrl);
            
            //Logging in
            LoginPageMethods login = new LoginPageMethods();
            login.LogIntoAccount(user.GetUsername(),user.GetPassword());
        }
    }
}