using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Selenium_OpenCart.Data.Login
{
    public class Login : ILoginBuilder, ILogin, ISetApiToken
    {
        private string message;
        private string api_token;

        private Login()
        {

        }

        public ILogin Build()
        {
            return this;
        }

        public static ISetApiToken Get()
        {
            return new Login();
        }

        public ILoginBuilder SetApiToken(string api_token) {
            this.api_token = api_token;
            return this;
        }

        public ILoginBuilder SetMessage(string message)
        {
            this.message = message;
            return this;
        }

        public string GetApiToken()
        {
            return this.api_token;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }

    public interface ILoginBuilder
    {
        ILoginBuilder SetMessage(string message);
        ILogin Build();
    }

    public interface ILogin
    {
        string GetApiToken();
        string GetMessage();
    }

    public interface ISetApiToken
    {
        ILoginBuilder SetApiToken(string api_token);
    }

}