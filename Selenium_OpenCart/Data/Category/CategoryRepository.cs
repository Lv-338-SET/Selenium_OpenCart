using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Category
{
    public sealed class CategoryRepository
    {
        public volatile static CategoryRepository instance;
        public static object lockObject = new object();

        private CategoryRepository()
        {

        }

        public static CategoryRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CategoryRepository();

                    }
                }
            }
            return instance;
        }

        //public ICategory Valid()
        //{
        //    return Category.Get()
        //        .SetName("HP LP3065")
        //        .SetShortDescription("Stop your co-workers in their tracks with the stunning new 30-inch diagonal HP LP3065 Flat Panel Mon..")
        //        .Build();
        //}
    }
}
