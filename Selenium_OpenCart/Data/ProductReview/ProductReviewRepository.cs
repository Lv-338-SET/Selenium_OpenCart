using System;
using Selenium_OpenCart.Data.ProductReview.Rating;

namespace Selenium_OpenCart.Data.ProductReview
{
    public sealed class ProductReviewRepository
    {
        private volatile static ProductReviewRepository instance;
        private static readonly object lockObject = new object();

        private ProductReviewRepository()
        {

        }

        public static ProductReviewRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ProductReviewRepository();
                    }
                }
            }
            return instance;
        }

        public IProductReview ValidHP()
        {
            return ProductReview.Get()
            .SetProductName("HP LP3065")
            .SetReviewerName("Volodymyr Matsko")
            .SetReviewText("Some review to smoke test of reviews")
            .SetRating(1.ToRating())
            .SetDate(DateTime.Now.ToString(@"dd\/MM\/yyyy"))
            .Build();
        }

        public IProductReview ValidMac()
        {
            return ProductReview.Get()
            .SetProductName("MacBook")
            .SetReviewerName("Volodymyr Matsko")
            .SetReviewText("Some review to smoke test of reviews")
            .SetRating(1.ToRating())
            .SetDate(DateTime.Now.ToString(@"dd\/MM\/yyyy"))
            .Build();
        }
    }
}
