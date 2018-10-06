using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium_OpenCart.Pages;
using Selenium_OpenCart.Pages.Body;


namespace OpenCart
{
    
    [TestFixture]
    public class OpenCartTest
    {

        IWebDriver driver;

        [TestCase("iPhone")]
        [Order(0)]
        public void WishListWorks_AddingIphone_IsAdded(string product)
        {

            //PRODUCT SEARCHING
            Header header = new Header(driver);
            header.Search(product).AddAppropriateItemToWishList(product);
            //header.
            //bool result = WishListPage.IsProductAdded(product);
            Assert.IsTrue(result, "Expected element is added to wishlist");
            
        }


        [TestCase("iPhone")]
        [Order(1)]

        public void AddToCartFromWishList_AddIphone_IsAdded(string product)
        {
            WishListPage wishList = new WishListPage(driver);
            
        }


        [TestCase("iPhone")]
        [Order(2)]

        public void RemoveFromWishList_RemoveIphone_IsRemoved(string product)
        {
            
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");

            //Login page opening
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();

            //LOGGING IN
            driver.FindElement(By.Id("input-email")).SendKeys("iwilltestyounow@gmail.com");
            driver.FindElement(By.Id("input-password")).SendKeys("qwerty12345");
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Login']")).Click();
        }

    }
}
