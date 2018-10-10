﻿using OpenQA.Selenium;

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

        //Fluent Interface
        public ProductPageReviewLogic ClickClearAndInputToReviewTextInput(IProductReview productReview)
        {
            ProductPageReview.ClickOnReviewInput();
            ProductPageReview.ClearReviewInput();
            ProductPageReview.InputTextToReviewInput(productReview);
            return this;
        }

        public SuccessfullyAddedReviewPage InputValidReviewAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ClickClearAndInputToReviewTextInput(productReview);
            ProductPageReview.SelectRating(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new SuccessfullyAddedReviewPage(driver);
        }

        public NotSelectedRatingAlertPage InputValidReviewButNotSelectRatingAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ClickClearAndInputToReviewTextInput(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new NotSelectedRatingAlertPage(driver);
        }

        public InvalidReviewTextAlertPage InputValidReviewerNameAndSelectRatingAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewerNameInput(productReview);
            ProductPageReview.SelectRating(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new InvalidReviewTextAlertPage(driver);
        }

        public InvalidReviewerNameAlertPage InputValidReviewTextAndSelectRatingAndClickOnAddReviewButton(IProductReview productReview)
        {
            ClickClearAndInputToReviewTextInput(productReview);
            ProductPageReview.SelectRating(productReview);
            ProductPageReview.ClickOnAddReviewButton();
            return new InvalidReviewerNameAlertPage(driver);
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
