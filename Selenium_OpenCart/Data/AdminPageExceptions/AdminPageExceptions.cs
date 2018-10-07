using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.AdminPageExeptions
{
    /// <summary>
    /// Exeption using when in Header Curnet Page Label not equal to last reference text in site map
    /// </summary>
    public class BadSiteMap : Exception
    {
        public BadSiteMap()
        {
        }

        public BadSiteMap(string message) : base(message)
        {
            if (message == null || message == String.Empty)
            {
                message = "In Header Curnet Page Label not equal to last reference text in site map";
            }
        }

        public BadSiteMap(string message, Exception inner) : base(message, inner)
        {
            if (message == null || message == String.Empty)
            {
                message = "In Header Curnet Page Label not equal to last reference in site map";
            }
        }
    }
}
