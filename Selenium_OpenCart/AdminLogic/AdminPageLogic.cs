using Selenium_OpenCart.AdminPages.HeaderAndNavigation;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.AdminLogic
{
    public class AdminPageLogic
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        public Header Header
        {
            get
            {
                return new Header();
            }
        }

        public Navigation Navigation
        {
            get
            {
                return new Navigation();
            }
        }

        public AdminPageLogic()
        {

        }
    }
}
