using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.LogoutPage;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Selenium_OpenCart.Pages.Body.MyAccountFolder;

namespace Selenium_OpenCart.Logic
{
    public class CurencyMethods
    {
        public string CurrentCurrencyFromMain;
        public CurencyMethods()
        {
        }

        public HomePage GoToHomePage()
        {
            return new HomePage();
        }

        internal LogoutPage LogOut()
        {
            Application.Get().Browser.OpenUrl(Application.Get().ApplicationSource.LogoutPageUrl);
            return new LogoutPage();
        }

        public LoginPage GoToLoginPage()
        {
            TopBar navBar = new TopBar();
            NotLoginedUserAcountElements accountMenu = (NotLoginedUserAcountElements)navBar.MyAccountButtonClick();
            return accountMenu.LoginButtomClick();
        }

        public MyAccountPage LoggedIn(string userName, string Userpassword)
        {
            LoginPage items = GoToLoginPage();
            items.ClickClearInputLoginEmail(userName);
            items.ClickClearInputLoginPassword(Userpassword);
            items.ClickLoginButton();
            return new MyAccountPage();
        }

        public bool IsWishListEmpty()
        {
            TopBar navBar = new TopBar();
            return navBar.WishListButtonClick().IsEmpty();
        }

        public SearchPage SearchProduct(string productName)
        {
            SearchMethods searchmethods = new SearchMethods();
            return searchmethods.Search(productName);
        }


        public void AddProductToWishList(string productName)
        {
            SearchMethods searchmethods = new SearchMethods();
            SearchPage search = searchmethods.Search(productName);
            search.AddAppropriateItemToWishList(productName);
        }

        public bool IsShoppingCartEmpty()
        {
            TopBar navBar = new TopBar();
            return navBar.ShoppingCartButtonClick().IsEmpty();
        }

        public void AddProductToCart(string productName)
        {
            SearchMethods searchmethods = new SearchMethods();
            SearchPage search = searchmethods.Search(productName);
            search.AddAppropriateItemToShopingCart(productName);
        }

        public ShopingCartPage GoToShoppingCart()
        {
            TopBar navBar = new TopBar();
            return navBar.ShoppingCartButtonClick();
        }

        public WishListPage GoToWishList()
        {
            TopBar navBar = new TopBar();
            return navBar.WishListButtonClick();
        }

        public void ClearWishList()
        {
            TopBar navBar = new TopBar();
            WishListPage wishList = navBar.WishListButtonClick();
            while (!wishList.IsEmpty())
            {
               wishList.GetProduct().ClickRemoveFromWishListButton();
            }
        }

        public void ClearShoppingCart()
        {
            TopBar navBar = new TopBar();
            ShopingCartPage shopingCart = navBar.ShoppingCartButtonClick();
            while (!shopingCart.IsEmpty())
            {
                shopingCart.GetProduct().ClickRemoveButton();
            }
        }

        public void ChooseUSD()
        {
            TopBar navBar = new TopBar();
            Currency currencyMenu = navBar.ReturnCurrencyList();
            currencyMenu.ClickButtonUSDolar();
            CurrentCurrencyFromMain = currencyMenu.GetCurrencyFromMenu();
        }

        public bool Verify()
        {
            TopBar navBar = new TopBar();
            return TopBar.Verify();
        }

        public void ChooseEuro()
        {
            TopBar navBar = new TopBar();
            Currency currencyMenu = navBar.ReturnCurrencyList();
            currencyMenu.ClickButtonEuro();
            CurrentCurrencyFromMain = currencyMenu.GetCurrencyFromMenu();
        }

        public void ChoosePoundSterling()
        {
            TopBar navBar = new TopBar();
            Currency currencyMenu = navBar.ReturnCurrencyList();
            currencyMenu.ClickButtonPoundSterling();
            CurrentCurrencyFromMain = currencyMenu.GetCurrencyFromMenu();
        }

        public string GetCurrencyFromMainPage()
        {
            TopBar navBar = new TopBar();
            Currency currencyMenu = navBar.ReturnCurrencyList();
            return currencyMenu.GetCurrencyFromMenu();
        }

        public string GetCurrencyFromProductItem(SearchPage searchPage)
        {
            List<ProductItem> products = searchPage.GetListProduct();
            string productPrice = products[0].GetTextFromProductPrice(); ;
            string cleanProductPrice = productPrice.Trim();
            string[] productPrises = cleanProductPrice.Split(':');
            string price = productPrises[1];
            if (CurrentCurrencyFromMain == "€")
            {
                return price[price.Length - 1].ToString();
            }
            else
            {
                return price[0].ToString();
            }
        }

        public string GetCurrencyFromWishList(WishListPage wishListPage)
        {
            WishListTableItem product = wishListPage.GetProduct();
            string productPrice = product.GetProductPrice();
            string cleanProductPrice = productPrice.Trim();
            return cleanProductPrice[cleanProductPrice.Length - 1].ToString();
        }

        public string GetCurrencyFromShopingCart(ShopingCartPage shopingCartPage)
        {
            ShopingCartTableItem product = shopingCartPage.GetProduct();
            string productPrice = product.GetProductPrice();
            string cleanProductPrice = productPrice.Trim();
            if (CurrentCurrencyFromMain == "€")
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
