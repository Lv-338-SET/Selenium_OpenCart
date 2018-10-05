using System;

namespace Selenium_OpenCart.Data.ProductReview
{
    public sealed class ProductReviewRepository
    {
        public volatile static ProductReviewRepository instance;
        public static object lockObject = new object();

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

        public IProductReview Valid()
        {
            return ProductReview.Get()
            .SetProductName("HP LP3065")
            .SetReviewerName("Volodymyr Matsko")
            .SetReviewText("Some review to smoke test of reviews")
            .SetRaiting(1)
            .SetDate(DateTime.Now.ToString("dd/MM/YYYY"))
            .Build();
        }
    }
}
