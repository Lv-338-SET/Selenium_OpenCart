using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Search
{
    public sealed class SearchRepository
    {
        public volatile static SearchRepository instance;
        public static object lockObject = new object();

        private SearchRepository()
        {

        }

        public static SearchRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SearchRepository();

                    }
                }
            }
            return instance;
        }

        //public ISearch Valid()
        //{
        //    return Search.Get()
        //        .SetName("HP LP3065")
        //        .SetShortDescription("Stop your co-workers in their tracks with the stunning new 30-inch diagonal HP LP3065 Flat Panel Mon..")
        //        .Build();
        //}
    }
}
