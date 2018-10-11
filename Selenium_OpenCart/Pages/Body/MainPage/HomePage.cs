using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_OpenCart.Pages.Body.SearchPage;
using Selenium_OpenCart.Pages.Body.MainPage;

using Selenium_OpenCart.Tools;
namespace Selenium_OpenCart.Pages.Body.MainPage
{
    public class HomePage
    {
        protected IWebElement UpHorizontalCarousel { get { return Application.Get().Search.ElementById("slideshow0"); } }
        protected IWebElement DownHorizontalCarousel { get { return Application.Get().Search.ElementById("carousel0"); } }
        protected List<ProductItemFromHomePage> ListProductFromMainPage => InitializeListProductFromMainPage(Application.Get().Search.ElementsByClassName("product-layout"));

        private bool Initialize()
        {
            IWebElement element = UpHorizontalCarousel;
            element = DownHorizontalCarousel;
            var listP = ListProductFromMainPage;
            return true;
        }

        public List<ProductItemFromHomePage> InitializeListProductFromMainPage(IReadOnlyCollection<IWebElement> elements)
        {
            List<ProductItemFromHomePage> list = new List<ProductItemFromHomePage>();

            foreach (var current in elements)
            {
                list.Add(new ProductItemFromHomePage(Application.Get().Browser.Driver,current));
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
