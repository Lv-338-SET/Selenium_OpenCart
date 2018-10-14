using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Tools;
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

      
        public string AddProductByName(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            HomePage homePage = new HomePage();
            TopBar topBar = new TopBar();
            var product = homePage.FindAppropriateProduct(nameProduck);
            Thread.Sleep(500);
            product.ClickCartButton();
            Thread.Sleep(500);
            topBar.ShoppingCartButtonClick();
            return shopingCartPage.GetProduct().GetProductName();

        }

        public string AddProductByNameUseSearch(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            SearchMethods search = new SearchMethods();
            TopBar topBar = new TopBar();
            var searchResult = search.Search(nameProduck);
            Thread.Sleep(500);
            searchResult.AddAppropriateItemToCart(nameProduck);
            Thread.Sleep(500);
            topBar.ShoppingCartButtonClick();
            return shopingCartPage.GetProduct().GetProductName();
        }

        public HomePage IsCartEmpty()
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            TopBar topBar = new TopBar();
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GetEmptyCartMessage();
            return new HomePage();
        }

        public void RemoveFromCart(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            HomePage homePage = new HomePage();
            TopBar topBar = new TopBar();
            var product = homePage.FindAppropriateProduct(nameProduck);
            Thread.Sleep(500);
            product.ClickCartButton();
            Thread.Sleep(500);
            topBar.ShoppingCartButtonClick();
            shopingCartPage.GetProduct().GetProductName();
            shopingCartPage.GetProduct().ClickRemoveButton();
            shopingCartPage.GetEmptyCartMessage();
        }

        public string AddProductByNameUseSearchWithLofinedUser(string nameProduck, string email, string password)
        {
            LoginPageMethods login = new LoginPageMethods();
            login.LogIntoAccount(email, password);
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            SearchMethods search = new SearchMethods();
            TopBar topBar = new TopBar();
            var product = search.Search(nameProduck);
            product.AddAppropriateItemToCart(nameProduck);
            //Thread.Sleep(1000);
            topBar.ShoppingCartButtonClick();
            return shopingCartPage.GetProduct().GetProductName();
        }

    }
}
