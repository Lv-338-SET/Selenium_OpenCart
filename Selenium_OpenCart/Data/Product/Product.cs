using Selenium_OpenCart.Data.Currency;

namespace Selenium_OpenCart.Data.Product
{
    public class Product : IProduct, IProductBuilder, ISetName
    {
        private string name;
        private string shortDescription;
        private string description;
        private byte[] image;
        private char currency;
        private double price;
        private double priceExTax;
        private int quantity;

        private Product()
        {

        }

        public IProduct Build()
        {
            return this;
        }

        public static ISetName Get()
        {
            return new Product();
        }

        public IProductBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public IProductBuilder SetShortDescription(string shortDescription)
        {
            this.shortDescription = shortDescription;
            return this;
        }

        public IProductBuilder SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IProductBuilder SetImage(byte[] image)
        {
            this.image = image;
            return this;
        }

        public IProductBuilder SetCurrency(CurrencyList currency)
        {
            this.currency = CurrencyRepository.CurrencyFullTextToSign[currency];
            return this;
        }

        public IProductBuilder SetPrice(double price)
        {
            this.price = price;
            return this;
        }

        public IProductBuilder SetPriceExTax(double priceExTax)
        {
            this.priceExTax = priceExTax;
            return this;
        }

        public IProductBuilder SetQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public string GetName()
        {
            return name;
        }

        public string GetShortDescription()
        {
            return shortDescription;
        }

        public string GetDescription()
        {
            return description;
        }

        public byte[] GetImage()
        {
            return image;
        }

        public char GetCurrency()
        {
            return currency;
        }

        public double GetPrice()
        {
            return price;
        }

        public double GetPriceExTax()
        {
            return priceExTax;
        }

        public int GetQuantity()
        {
            return quantity;
        }
    }

    public interface IProduct
    {
        string GetName();
        string GetShortDescription();
        string GetDescription();
        byte[] GetImage();
        char GetCurrency();
        double GetPrice();
        double GetPriceExTax();
        int GetQuantity();
    }

    public interface IProductBuilder
    {
        IProductBuilder SetShortDescription(string description);
        IProductBuilder SetDescription(string description);
        IProductBuilder SetImage(byte[] image);
        IProductBuilder SetCurrency(CurrencyList currency);
        IProductBuilder SetPrice(double price);
        IProductBuilder SetPriceExTax(double price);
        IProductBuilder SetQuantity(int quantity);
        IProduct Build();
    }

    public interface ISetName
    {
        IProductBuilder SetName(string name);
    }
}
