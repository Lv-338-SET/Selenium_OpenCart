using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    class AddToCartMetods
    {

        IWebDriver WebDriver;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="webDriver"></param>
        public AddToCartMetods(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }


        public void FindElementProduct(string nameProduck)
        {
            HomePage homePage = new HomePage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
        }

        public void FindNameProduckt(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            HomePage homePage = new HomePage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
            Thread.Sleep(1500);
            topBar.ShopingCartButtonClick();
            shopingCartPage.GetProduct().ClickRemoveButton();
        }

        public HomePage IsCartIsEmpty()
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            Thread.Sleep(1500);
            topBar.ShopingCartButtonClick();
            shopingCartPage.GoToMainPageIfCartIsEmpty();
            return new HomePage(WebDriver);
        }

        public void VerifyIsCartEmpty()
        {
            TopBar topBar = new TopBar(WebDriver);
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            topBar.ShopingCartButtonClick();
            Thread.Sleep(1500);
            shopingCartPage.GetEmptyCartMessage();
        }
    }
}
