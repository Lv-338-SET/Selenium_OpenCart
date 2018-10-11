using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Currency
{
    public class Currency : ICurrency, ICurrencyBuilder, ISetValue
    {
        private int ID;
        private string title;
        private string code;
        private double value;

        private Currency()
        {

        }

        public ICurrency Build()
        {
            return this;
        }

        public static ISetValue Get()
        {
            return new Currency();
        }

        public ICurrencyBuilder SetValue(double value)
        {
            this.value = value;
            return this;
        }

        public ICurrencyBuilder SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public ICurrencyBuilder SetID(int id)
        {
            this.ID = id;
            return this;
        }

        public ICurrencyBuilder SetCode(string code)
        {
            this.code = code;
            return this;
        }

        public double GetValue()
        {
            return value;
        }


        public int GetID()
        {
            return ID;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetCode()
        {
            return code;
        }

    }

    public interface ICurrency
    {
        double GetValue();
        int GetID();
        string GetTitle();
        string GetCode();
    }

    public interface ICurrencyBuilder
    {
        ICurrencyBuilder SetTitle(string title);
        ICurrencyBuilder SetID(int id);
        ICurrencyBuilder SetCode(string code);

        ICurrency Build();
    }

    public interface ISetValue
    {
        ICurrencyBuilder SetValue(double value);
    }


}
