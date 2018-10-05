using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.User
{
    public class User : IUserBuilder, IUser, ISetUserName, ISetPassword
    {
        private string username;
        private string password;

        private User()
        {

        }

        public IUser Build()
        {
            return this;
        }

        public static ISetUserName Get()
        {
            return new User();
        }

        public ISetPassword SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        public IUserBuilder SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public string GetPassword()
        {
            return this.password;
        }
    }

    public interface IUserBuilder
    {
        IUser Build();
    }

    public interface IUser
    {
        string GetUsername();
        string GetPassword();
    }

    public interface ISetUserName
    {
        ISetPassword SetUsername(string username);
    }

    public interface ISetPassword
    {
        IUserBuilder SetPassword(string password);
    }
}
