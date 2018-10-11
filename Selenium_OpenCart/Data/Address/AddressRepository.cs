using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Address
{
    public sealed class AddressRepository
    {
        public volatile static AddressRepository instance;
        public static object lockObject = new object();

        private AddressRepository()
        {

        }

        public static AddressRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new AddressRepository();
                    }
                }
            }
            return instance;
        }

    }
}
