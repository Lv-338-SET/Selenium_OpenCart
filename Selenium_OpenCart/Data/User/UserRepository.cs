using System;

namespace Selenium_OpenCart.Data.User
{
    public sealed class UserRepository
    {
        public volatile static UserRepository instance;
        public static object lockObject = new object();

        private UserRepository()
        {

        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
                .SetUsername("admin")
                .SetPassword("setadmin")
                .Build();
        }
    }
}
