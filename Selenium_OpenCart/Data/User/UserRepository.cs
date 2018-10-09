
namespace Selenium_OpenCart.Data.User
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static readonly object lockObject = new object();

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
                .SetFirstName("John")
                .SetLastName("Doe")
                .Build();
        }

        public IUser AdminDefault()
        {
            return User.Get()
                .SetUsername("admin")
                .SetPassword("admin")
                .SetFirstName("admin")
                .SetLastName("admin")
                .Build();
        }
    }
}
