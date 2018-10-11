using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.MyAccount;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    public class CurencyMethods
    {
        private ISearch search;
        private AllBrowsers browser;
        private TopBar topBar;

        public CurencyMethods()
        {
            topBar = new TopBar();
            this.search = Application.Get(ApplicationSourceRepository.Default()).Search;
            this.browser = Application.Get(ApplicationSourceRepository.Default()).Browser;
        }

        public HomePage GoToHomePage()
        {
            browser.OpenUrl(Application.Get(ApplicationSourceRepository.Default()).ApplicationSource.HomePageUrl);
            return new HomePage(browser.Driver);
        }

        public LoginPage GoToLoginPage()
        {
            NotLoginedUserAcountElements accountMenu = (NotLoginedUserAcountElements)topBar.MyAccountButtonClick();
            return accountMenu.LoginButtomClick();
        }

        public MyAccountPage LoggedIn(string userName, string Userpassword)
        {
            LoginPage items = GoToLoginPage();
            items.ClickClearInputLoginEmail(userName);
            items.ClickClearInputLoginPassword(Userpassword);
            items.ClickLoginButton();
            return new MyAccountPage(browser.Driver);
        }

        public bool IsWishListEmpty()
        {
            return topBar.WishListButtonClick().IsEmpty();
        }

        public void AddProductToWishList(string productName)
        {
            SearchPage search = SearchProducts(productName);
            search.AddAppropriateItemToWishList(productName);
        }

        public bool IsShoppingCartEmpty()
        {
            return topBar.ShoppingCartButtonClick().IsEmpty();
        }

        public void AddProductToCart(string productName)
        {
            SearchPage search = SearchProducts(productName);
            search.AddAppropriateItemToShopingCart(productName);
        }

        public ShopingCartPage GoToShoppingCart()
        {
            return topBar.ShoppingCartButtonClick();
        }

        public WishListPage GoToWishList()
        {
            return topBar.WishListButtonClick();
        }

        public void ClearWishList()
        {
            WishListPage wishList = topBar.WishListButtonClick();
            while (!wishList.IsEmpty())
            {
               wishList.GetProduct().ClickRemoveFromWishListButton();
            }
        }

        public void ClearShoppingCart()
        {
            while (!topBar.ShoppingCartButtonClick().IsEmpty())
            {
            }
        }

        public void ChooseUSD()
        {
            Currency currencyMenu = topBar.ReturnCurrencyList();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonUSDolar();
        }

        public void ChooseEuro()
        {
            Currency currencyMenu = topBar.ReturnCurrencyList();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonEuro();
        }

        public void ChoosePoundSterling()
        {
            Currency currencyMenu = topBar.ReturnCurrencyList();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonPoundSterling();
        }

        public string GetCurrencyFromMainPage()
        {
            Currency currencyMenu = topBar.ReturnCurrencyList();
            Thread.Sleep(10000);
            string shopCurrency = currencyMenu.GetCurrencyFromMenu();
            return shopCurrency[0].ToString();
        }

        public string GetCurrencyFromWishList(WishListPage wishListPage)
        {
            WishListTableItem product = wishListPage.GetProduct();
            string productPrice = product.GetProductPrice();
            string cleanProductPrice = productPrice.Replace(" ", "");
            if (GetCurrencyFromMainPage() == "€")
            {
                return cleanProductPrice[cleanProductPrice.Length - 1].ToString();
            }
            else
            {
                return cleanProductPrice[0].ToString();
            }
        }

        public string GetCurrencyFromShopingCart(ShopingCartPage shopingCartPage)
        {
            ShopingCartTableItem product = shopingCartPage.GetProduct();
            string productPrice = product.GetProductPrice();
            string cleanProductPrice = productPrice.Replace(" ", "");
            if (GetCurrencyFromMainPage() == "€")
            {
                return cleanProductPrice[cleanProductPrice.Length - 1].ToString();
            }
            else
            {
                return cleanProductPrice[0].ToString();
            }
        }
    }
}
