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

        private void VerifyPage()
        {
            IWebElement tmp = ProductNameLablel;
            tmp = WriteRewiewLink;
            tmp = ReviewsLink;
            tmp = CompareProductButton;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for ProductNameLabel
        public string GetProductNameText()
        {
            return this.ProductNameLablel.Text;
        }

        public bool IsProductPageOf(IProductReview productReview)
        {
            return GetProductNameText().Equals(productReview.GetProductName());
        }
        #endregion

        #region Atomic operations for WriteReviewLink
        public string GetWriteReviewLinkText()
        {
            return this.WriteRewiewLink.Text;
        }

        public ProductPageReviewLogic ClickWriteReviewLink()
        {
            this.WriteRewiewLink.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for ReviewsLink
        public string GetReviewsLinkText()
        {
            return this.ReviewsLink.Text;
        }

        public ProductPageReviewLogic ClickReviewsLink()
        {
            this.ReviewsLink.Click();
            return new ProductPageReviewLogic(driver);
        }
        #endregion

        #region Atomic operations for CompareProductButton
        public SuccessfullyAddedProductForComparisonPage ClickCompareProductButton()
        {
            this.CompareProductButton.Click();
            return new SuccessfullyAddedProductForComparisonPage(driver);
        }
        #endregion
        #endregion
    }
}
