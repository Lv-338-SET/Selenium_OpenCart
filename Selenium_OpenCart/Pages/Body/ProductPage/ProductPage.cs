using OpenQA.Selenium;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Logic.ProductPageLogic;

using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public class ProductPage : Header.Header
    {
        #region Properties
        protected IWebElement ProductNameLablel
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@id='content']//h1"));
            }
        }

        protected IWebElement WriteRewiewLink
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='rating']//a[text() = 'Write a review']"));
            }
        }

        protected IWebElement ReviewsLink
        {
            get
            {
                return driver.FindElement(By.XPath(".//div[@class='rating']//a[contains(text(),' reviews')]"));
            }
        }

        protected IWebElement CompareProductButton
        {
            get
            {
                return driver.FindElement(By.XPath(".//button[contains(@onclick,'compare.add')]"));
            }
        }

        public ProductPageInfo ProductPageInfo
        {
            get
            {
                return new ProductPageInfo(driver);
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ProductPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private bool VerifyPage()
        {
            IWebElement tmp = ProductNameLablel;
            tmp = WriteRewiewLink;
            tmp = ReviewsLink;
            tmp = CompareProductButton;
            return true;
        }
        #endregion

        #region Atomic operations
        public bool IsProductPage()
        {
            return VerifyPage();
        }

        #region Atomic operations for ProductNameLabel
        public string GetTextFromProductName()
        {
            return ProductNameLablel.Text;
        }

        /// <summary>
        /// Check is it product page of specific product
        /// </summary>
        /// <param name="productReview">Produc review in IProductReview format</param>
        /// <returns>True if product name equals and false if not</returns>
        public bool IsProductPageOf(IProductReview productReview)
        {
            return GetTextFromProductName().Equals(productReview.GetProductName());
        }
        #endregion

        #region Atomic operations for WriteReviewLink
        public string GetTextFromWriteReviewLink()
        {
            return WriteRewiewLink.Text;
        }

        /// <summary>
        /// Click on write review link
        /// </summary>
        /// <returns>ProductPageReviewLogic page</returns>
        public ProductPageReviewLogic ClickWriteReviewLink()
        {
            WriteRewiewLink.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for ReviewsLink
        public string GetTextFromReviewsLink()
        {
            return ReviewsLink.Text;
        }

        /// <summary>
        /// Click on Reviews
        /// </summary>
        /// <returns>ProductPageReviewLogic page</returns>
        public ProductPageReviewLogic ClickReviewsLink()
        {
            ReviewsLink.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for CompareProductButton
        /// <summary>
        /// Click on compare product button
        /// </summary>
        /// <returns>SuccessfullyAddedProductForComparisonPage page</returns>
        public SuccessfullyAddedProductForComparisonPage ClickOnCompareProductButton()
        {
            CompareProductButton.Click();
            return new SuccessfullyAddedProductForComparisonPage(driver);
        }
        #endregion
        #endregion
    }
}
