using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            topBar.ShopingCartButtonClick();
        }

        public void FindNameProduckt(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            HomePage homePage = new HomePage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
            topBar.ShopingCartButtonClick();
            shopingCartPage.GetProduct().ClickRemoveButton();

        }

        public HomePage IsCartIsEmpty()
        {
            HomePage homePage = new HomePage(WebDriver);
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            topBar.ShopingCartButtonClick();
            shopingCartPage.GoToMainPageIfCartIsEmpty();
            return new HomePage(WebDriver);
        }
        public void VerifyIsCartEmpty()
        {
            TopBar topBar = new TopBar(WebDriver);
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            topBar.ShopingCartButtonClick();
            shopingCartPage.GetEmptyCartMessage();
        }
    }
}