using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Data.Message;

namespace Selenium_OpenCart.Data.Order
{
    public class Order : IOrderBuilder, IOrder, ISetOrderID
    {
        private string order_id;
        private IMessage status;

        private Order()
        {

        }

        public IOrder Build()
        {
            return this;
        }

        public static ISetOrderID Get()
        {
            return new Order();
        }

        public IOrderBuilder SetMessage(IMessage status)
        {
            this.status = status;
            return this;
        }

        public IOrderBuilder SetOrderID(string order_id)
        {
            this.order_id = order_id;
            return this;
        }

        public IMessage GetMessage()
        {
            return this.status;
        }

        public string GetOrderID()
        {
            return this.order_id;
        }
    }

    public interface IOrderBuilder
    {
        IOrderBuilder SetOrderID(string order_id);
        IOrderBuilder SetMessage(IMessage message);
        IOrder Build();
    }

    public interface IOrder
    {
        IMessage GetMessage();
        string GetOrderID();
    }

    public interface ISetOrderID
    {
        IOrderBuilder SetOrderID(string order_id);
    }

}