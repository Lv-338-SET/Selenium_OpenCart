using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Cart
{
    public class Cart : ICart, ICartBuilder, ISetID
    {
        private int ID;
        private int customer_id;
        private int session_id;
        private int product_id;
        private string date;
        
        private Cart()
        {

        }

        public ICart Build()
        {
            return this;
        }

        public static ISetID Get()
        {
            return new Cart();
        }

        public ICartBuilder SetID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ICartBuilder SetCustomerID(int customer_id)
        {
            this.customer_id = customer_id;
            return this;
        }

        public ICartBuilder SetSessionID(int session_id)
        {
            this.session_id = session_id;
            return this;
        }

        public ICartBuilder SetProductID(int product_id)
        {
            this.product_id = product_id;
            return this;
        }

        public ICartBuilder SetDate(string date)
        {
            this.date = date;
            return this;
        }

        public int GetCustomerID()
        {
            return customer_id;
        }

        public int GetSessionID()
        {
            return session_id;
        }

        public int GetProductID()
        {
            return product_id;
        }


        public string GetDate()
        {
            return date;
        }

        public int GetID()
        {
            return ID;
        }

    }

    public interface ICart
    {
        int GetCustomerID();
        int GetProductID();
        string GetDate();
        int GetID();
    }

    public interface ICartBuilder
    {
        ICartBuilder SetCustomerID(int customer_id);
        ICartBuilder SetProductID(int product_id);
        ICartBuilder SetDate(string date);

        ICart Build();
    }

    public interface ISetID
    {
        ICartBuilder SetID(int ID);
    }


}
