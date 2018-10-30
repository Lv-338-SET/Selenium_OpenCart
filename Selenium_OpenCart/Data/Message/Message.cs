using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Message
{
    public class Message : IMessageBuilder, IMessage, ISetMessage
    {
        private string message;
        private string status;

        private Message()
        {

        }

        public IMessage Build()
        {
            return this;
        }

        public static ISetMessage Get()
        {
            return new Message();
        }

        public IMessageBuilder SetStatus(string status)
        {
            this.status = status;
            return this;
        }

        public IMessageBuilder SetMessage(string message)
        {
            this.message = message;
            return this;
        }

        public string GetStatus()
        {
            return this.status;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }

    public interface IMessageBuilder
    {
        IMessageBuilder SetMessage(string message);
        IMessage Build();
    }

    public interface IMessage
    {
        string GetStatus();
        string GetMessage();
    }

    public interface ISetMessage
    {
        IMessageBuilder SetMessage(string message);
    }

}