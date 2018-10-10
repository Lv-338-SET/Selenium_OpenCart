using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.AdminPageExeptions;

namespace Selenium_OpenCart.AdminPages.HeaderAndNavigation
{
    public class Header
    {
        protected IWebDriver driver;

        const string HOME_PAGE_CURNET_PAGE_LABLE = "Dashboard";

        #region Properties
        protected IWebElement CurnetPageLabel
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@id='content']//div[@class='page-header']//div[@class='container-fluid']//h1"));
            }
        }

        protected List<IWebElement> SiteMap
        {
            get
            {
                return driver.FindElements(By.XPath(".//div[@id='content']//div[@class='page-header']//div[@class='container-fluid']//ul[@class='breadcrumb']//a")).ToList();
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Header(IWebDriver driver)
        {
            this.driver = driver;
        }

        private void VerifyPage()
        {
            IWebElement tmp = CurnetPageLabel;
            List<IWebElement> tmp2 = SiteMap;
            if (!tmp.Text.Equals(tmp2.LastOrDefault().Text))
            {
                throw new BadSiteMap("Last element in site must be " + tmp.Text + " bu is " + tmp2.LastOrDefault().Text);
            }
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for CurnetPageLable
        public string GetTextFromCurnetPageLable()
        {
            return this.CurnetPageLabel.Text;
        }

        public bool IsHomePage()
        {
            return this.CurnetPageLabel.Text.Equals(HOME_PAGE_CURNET_PAGE_LABLE);
        }
        #endregion

        #region Atomic operations SiteMap
        public string GetTextFromFirstPageLink()
        {
            return this.SiteMap.FirstOrDefault().Text;
        }

        public string GetTextFromLastPageLink()
        {
            return this.SiteMap.LastOrDefault().Text;
        }

        public List<IWebElement> GetSiteMapList()
        {
            return this.SiteMap;
        }
        #endregion
        #endregion
    }
}
