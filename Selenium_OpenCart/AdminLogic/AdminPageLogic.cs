using OpenQA.Selenium;

using Selenium_OpenCart.AdminPages.HeaderAndNavigation;

namespace Selenium_OpenCart.AdminLogic
{
    public class AdminPageLogic
    {
        protected IWebDriver driver;

        public Header Header
        {
            get
            {
                return new Header(driver);
            }
        }

        public Navigation Navigation
        {
            get
            {
                return new Navigation(driver);
            }
        }

        public AdminPageLogic(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
