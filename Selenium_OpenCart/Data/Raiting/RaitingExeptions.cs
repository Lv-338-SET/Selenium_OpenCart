using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Raiting
{
    /// <summary>
    /// Exception that throws if number of found raiting starts not equal to raiting enum in test data
    /// </summary>
    public class CountRaitingExeption : Exception
    {
        public CountRaitingExeption()
        {
        }

        public CountRaitingExeption(string message) : base(message)
        {
        }

        public CountRaitingExeption(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
