using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Currency
{
    public sealed class CurrencyRepository
    {
        public volatile static CurrencyRepository instance;
        public static object lockObject = new object();

        private CurrencyRepository()
        {

        }

        public static CurrencyRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CurrencyRepository();

                    }
                }
            }
            return instance;
        }
    }
}

