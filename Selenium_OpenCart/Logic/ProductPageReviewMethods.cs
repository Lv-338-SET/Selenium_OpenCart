using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.Rating;

using Selenium_OpenCart.Pages.Body.ProductPage;

namespace Selenium_OpenCart.Logic
{
    public class ProductPageReviewMethods
    {
        private IWebDriver driver;

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

        public ProductPageReviewMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Fluent Interface
        public ProductPageReview ClickClearAndInputToReviewInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewInput();
            ProductPageReview.ClearReviewInput();
            ProductPageReview.InputTextToReviewInput(productReview);
            return ProductPageReview;
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
        public ProductPageReview ClickClearAndInputToReviewerNameInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewerNameInput();
            ProductPageReview.ClearReviewerNameInput();
            ProductPageReview.InputTextToReviewerNameInput(productReview);
            return ProductPageReview;
        }
    }
}
