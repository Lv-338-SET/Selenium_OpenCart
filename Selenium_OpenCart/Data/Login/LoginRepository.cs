using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Login
{
    public sealed class LoginRepository
    {
        public volatile static LoginRepository instance;
        public static object lockObject = new object();

        private LoginRepository()
        {

        }

        public static LoginRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new LoginRepository();
                    }
                }
            }
            return instance;
        }
    }
}
