using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.AdminPageExeptions;

namespace Selenium_OpenCart.AdminPages.HeaderAndNavigation
{
    public class Header
    {
        protected IWebDriver driver;

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

        private bool VerifyPage()
        {
            IWebElement tmp = CurnetPageLabel;
            List<IWebElement> tmp2 = SiteMap;
            if (!tmp.Text.Equals(tmp2.LastOrDefault().Text))
            {
                throw new BadSiteMap("Last element in site must be " + tmp.Text + " bu is " + tmp2.LastOrDefault().Text);
            }
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsHeader()
        {
            return VerifyPage();
        }

        #region Atomic operations for CurnetPageLable
        /// <summary>
        /// Gets curnet page name from header. Equals with last link from SiteMat
        /// </summary>
        /// <returns>Curnet page name from header</returns>
        public string GetTextFromCurnetPageLable()
        {
            return CurnetPageLabel.Text;
        }
        #endregion

        #region Atomic operations SiteMap
        public string GetTextFromFirstPageLink()
        {
            return SiteMap.FirstOrDefault().Text;
        }

        public string GetTextFromLastPageLink()
        {
            return SiteMap.LastOrDefault().Text;
        }

        /// <summary>
        /// Gets all links from header site map
        /// </summary>
        /// <returns>List<IWebElement> with all page links from header</returns>
        public List<IWebElement> GetSiteMapList()
        {
            return SiteMap;
        }
        #endregion
        #endregion
    }
}
