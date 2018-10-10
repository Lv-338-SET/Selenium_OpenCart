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
            TestsApplication.Get();
            cm = new CurencyMethods();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            TestsApplication.Remove();
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

        [Test]
        public void CheckChangeProductPriceCurrency()
        {
            //cm.SearchProducts("Samsung");
            ProductItem product = cm.ChooseAppropriateProduct("Samsung SyncMaster");
            cm.ScrollToView(product.GetProductCartButton());
            cm.AddProductToCart(product);

            cm.ScroolToElementCartButton(product);
            cm.GoToCart();
        }

        //[Test]
        //public void CheckChangeProductPriceCurrencyInWishList()
        //{
        //}

        //[Test]
        //public void CheckChangeProductPriceCurrencyInShopingCart()
        //{
        //}
    }
}
