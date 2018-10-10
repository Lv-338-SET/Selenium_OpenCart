using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.MainPage;
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
        protected IWebDriver driver;
        protected ISearch search;
        protected AllBrowsers Browser;

        public CurencyMethods()
        {
            this.driver = Application.Get(ApplicationSourceRepository.Default()).Browser.Driver;
            this.search = Application.Get(ApplicationSourceRepository.Default()).Search;
            this.Browser = Application.Get(ApplicationSourceRepository.Default()).Browser;
        }

        public void CurencyMetho()
        {
            this.search = Application.Get(ApplicationSourceRepository.Default()).Search;
            search.PresenceOfWebElement(search.ElementByXPath("some xapatrh or anothe"));//присутність елемента на сторінці
            IWebElement asd = search.ElementByXPath("some xapatrh or anothe");
        }

        public void Login(string userName, string Userpassword)
        {
            //loged in
        }

        public void Loginasd()
        {
            TopBar topBar = new TopBar(driver);
            Currency currencyMenu = topBar.ReturnCurrencyList();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonEuro();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonPoundSterling();
            Thread.Sleep(10000);
            currencyMenu.ClickButtonUSDolar();
        }

        public void GotoElement(IWebElement element)
        {
            //IWebDriver driver = Application.Get(ApplicationSourceRepository.Default()).Browser.Driver;
            Actions action = new Actions(driver);
            action.MoveToElement(element, 1, 1).Click().Perform();
        }

        public HomePage GoToHomePage()
        {
            Browser.OpenUrl(Application.Get(ApplicationSourceRepository.Default()).ApplicationSource.HomePageUrl);
            return new HomePage(driver);
        }

        public SearchPage SearchProducts(string searchItemName)
        {
            SearchMethods searchMethods = new SearchMethods(driver);
            return searchMethods.Search(searchItemName);
        }

        public ProductItem ChooseAppropriateProduct(string productName)
        {
            SearchPage search = SearchProducts(productName);
            return search.FindAppropriateProduct(productName);
        }

        public void AddProductToCart(ProductItem product)
        {
            product.ClickCartButton();
        }

        public void AddProductToWishList(ProductItem product)
        {
            product.ClickCartFavourite();
        }

        public void ScroolToElementWishList(ProductItem product)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(product.GetProductCartButton());
            //actions.Perform();
        }

        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("window.scrollTo({0}, {1})", xPosition, yPosition);
        }

        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100);
            }
        }

        public void ScroolToElementCartButton(ProductItem product)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(product.GetProductCartButton());
            //actions.Perform();
        }

        public ShopingCartPage GoToCart()
        {
            TopBar topBar = new TopBar(driver);
            return topBar.ShoppingCartButtonClick();
        }

        public WishListPage GoToWishList()
        {
            TopBar topBar = new TopBar(driver);
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
