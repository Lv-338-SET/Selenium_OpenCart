using NUnit.Framework;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class CurrencyTests
    {
        protected CurencyMethods cm;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get(ApplicationSourceRepository.Default());
            cm = new CurencyMethods();
            if (!cm.IsWishListEmpty())
            {
                cm.ClearWishList();
            }

            if (!cm.IsShoppingCartEmpty())
            {
                cm.ClearShoppingCart();
            }
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Remove();
            if (!cm.IsWishListEmpty())
            {
                cm.ClearWishList();
            }

            if (!cm.IsShoppingCartEmpty())
            {
                cm.ClearShoppingCart();
            }
        }

        [SetUp]
        public void SetUp()
        {
            cm.GoToHomePage();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [TestCase("Samsyng SyncMaster")]
        public void CheckChangeProductPriceCurrency(string productName)
        {
            cm.LoggedIn("testa@testa.com", "testa");
            cm.AddProductToWishList(productName);
            cm.GoToWishList();
            Thread.Sleep(50000);
        }


        [TestCase("Samsyng SyncMaster")]
        public void CheckChangeProductPriceCurrencyInWishList(string productName)
        {
            //Act
            cm.GoToHomePage();
            Thread.Sleep(2000);
            cm.LoggedIn("testa@testa.com", "testa");
            Thread.Sleep(2000);
            cm.AddProductToWishList(productName);
            Thread.Sleep(2000);
            WishListPage wishList = cm.GoToWishList();
            Thread.Sleep(5000);
            cm.ChooseEuro();
            string expectedResult = cm.GetCurrencyFromMainPage();
            string actualResult = cm.GetCurrencyFromWishList(wishList);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Samsyng SyncMaster")]
        public void CheckChangeProductPriceCurrencyInShopingCart(string productName)
        {
            //Act
            cm.GoToHomePage();
            Thread.Sleep(2000);
            cm.LoggedIn("testa@testa.com", "testa");
            Thread.Sleep(2000);
            cm.AddProductToCart(productName);
            Thread.Sleep(2000);
            cm.GoToShoppingCart();
            Thread.Sleep(5000);
            cm.ChooseEuro();
            string expectedResult = cm.GetCurrencyFromMainPage();
            string actualResult = cm.get();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
