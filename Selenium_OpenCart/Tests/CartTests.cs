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

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class CartTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TestCase]
        public void Verify()
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods(driver);
            addToCartMetods.VerifyIsCartEmpty();

        }

        [TestCase("MacBook")]
        public void CartButtonFromMainPageWorks_AddingMacBook_IsAdded(string product)
        {
            HomePage homePage = new HomePage();
            TopBar topBar = new TopBar();
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            homePage.FindAppropriateProduct(product).ClickCartButton();
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GetProduct().ClickRemoveButton();

        }

        [TestCase("iPhone")]
        public void RemoveFromCart(string product)
        {
            TopBar topBar = new TopBar();
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GetEmptyCartMessage();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
