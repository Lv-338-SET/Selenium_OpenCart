using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    class AddressBookException:Exception
    {
        public AddressBookException(string message) : base(message) { }
    }
}
