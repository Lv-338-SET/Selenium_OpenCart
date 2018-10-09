using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Pages.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Logic
{
    public class CurencyMethods
    {
        private IWebDriver driver;

        public CurencyMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddProductToCart(string productName)
        {
            TopBar topBar = new TopBar(driver);
            bool isWishListEmpty = topBar.WishListButtonClick().IsEmpty();
            //Clear Cart
            SearchMethods search = new SearchMethods(driver);
            search.Search(productName).FindAppropriateProduct(productName).ClickCartfavourite();
        }

        public void AddProductToWishList(string productName)
        {
            TopBar topBar = new TopBar(driver);
            bool isWishListEmpty = topBar.WishListButtonClick().IsEmpty();
            //Clear WishList
            SearchMethods search = new SearchMethods(driver);
            search.Search(productName).FindAppropriateProduct(productName).ClickCartfavourite();
        }
    }
}
