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
using Selenium_OpenCart.Data.Application;

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
            HomePage homePage = new HomePage();
            TopBar topBar = new TopBar();
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
        }

        public void FindNameProduckt(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            HomePage homePage = new HomePage();
            TopBar topBar = new TopBar();
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
            Thread.Sleep(1500);
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GetProduct().ClickRemoveButton();
        }

        public HomePage IsCartIsEmpty()
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            TopBar topBar = new TopBar();
            Thread.Sleep(1500);
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GoToMainPageIfCartIsEmpty();
            return new HomePage();
        }

        public void VerifyIsCartEmpty()
        {
            TopBar topBar = new TopBar();
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            topBar.ShoppingCartButtonClick();
            Thread.Sleep(1500);
            shopingCartPage.GetEmptyCartMessage();
        }
    }
}
