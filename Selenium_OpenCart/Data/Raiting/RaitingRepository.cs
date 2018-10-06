using System.Collections.Generic;
using System.ComponentModel;

namespace Selenium_OpenCart.Data.Raiting
{
    public enum RaitingList
    {
        None = 0,
        Rating1 = 1,
        Rating2 = 2,
        Rating3 = 3,
        Rating4 = 4,
        Rating5 = 5
    }


    public class RaitingRepository
    {
        public static Dictionary<RaitingList, int> ListOfRaiting
        {
            get;
            private set;
        }

        static RaitingRepository()
        {
            ListOfRaiting = new Dictionary<RaitingList, int>()
            {
                { RaitingList.Rating1, 1 },
                { RaitingList.Rating2, 2 },
                { RaitingList.Rating3, 3 },
                { RaitingList.Rating4, 4 },
                { RaitingList.Rating5, 5 }
            };
        }
    }

    public static class ExtentionMethods
    {
        public static RaitingList ToRaiting(this int val)
        {
            return (val >=0  && val <= 5) ? (RaitingList)val : RaitingList.None;
        }

        public static int ToInt(this RaitingList val)
        {
            return (int)val;
        }
    }
}
