
namespace Selenium_OpenCart.Data.ProductReview
{
    public class ProductReview : IProductReview, IProductReviewBuilder, ISetProductName, ISetReviewerName, ISetReviewText, ISetRaiting, ISetDate
    {
        private string productName;
        private string reviewerName;
        private string reviewText;
        private int raiting;
        private string date;

        private ProductReview()
        {

        }

        public IProductReview Build()
        {
            return this;
        }

        public static ISetProductName Get()
        {
            return new ProductReview();
        }

        public ISetReviewerName SetProductName(string productName)
        {
            this.productName = productName;
            return this;
        }

        public ISetReviewText SetReviewerName(string reviewerName)
        {
            this.reviewerName = reviewerName;
            return this;
        }

        public ISetRaiting SetReviewText(string reviewText)
        {
            this.reviewText = reviewText;
            return this;
        }

        public ISetDate SetRaiting(int raiting)
        {
            this.raiting = raiting;
            return this;
        }

        public IProductReviewBuilder SetDate(string date)
        {
            this.date = date;
            return this;
        }

        public string GetProductName()
        {
            return this.productName;
        }

        public string GetReviewerName()
        {
            return this.reviewerName;
        }

        public string GetReviewText()
        {
            return this.reviewText;
        }

        public int GetRaiting()
        {
            return this.raiting;
        }

        public string GetDate()
        {
            return this.date;
        }
    }

    public interface IProductReview
    {
        string GetProductName();
        string GetReviewerName();
        string GetReviewText();
        int GetRaiting();
        string GetDate();
    }

    public interface IProductReviewBuilder
    {
        IProductReview Build();
    }

    public interface ISetProductName
    {
        ISetReviewerName SetProductName(string productName);
    }

    public interface ISetReviewerName
    {
        ISetReviewText SetReviewerName(string reviewerName);
    }

    public interface ISetReviewText
    {
        ISetRaiting SetReviewText(string reviewText);
    }

    public interface ISetRaiting
    {
        ISetDate SetRaiting(int raiting);
    }

    public interface ISetDate
    {
        IProductReviewBuilder SetDate(string data);
    }
}
