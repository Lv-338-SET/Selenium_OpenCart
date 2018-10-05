using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.MyAccountPage
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
