using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Cart
{
    public sealed class CartRepository
    {
        public volatile static CartRepository instance;
        public static object lockObject = new object();

        private CartRepository()
        {

        }

        public static CartRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CartRepository();
                    }
                }
            }
            return instance;
        }

        //public ICart Valid()
        //{
        //    return Cart.Get()
        //    .SetProductName("HP LP3065")
        //    .SetReviewerName("Volodymyr Matsko")
        //    .SetReviewText("Some review to smoke test of reviews")
        //    .SetRaiting(1.ToRaiting())
        //    .SetDate(DateTime.Now.ToString(@"dd\/MM\/yyyy"))
        //    .Build();
        //}
    }
}
