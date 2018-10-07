using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MainPage;
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
            TopBar shopingCardPage = new TopBar(WebDriver);
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();

            shopingCardPage.ShopingCardButtonClick();

        }


    }
}
