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
            //topBar.ShopingCardButtonClick();
            //shopingCardPage.ShopingCardButtonClick();

        }

        public HomePage IsCartIsEmpty()
        {
            HomePage homePage = new HomePage(WebDriver);
            ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            TopBar topBar = new TopBar(WebDriver);
            //topBar.ShopingCardButtonClick();
            shopingCartPage.GoToMainPageIfCartIsEmpty();
            return new HomePage(WebDriver);

        }

        //public ShopingCartPage RemoveFromCart(string name)
        //{
        //    ShopingCartPage shopingCartPage = new ShopingCartPage(WebDriver);
            //shopingCartPage.
        //}


    }
}
