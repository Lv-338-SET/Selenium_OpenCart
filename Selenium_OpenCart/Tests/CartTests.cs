using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class CartTests
    {
        const string URL = "http://40.118.125.245/";
        Uri uri = new Uri("http://3.16.80.107:4444/wd/hub");

        [SetUp]
        public void SetUp()
        {
            Application.Get(ApplicationSourceRepository.RemoteLinuxChromeNew(uri)).Browser.OpenUrl(URL);
        }

        [TestCase]
        public void VerifyIsCartEmpty()
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods();
            addToCartMetods.IsCartEmpty();
        }

        [TestCase("iPhone")]
        public void AddingProductToCartFromMainPage(string product)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods();
            string actual = addToCartMetods.AddProductByName(product);

            Assert.AreEqual(product, actual);
        }

        [TestCase("MacBook")]
        public void AddProductByNameUseSearch(string productName)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods();
            string actual = addToCartMetods.AddProductByNameUseSearch(productName);

            Assert.AreEqual(productName, actual);

        }

        [TestCase("iPhone")]
        public void RemoveFromCart(string productName)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods();
            addToCartMetods.RemoveFromCart(productName);
        }

        [TestCase("iPhone", "test@gmail.com", "testtest")]
        public void AddProductByNameUseSearchWithLofinedUser(string productName, string email, string password)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods();
            string actual = addToCartMetods.AddProductByNameUseSearchWithLofinedUser(productName, email, password);

            Assert.AreEqual(productName, actual);
        }

        [TearDown]
        public void TearDown()
        {
            Application.Remove();
        }
    }
}
