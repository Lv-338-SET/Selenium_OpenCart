
namespace Selenium_OpenCart.Data.Product
{
    public class Product : IProduct, IProductBuider, ISetName
    {
        private string name;
        private string description;
        private byte[] image;

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

        public IProductBuider SetName(string name)
        {
            this.name = name;
            return this;
        }

        public IProductBuider SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IProductBuider SetImage(byte[] image)
        {
            this.image = image;
            return this;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }

        public byte[] GetImage()
        {
            return image;
        }
    }

    public interface IProduct
    {
        string GetName();
        string GetDescription();
        byte[] GetImage();
    }

    public interface IProductBuider
    {
        IProductBuider SetDescription(string description);
        IProductBuider SetImage(byte[] image);
        IProduct Build();
    }

    public interface ISetName
    {
        IProductBuider SetName(string name);
    }
}
