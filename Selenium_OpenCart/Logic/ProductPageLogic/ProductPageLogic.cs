using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.ProductPage;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Logic.ProductPageLogic
{
    public class ProductPageLogic
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        public ProductPage ProductPage
        {
            get
            {
                return new ProductPage();
            }
        }

        public ProductPageInfo ProductPageInfo
        {
            get
            {
                return new ProductPageInfo();
            }
        }

        public ProductPageLogic()
        {
            
        }
    }
}
