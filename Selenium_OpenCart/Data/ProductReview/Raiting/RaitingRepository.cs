using System.Collections.Generic;
using System.ComponentModel;

namespace Selenium_OpenCart.Data.ProductReview.Rating
{
    public enum RatingList
    {
        None = 0,
        Rating1 = 1,
        Rating2 = 2,
        Rating3 = 3,
        Rating4 = 4,
        Rating5 = 5
    }


    public sealed class RatingRepository
    {
        public static Dictionary<RatingList, int> ListOfRating
        {
            get;
            private set;
        }

        static RatingRepository()
        {
            ListOfRating = new Dictionary<RatingList, int>()
            {
                { RatingList.Rating1, 1 },
                { RatingList.Rating2, 2 },
                { RatingList.Rating3, 3 },
                { RatingList.Rating4, 4 },
                { RatingList.Rating5, 5 }
            };
        }
    }

    public static class ExtentionMethods
    {
        public static RatingList ToRating(this int val)
        {
            return (val >=0  && val <= 5) ? (RatingList)val : RatingList.None;
        }

        public static int ToInt(this RatingList val)
        {
            return (int)val;
        }
    }
}
