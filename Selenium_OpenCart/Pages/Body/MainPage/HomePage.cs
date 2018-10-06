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
        protected List<ProductItem> ListProduct { get { return InitializeListProductFromMainPage(driver.FindElements(By.ClassName("product-layout"))); } }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        private void Initialize()
        {
            IWebElement element = UpHorizontalCarousel;
            element = DownHorizontalCarousel;

            var listP = ListProduct;
        }

        public List<ProductItem> InitializeListProductFromMainPage(IReadOnlyCollection<IWebElement> elements)
        {
            List<ProductItem> list = new List<ProductItem>();

            foreach (var current in elements)
            {
                list.Add(new ProductItem(driver, current));
            }
            return list;
        }

        public List<ProductItem> GetListProduct()
        {
            return ListProduct;
        }
    }
}
