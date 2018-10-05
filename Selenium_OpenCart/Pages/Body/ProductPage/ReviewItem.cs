using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;


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
                return currnetReview.FindElement(By.XPath("//tr///td//strong"));
            }
        }

        private IWebElement ReviewDate
        {
            get
            {
                return currnetReview.FindElement(By.XPath("//tr//td[@class='text-right']"));
            }
        }

        private IWebElement ReviewText
        {
            get
            {
                return currnetReview.FindElement(By.XPath("//tr//td//p"));
            }
        }

        private List<IWebElement> Raiting
        {
            get
            {
                return currnetReview.FindElements(By.XPath("//tr//td//span")).ToList();
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
            //STARS COUNT
            if (tmp2.Count != 5)
            {
                //EXCEPTION
                throw new FormatException("Raiting don't have 5 radio boxes, it has " + tmp2.Count);
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
        public int? GetRaiting()
        {
            int? raiting = null;
            for (int i = 0; i < this.Raiting.Count; i++)
            {
                if (Raiting[i].FindElements(By.CssSelector("#fa fa-star fa-stack-2x")).Any())
                {
                    raiting = (i + 1);
                }
            }
            return raiting;
        }
        //
    }
}
