using System;

namespace Selenium_OpenCart.Data.ProductReview.Rating
{
    /// <summary>
    /// Exception that throws if number of found raiting starts not equal to raiting enum in test data
    /// </summary>
    public class CountRatingExeption : Exception
    {
        public CountRatingExeption()
        {
        }

        public CountRatingExeption(string message) : base(message)
        {
            if (message == null || message == String.Empty)
            {
                message = "Raiting starts not equal to raiting enum in test data. Must be " + RatingRepository.ListOfRating.Count;
            }
        }

        public CountRatingExeption(string message, Exception inner) : base(message, inner)
        {
            if (message == null || message == String.Empty)
            {
                message = "Raiting starts not equal to raiting enum in test data. Must be " + RatingRepository.ListOfRating.Count;
            }
        }
    }
}
