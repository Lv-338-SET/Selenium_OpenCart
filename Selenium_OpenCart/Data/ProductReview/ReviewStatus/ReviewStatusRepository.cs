using System;
using System.Collections.Generic;

namespace Selenium_OpenCart.Data.ProductReview.ReviewStatus
{
    public enum ReviewStatusList
    {
        None,
        Enabled,
        Disabled
    }

    public sealed class ReviewsStatusRepository
    {
        public static Dictionary<ReviewStatusList, string> ListOfReviewStatus
        {
            get;
            private set;
        }

        static ReviewsStatusRepository()
        {
            ListOfReviewStatus = new Dictionary<ReviewStatusList, string>()
            {
                { ReviewStatusList.Enabled, "enabled" },
                { ReviewStatusList.Disabled, "disabled" }
            };
        }
    }

    public static class ExtentionMethods
    {
        public static ReviewStatusList ToReviewStatus(this string var)
        {
            return (Enum.TryParse(var, out ReviewStatusList output)) ? output : ReviewStatusList.None;
        }
    }
}
