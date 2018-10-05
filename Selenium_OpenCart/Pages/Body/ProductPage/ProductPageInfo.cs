using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public class ProductPageInfo : ProductPage
    {
        //
        protected IWebElement ReviewsLinkInNavigation
        {
            get
            {
                return driver.FindElement(By.XPath($".//div[@class='rating']//a[contains(text(), ' reviews')]"));
            }
        }

        protected IWebElement DescriptionLink
        {
            get
            {
                return driver.FindElement(By.XPath($".//ul[@class='nav nav-tabs']//a[contains(text(), 'Reviews')]"));
            }
        }
        //

        //
        public ProductPageInfo(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ReviewsLinkInNavigation;
            tmp = DescriptionLink;
        }
        //

        //Atomic operations for DescriptionLink
        public string GetTextFromDescriptionLink()
        {
            return this.DescriptionLink.Text;
        }

        public ProductPageDescription ClickOnDescriptionLink()
        {
            this.DescriptionLink.Click();
            return new ProductPageDescription(driver);
        }
        //

        //Atomic operations for ReviewsLink
        public string GetTextFromReviewsLink()
        {
            return this.ReviewsLinkInNavigation.Text;
        }

        public ProductPageReview ClickOnReviewsLink()
        {
            this.ReviewsLinkInNavigation.Click();
            return new ProductPageReview(driver);
        }
        //
    }
}
