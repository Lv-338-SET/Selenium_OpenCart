using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public SearchPage SearchProducts(string searchItemName)
        {
            SearchMethods searchMethods = new SearchMethods(Driver);
            return searchMethods.Search(searchItemName);
        }

        public ProductItem ChooseAppropriateProduct(string productName)
        {
            SearchPage search = SearchProducts(productName);
            return search.FindAppropriateProduct(productName);
        }

        public void AddProductToCart(ProductItem product)
        {
            product.ClickCartfavourite();
        }

        public void AddProductToWishList(ProductItem product)
        {
            product.ClickCartButton();
        }

        public void ScroolToElementWishList(ProductItem product)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(product.GetProductCartButton());
            //actions.Perform();
        }

        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
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
            Actions actions = new Actions(Driver);
            actions.MoveToElement(product.GetProductCartButton());
            //actions.Perform();
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
