using OpenQA.Selenium;

using Selenium_OpenCart.Logic.ProductPageLogic;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public class ProductPageInfo : ProductPage
    {
        #region Properties
        protected IWebElement ReviewsLinkInNavigation
        {
            get
            {
                return Search.ElementByXPath($".//div[@class='rating']//a[contains(text(), ' reviews')]");
            }
        }

        protected IWebElement DescriptionLink
        {
            get
            {
                return Search.ElementByXPath($".//ul[@class='nav nav-tabs']//a[contains(text(), 'Reviews')]");
            }
        }

        public ProductPageDescription ProductPageDescription
        {
            get
            {
                return new ProductPageDescription();
            }
        }

        public ProductPageReviewLogic ProductPageReview
        {
            get
            {
                return new ProductPageReviewLogic();
            }
        }
        #endregion

        #region Initialization and Verifycation
        public ProductPageInfo()
        {
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = ReviewsLinkInNavigation;
            tmp = DescriptionLink;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsProductPageInfo()
        {
            return VerifyPage();
        }

        #region Atomic operations for DescriptionLink
        public string GetTextFromDescriptionLink()
        {
            return DescriptionLink.Text;
        }

        /// <summary>
        /// Click on Description link in menu
        /// </summary>
        /// <returns>ProductPageDescription page</returns>
        public ProductPageDescription ClickOnDescriptionLink()
        {
            DescriptionLink.Click();
            return new ProductPageDescription();
        }
        #endregion

        #region Atomic operations for ReviewsLink
        public string GetTextFromReviewsLinkInMenu()
        {
            return ReviewsLinkInNavigation.Text;
        }

        /// <summary>
        /// Click on Review link in menu
        /// </summary>
        /// <returns>ProductPageReview page</returns>
        public ProductPageReview ClickOnReviewsLink()
        {
            ReviewsLinkInNavigation.Click();
            return new ProductPageReview();
        }
        #endregion
        #endregion
    }
}
