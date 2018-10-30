using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.AdminLogic;
using Selenium_OpenCart.Data.AdminPageExeptions;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.AdminPages.HeaderAndNavigation
{
    public class Header : AdminPageLogic
    {
        #region Properties
        protected IWebElement CurnetPageLabel
        {
            get
            {
                return Search.ElementByXPath(".//div[@id='content']//div[@class='page-header']//div[@class='container-fluid']//h1");
            }
        }

        protected List<IWebElement> SiteMap
        {
            get
            {
                return Search.ElementsByXPath(".//div[@id='content']//div[@class='page-header']//div[@class='container-fluid']//ul[@class='breadcrumb']//a").ToList();
            }
        }
        #endregion

        #region Initialization And Verifycation
        public Header()
        {

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
