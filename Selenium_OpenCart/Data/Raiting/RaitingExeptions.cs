using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Rating
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
        }

        public CountRatingExeption(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
