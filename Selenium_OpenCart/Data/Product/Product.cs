using Selenium_OpenCart.Data.Currency;

namespace Selenium_OpenCart.Data.Product
{
    public class Product : IProduct, IProductBuilder, ISetName
    {
        private int ID;
        private string name;
        private string shortDescription;
        private string description;
        private string image;
        
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

        public IProductBuilder SetImage(string image)
        {
            this.image = image;
            return this;
        }

       

        public IProductBuilder SetPrice(double price)
        {
            this.price = price;
            return this;
        }

        public IProductBuilder SetID(int id)
        {
            this.ID = id;
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

        public string GetImage()
        {
            return image;
        }

      

        public double GetPrice()
        {
            return price;
        }

        public double GetID()
        {
            return ID;
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
        string GetImage();
        
        double GetPrice();
        double GetID();
        double GetPriceExTax();
        int GetQuantity();
    }

    public interface IProductBuilder
    {
        IProductBuilder SetShortDescription(string description);
        IProductBuilder SetQuantity(int quantity);
        IProductBuilder SetDescription(string description);
        IProductBuilder SetImage(string image);
        
        IProductBuilder SetPrice(double price);
        IProductBuilder SetID(int id);
        IProductBuilder SetPriceExTax(double price);
        
        IProduct Build();
    }

    public interface ISetName
    {
        IProductBuilder SetName(string name);
    }


}
