using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Pages.Body.MainPage
{
    public class HomePage
    {
        private IWebDriver driver;
        protected IWebElement UpHorizontalCarousel { get { return driver.FindElement(By.Id("slideshow0")); } }
        protected IWebElement DownHorizontalCarousel { get { return driver.FindElement(By.Id("carousel0")); } }
        protected List<ProductItemFromHomePage> ListProductFromMainPage => InitializeListProductFromMainPage(driver.FindElements(By.ClassName("product-layout")));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        private void Initialize()
        {
            IWebElement element = UpHorizontalCarousel;
            element = DownHorizontalCarousel;

            var listP = ListProductFromMainPage;
        }

        public List<ProductItemFromHomePage> InitializeListProductFromMainPage(IReadOnlyCollection<IWebElement> elements)
        {
            List<ProductItemFromHomePage> list = new List<ProductItemFromHomePage>();

            foreach (var current in elements)
            {
                list.Add(new ProductItemFromHomePage(driver, current));
            }
            return list;
        }

        public List<ProductItemFromHomePage> GetListProduct()
        {
            return ListProductFromMainPage;
        }

        public ProductItemFromHomePage FindAppropriateProduct(string product)
        {
            foreach (var item in ListProductFromMainPage)
            {
                if (item.IsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
