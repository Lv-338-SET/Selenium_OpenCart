using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.Raiting;

namespace Selenium_OpenCart.Pages.Body.ProductPage
{
    public sealed class ReviewItem : ProductPageReview
    {
        //
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

        private List<IWebElement> Raiting
        {
            get
            {
                return currnetReview.FindElements(By.XPath(".//tr//td//span")).ToList();
            }
        }
        //

        //
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
            List<IWebElement> tmp2 = Raiting;
            if (tmp2.Count != RaitingRepository.ListOfRaiting.Count)
            {
                throw new CountRaitingExeption("Raiting don't have 5 stars, it has " + tmp2.Count);
            }
        }
        //

        //Atomic for ReviewerName
        public string GetReviewerNameText()
        {
            return this.ReviewerName.Text;
        }
        //

        //Atomic for ReviewDate
        public string GetReviewDate()
        {
            return this.ReviewDate.Text;
        }
        //

        //Atomic for ReviewText
        public string GetReviewText()
        {
            return this.ReviewText.Text;
        }
        //

        //Atomic for Raiting
        public RaitingList GetRaiting()
        {
            int raiting = 0;
            for (int i = 0; i < this.Raiting.Count; i++)
            {
                if (Raiting[i].FindElements(By.XPath(".//i[@class='fa fa-star fa-stack-2x']")).Any())
                {
                    raiting = (i + 1);
                }
            }
            return raiting.ToRaiting();
        }
        //

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
                    && this.GetRaiting().Equals(productReview.GetRaiting()));
            }
            else if (obj is ReviewItem)
            {
                ReviewItem productReview = obj as ReviewItem;

                return (this.GetReviewerNameText().Equals(productReview.GetReviewerNameText())
                    && this.GetReviewDate().Equals(productReview.GetReviewDate())
                    && this.GetReviewText().Equals(productReview.GetReviewText())
                    && this.GetRaiting().Equals(productReview.GetRaiting()));
            }
            else
            {
                return false;
            }
        }
    }
}
