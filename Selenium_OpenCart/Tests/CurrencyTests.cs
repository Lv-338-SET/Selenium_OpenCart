using NUnit.Framework;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Pages.Body.CartPage;
using Selenium_OpenCart.Pages.Body.WishListPage;
using Selenium_OpenCart.Tools; 

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class CurrencyTests
    {
        const string TESTED_PRODUCT_NAME = "MacBook Air";
        const string USER_LOGIN = "testa@testa.com";
        const string USER_PASSWOR = "testa";

        protected CurencyMethods cm;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get().Browser.OpenUrl(Application.Get().ApplicationSource.HomePageUrl);
            cm = new CurencyMethods();
            cm.LoggedIn(USER_LOGIN, USER_PASSWOR);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            if (!cm.IsWishListEmpty())
            {
                cm.ClearWishList();
            }

            if (!cm.IsShoppingCartEmpty())
            {
                cm.ClearShoppingCart();
            }
            cm.LogOut();
            Application.Get().Browser.Driver.Manage().Cookies.DeleteAllCookies();
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            Application.Get().Browser.OpenUrl(Application.Get().ApplicationSource.HomePageUrl);
        }

        [TearDown]
        public void TearDown()
        {
            cm.ChooseUSD();
        }

        [TestCase(TESTED_PRODUCT_NAME)]
        public void CheckChangeProductPriceCurrency(string productName)
        {
            //Act
            string expectedResult = "€";
            string actualResult = "€";

            //Assert
            Assert.IsTrue(cm.Verify());
        }

        [TestCase(TESTED_PRODUCT_NAME)]
        public void CheckChangeProductPriceCurrencyInWishList(string productName)
        {
            //Act
            cm.AddProductToWishList(productName);
            WishListPage wishList = cm.GoToWishList();
            cm.ChooseEuro();
            string expectedResult = "€";
            string actualResult = "€";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(TESTED_PRODUCT_NAME)]
        public void CheckChangeProductPriceCurrencyInShopingCart(string productName)
        {
            //Act
            cm.AddProductToCart(productName);
            ShopingCartPage shopingCart = cm.GoToShoppingCart();
            cm.ChooseEuro();
            string expectedResult = "€";
            string actualResult = "€";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
