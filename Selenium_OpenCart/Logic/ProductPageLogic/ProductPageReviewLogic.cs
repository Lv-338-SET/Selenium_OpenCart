using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;

using Selenium_OpenCart.Pages.Body.ProductPage;
using Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts;

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

        /// <summary>
        /// Click, Clear and Input Text to Review Text Input on page
        /// Uses Fluent Interface so you can use page again
        /// </summary>
        /// <param name="productReview">Data that represents reveiw in IProduct Review fromat</param>
        /// <returns>ProductPageReviewLogic page</returns>
        public ProductPageReviewLogic ClickClearAndInputToReviewTextInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewInput();
            ProductPageReview.ClearReviewInput();
            ProductPageReview.InputTextToReviewInput(productReview);
            return this;
        }

        /// <summary>
        /// Click, Clear and Input Text to Reviewer Name Input on page
        /// Uses Fluent Interface so you can use page again
        /// </summary>
        /// <param name="productReview">Data that represents reveiw in IProduct Review fromat</param>
        /// <returns>ProductPageReviewLogic page</returns>
        public ProductPageReviewLogic ClickClearAndInputToReviewerNameInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewerNameInput();
            ProductPageReview.ClearReviewerNameInput();
            ProductPageReview.InputTextToReviewerNameInput(productReview);
            return this;
        }

        /// <summary>
        /// Click, Clear and Input Text to Reviewer Name Input on page
        /// Click, Clear and Input Text to Review Text Input on page
        /// Select rating
        /// Click on add review buuton
        /// </summary>
        /// <param name="productReview">Valid data that represents reveiw in IProduct Review fromat</param>
        /// <returns>SuccessfullyAddedReviewPage page</returns>
        public SuccessfullyAddedReviewPage InputValidReviewAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ClickClearAndInputToReviewTextInput(productReview);
            ProductPageReview.SelectRating(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new SuccessfullyAddedReviewPage(driver);
        }

        /// <summary>
        /// Click, Clear and Input Text to Reviewer Name Input on page
        /// Click, Clear and Input Text to Review Text Input on page
        /// Click on add review buuton
        /// </summary>
        /// <param name="productReview">Data that represents reveiw in IProduct Review fromat</param>
        /// <returns>UnsuccessfullyAddedReviewPage page</returns>
        public UnsuccessfullyAddedReviewPage InputReviewWithoutRatingAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ClickClearAndInputToReviewTextInput(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new UnsuccessfullyAddedReviewPage(driver);
        }

        /// <summary>
        /// Click, Clear and Input valid Text to Review Name Input on page
        /// Click, Clear and Input invalid Text to Review Text Input on page
        /// Select valid rating
        /// Click on add review buuton
        /// </summary>
        /// <param name="validReview">Valid data that represents reveiw in IProduct Review fromat</param>
        /// <param name="invalidReview">Invalid data that represents reveiw in IProduct Review fromat</param>
        /// <returns>UnsuccessfullyAddedReviewPage page</returns>
        public UnsuccessfullyAddedReviewPage InputReviewWithInvalidReviewTextAndClickOnAddReviewButton(IProductReview validReview, IProductReview invalidReview)
        {
            ClickClearAndInputToReviewerNameInput(validReview);
            ClickClearAndInputToReviewTextInput(invalidReview);
            ProductPageReview.SelectRating(validReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new UnsuccessfullyAddedReviewPage(driver);
        }

        /// <summary>
        /// Click, Clear and Input invalid Text to Review Name Input on page
        /// Click, Clear and Input valid Text to Review Text Input on page
        /// Select valid rating
        /// Click on add review buuton
        /// </summary>
        /// <param name="validReview">Valid data that represents reveiw in IProduct Review fromat</param>
        /// <param name="invalidReview">Invalid data that represents reveiw in IProduct Review fromat</param>
        /// <returns>UnsuccessfullyAddedReviewPage page</returns>
        public UnsuccessfullyAddedReviewPage InputReviewWithInvalidReviewerNameAndClickOnAddReviewButton(IProductReview validReview, IProductReview invalidReview)
        {
            ClickClearAndInputToReviewerNameInput(invalidReview);
            ClickClearAndInputToReviewTextInput(validReview);
            ProductPageReview.SelectRating(validReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new UnsuccessfullyAddedReviewPage(driver);
        }
    }
}
