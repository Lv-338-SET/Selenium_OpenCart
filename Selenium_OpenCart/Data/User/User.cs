using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.User
{
    public class User : IUserBuilder, IUser, ISetUserName, ISetPassword, ISetSault
    {
        private int ID;
        private string username;
        private string password;
        private string sault;

        private string firstName;
        private string lastName;
        private string email;
        private string telephone;
        private bool subscribe;

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

        public IUserBuilder SetID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public IUserBuilder SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public IUserBuilder SetSault(string sault)
        {
            this.sault = sault;
            return this;
        }

        public IUserBuilder SetFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public IUserBuilder SetLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public IUserBuilder SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IUserBuilder SetTelephone(string telephone)
        {
            this.telephone = telephone;
            return this;
        }

        public IUserBuilder SetSubscribe(bool subscribe)
        {
            this.subscribe = subscribe;
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
        public string GetSault()
        {
            return this.sault;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public int GetID()
        {
            return this.ID;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string GetTelephone()
        {
            return this.telephone;
        }

        public bool GetSubscribe()
        {
            return this.subscribe;
        }
    }

    public interface IUserBuilder
    {
        IUserBuilder SetFirstName(string firstName);
        IUserBuilder SetLastName(string lastName);
        IUserBuilder SetSault(string sault);
        IUserBuilder SetEmail(string email);
        IUserBuilder SetID(int ID);
        IUserBuilder SetTelephone(string phone);
        IUserBuilder SetSubscribe(bool subscribe);
        IUser Build();
    }

    public interface IUser
    {
        int GetID();
        string GetUsername();
        string GetPassword();
        string GetSault();
        string GetFirstName();
        string GetLastName();
        string GetEmail();
        string GetTelephone();
        bool GetSubscribe();
    }

    public interface ISetUserName
    {
        ISetPassword SetUsername(string username);
    }

    public interface ISetID
    {
        IUserBuilder SetID(int ID);
    }

    public interface ISetPassword
    {
        IUserBuilder SetPassword(string password);
    }

    public interface ISetSault
    {
        IUserBuilder SetSault(string sault);
    }
}
