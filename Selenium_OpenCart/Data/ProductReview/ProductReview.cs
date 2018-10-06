using Selenium_OpenCart.Data.Rating;

namespace Selenium_OpenCart.Data.ProductReview
{
    public class ProductReview : IProductReview, IProductReviewBuilder, ISetProductName, ISetReviewerName, ISetReviewText, ISetRating, ISetDate
    {
        private string productName;
        private string reviewerName;
        private string reviewText;
        private RatingList raiting;
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

        public ISetRating SetReviewText(string reviewText)
        {
            this.reviewText = reviewText;
            return this;
        }

        public ISetDate SetRating(RatingList raiting)
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

        public RatingList GetRating()
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
        RatingList GetRating();
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
        ISetRating SetReviewText(string reviewText);
    }

    public interface ISetRating
    {
        ISetDate SetRating(RatingList raiting);
    }

    public interface ISetDate
    {
        IProductReviewBuilder SetDate(string data);
    }
}
