using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.CartPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        [TestCase("MacBook")]
        public void CartButtonFromMainPageWorks_AddingMacBook_IsAdded(string product)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods(driver);
            addToCartMetods.FindElementProduct(product);

        }

        [TestCase("MacBook")]
        public void RemoveFromCart(string product)
        {
            AddToCartMetods addToCartMetods = new AddToCartMetods(driver);
            addToCartMetods.FindElementProduct(product);
            

        }




        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
