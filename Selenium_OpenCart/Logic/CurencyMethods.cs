using OpenQA.Selenium;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    public class CurencyMethods
    {
        protected IWebDriver Driver { get; private set; }
        protected AllBrowsers Browser { get; private set; }

        public CurencyMethods()
        {
            this.Driver = TestsApplication.Get().Browser.Driver;
            this.Browser = TestsApplication.Get().Browser;
        }

        public void Login(string userName, string Userpassword)
        {
            //loged in
        }

        public HomePage GoToHomePage()
        {
            Browser.OpenUrl(TestsApplication.Get().ApplicationSource.HomePageUrl);
            return new HomePage(Driver);
        }

        public SearchPage SearchProduct(string productName)
        {
            SearchMethods searchMethods = new SearchMethods(Driver);
            return searchMethods.Search(productName);
        }

        public ProductItem ChooseAppropriateProduct(string productName)
        {
            SearchPage search = SearchProduct(productName);
            return search.FindAppropriateProduct(productName);
        }

        public void AddProductToCart(ProductItem product)
        {
            //TopBar topBar = new TopBar(Driver);
            //ShopingCartPage shopingCart = new ShopingCartPage(Driver);
            ////Clear Cart
            //SearchPage search = SearchProduct(productName);
            //search.FindAppropriateProduct(productName).ClickCartfavourite();
            product.ClickCartfavourite();
        }

        public void AddProductToWishList(ProductItem product)
        {
            //TopBar topBar = new TopBar(Driver);
            //bool isWishListEmpty = topBar.WishListButtonClick().IsEmpty();
            ////Clear WishList
            //SearchMethods search = new SearchMethods(Driver);
            //search.Search(productName).FindAppropriateProduct(productName).ClickCartfavourite();
            product.ClickCartButton();
        }

        public ShoppingCartPage GoToCart()
        {
            TopBar topBar = new TopBar(Driver);
            return topBar.ShoppingCartButtonClick();
        }

        public WishListPage GoToWishList()
        {
            TopBar topBar = new TopBar(Driver);
            return topBar.WishListButtonClick();
        }

        public void GoToWishList(ProductItem product)
        {
            //TopBar topBar = new TopBar(Driver);
            //bool isWishListEmpty = topBar.WishListButtonClick().IsEmpty();
            ////Clear WishList
            //SearchMethods search = new SearchMethods(Driver);
            //search.Search(productName).FindAppropriateProduct(productName).ClickCartfavourite();
            product.ClickCartButton();
        }
    }
}
