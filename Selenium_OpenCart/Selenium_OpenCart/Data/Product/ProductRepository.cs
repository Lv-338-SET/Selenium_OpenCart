
namespace Selenium_OpenCart.Data.Product
{
    public sealed class ProductRepository
    {
        public volatile static ProductRepository instance;
        public static object lockObject = new object();

        private ProductRepository()
        {

        }

        public static ProductRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ProductRepository();
                        
                    }
                }
            }
            return instance;
        }

        public IProduct Valid()
        {
            return Product.Get()
                .SetName("HP LP3065")
                .SetShortDescription("Stop your co-workers in their tracks with the stunning new 30-inch diagonal HP LP3065 Flat Panel Mon..")
                .Build();
        }
    }
}
