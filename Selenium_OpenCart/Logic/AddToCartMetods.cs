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
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
            topBar.ShoppingCartButtonClick();
            return shopingCartPage.GetProduct().GetProductName();

        }

        public string AddProductByNameUseSearch(string nameProduck)
        {
            ShopingCartPage shopingCartPage = new ShopingCartPage();
            SearchMethods search = new SearchMethods();
            TopBar topBar = new TopBar();
            search.Search(nameProduck).AddAppropriateItemToCart(nameProduck);
            Thread.Sleep(3000);
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
            homePage.FindAppropriateProduct(nameProduck).ClickCartButton();
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
            search.Search(nameProduck).AddAppropriateItemToCart(nameProduck);
            Thread.Sleep(3000);
            topBar.ShoppingCartButtonClick();
            return shopingCartPage.GetProduct().GetProductName();
        }

    }
}
