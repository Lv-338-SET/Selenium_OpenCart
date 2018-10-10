using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;

using Selenium_OpenCart.Pages.Body.ProductPage;

namespace Selenium_OpenCart.Logic.ProductPageLogic
{
    public class ProductPageReviewLogic : ProductPageLogic
    {
        public ProductPageReview ProductPageReview
        {
            get
            {
                return new ProductPageReview(driver);                
            }
            private set
            {
            }
        }

        public ProductPageReviewLogic(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //Fluent Interface
        public ProductPageReviewLogic ClickClearAndInputToReviewInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewInput();
            ProductPageReview.ClearReviewInput();
            ProductPageReview.InputTextToReviewInput(productReview);
            return this;
        }

        public ProductPageSuccessfullyAddedReview InputValidReviewAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ClickClearAndInputToReviewInput(productReview);
            ProductPageReview.SelectRating(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new ProductPageSuccessfullyAddedReview(driver);
        }

        //Fluent Interface
        public ProductPageReviewLogic ClickClearAndInputToReviewerNameInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewerNameInput();
            ProductPageReview.ClearReviewerNameInput();
            ProductPageReview.InputTextToReviewerNameInput(productReview);
            return this;
        }
    }
}
