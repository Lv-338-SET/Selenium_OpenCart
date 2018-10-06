using OpenQA.Selenium;

using Selenium_OpenCart.Logic;

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

        #region Atomic operations for ProductNameLabel
        public string GetProductNameText()
        {
            return this.ProductNameLablel.Text;
        }
        #endregion

        #region Atomic operations for WriteReviewLink
        public string GetWriteReviewLinkText()
        {
            return this.WriteRewiewLink.Text;
        }

        public ProductPageReviewMethods ClickWriteReviewLink()
        {
            this.WriteRewiewLink.Click();
            return new ProductPageReviewMethods(driver);
        }
        #endregion

        #region Atomic operations for ReviewsLink
        public string GetReviewsLinkText()
        {
            return this.ReviewsLink.Text;
        }

        public ProductPageReviewMethods ClickReviewsLink()
        {
            this.ReviewsLink.Click();
            return new ProductPageReviewMethods(driver);
        }
        #endregion

        #region Atomic operations for CpmpareProductButton
        public ProductPageSuccessfullyAddedProductForComparison ClickCompareProductButton()
        {
            this.CompareProductButton.Click();
            return new ProductPageSuccessfullyAddedProductForComparison(driver);
        }
        #endregion
    }
}
