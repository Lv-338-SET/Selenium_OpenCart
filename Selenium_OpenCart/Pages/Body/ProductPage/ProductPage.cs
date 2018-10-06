using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    //header
    public class ProductPage
    {
        protected IWebDriver driver;
        //
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

        protected IWebElement CompareProductButoon
        {
            get
            {
                return driver.FindElement(By.XPath(".//button[contains(@onclick,'compare.add')]"));
            }
        }
        //

        //
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ProductNameLablel;
            tmp = WriteRewiewLink;
            tmp = ReviewsLink;
            tmp = CompareProductButoon;
        }

        //Atomic operations for ProductNameLabel
        public string GetProductNameText()
        {
            return this.ProductNameLablel.Text;
        }
        //

        //Atomic operations for WriteReviewLink
        public string GetWriteReviewLinkText()
        {
            return this.WriteRewiewLink.Text;
        }

        public ProductPageReview ClickWriteReviewLink()
        {
            this.WriteRewiewLink.Click();
            return new ProductPageReview(driver);
        }
        //

        //Atomic operations for ReviewsLink
        public string GetReviewsLinkText()
        {
            return this.ReviewsLink.Text;
        }

        public ProductPageReview ClickReviewsLink()
        {
            this.ReviewsLink.Click();
            return new ProductPageReview(driver);
        }
        //

        //Atomic operations for CpmpareProductButton
        public ProductPageSuccessfullyAddedProductForComparison ClickCompareProductButton()
        {
            this.CompareProductButoon.Click();
            return new ProductPageSuccessfullyAddedProductForComparison(driver);
        }
    }
}
