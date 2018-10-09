using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Currency
{
    public enum CurrencyList
    {
        [Description("€ Euro")] euro,
        [Description("£ Pound Sterling")] pound,
        [Description("$ US Dollar")] dollar
    }

    public class CurrencyRepository
    {
        public static Dictionary<CurrencyList, char> CurrencyFullTextToSign
        {
            get;
            private set;
        }

        static CurrencyRepository()
        {
            CurrencyFullTextToSign = new Dictionary<CurrencyList, char>()
            {
                { CurrencyList.euro, '€' },
                { CurrencyList.pound, '£' },
                { CurrencyList.dollar, '$' }
            };
        }
    }

    public static class ExtentionMethods
    {
        public static string ToDescriptionString(this CurrencyList val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
