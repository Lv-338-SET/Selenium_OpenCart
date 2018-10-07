﻿using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.ProductReview.Rating;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ReviewItem : ProductPageReview
    {
        #region Properties
        private IWebElement currnetReview;

        private IWebElement ReviewerName
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td//strong"));
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td[@class='text-right']"));
            }
        }

        private IWebElement ReviewText
        {
            get
            {
                return currnetReview.FindElement(By.XPath(".//tr//td//p"));
            }
        }

        private List<IWebElement> Rating
        {
            get
            {
                return currnetReview.FindElements(By.XPath(".//tr//td//span")).ToList();
            }
        }
        #endregion

        #region Initialization And Verifycation
        public ReviewItem(IWebDriver driver, IWebElement currnetReview) : base(driver)
        {
            this.currnetReview = currnetReview;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = ReviewerName;
            tmp = ReviewDate;
            tmp = ReviewText;
            List<IWebElement> tmp2 = Rating;
            if (tmp2.Count != RatingRepository.ListOfRating.Count)
            {
                throw new CountRatingExeption("Rating don't have 5 stars, it has " + tmp2.Count);
            }
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for ReviewerName
        public string GetReviewerNameText()
        {
            return this.ReviewerName.Text;
        }
        #endregion

        #region Atomic operations for ReviewDate
        public string GetReviewDate()
        {
            return this.ReviewDate.Text;
        }
        #endregion

        #region Atomic operations for ReviewText
        public string GetReviewText()
        {
            return this.ReviewText.Text;
        }
        #endregion

        #region Atomic operations for Rating
        public RatingList GetRating()
        {
            int raiting = 0;
            for (int i = 0; i < this.Rating.Count; i++)
            {
                if (Rating[i].FindElements(By.XPath(".//i[@class='fa fa-star fa-stack-2x']")).Any())
                {
                    raiting = (i + 1);
                }
            }
            return raiting.ToRating();
        }
        #endregion
        #endregion

        #region overrided Methods and Operators
        public static bool operator ==(ReviewItem first, object second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(ReviewItem first, object second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IProductReview)
            {
                IProductReview productReview = obj as IProductReview;

                return (this.GetReviewerNameText().Equals(productReview.GetReviewerName())
                    && this.GetReviewDate().Equals(productReview.GetDate())
                    && this.GetReviewText().Equals(productReview.GetReviewText())
                    && this.GetRating().Equals(productReview.GetRating()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (this.GetReviewerNameText().Equals(productReview.GetReviewerNameText())
                    && this.GetReviewDate().Equals(productReview.GetReviewDate())
                    && this.GetReviewText().Equals(productReview.GetReviewText())
                    && this.GetRating().Equals(productReview.GetRating()));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return  (this.GetReviewerNameText() + " " + this.GetReviewText() + " " + this.GetRating() + " " + this.GetReviewDate()).GetHashCode();
        }
        #endregion
    }
}
