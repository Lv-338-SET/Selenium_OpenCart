using System;

namespace Selenium_OpenCart.Data.Application
{
    public class ApplicationSource
    {
        //Browser Data
        public string BrowserName { get; private set; }

        //Implicit and Implicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        //Implicit and Explicit Waits
        public long ExplicitTimeOut { get; private set; }

        //Params for brouser. Each Arguments most be preceeded by two dashes ("--")
        public string[] optionsParams = null;
        public string LoginPagetUrl { get { return $"{HomePageUrl}index.php?route=account/logout"; } }
        public string LogoutPageUrl { get { return $"{HomePageUrl}index.php?route=account/logout"; } }
        public string HomePageUrl { get; private set; }

        public ApplicationSource(string browserName,
                long implicitWaitTimeOut,
                long explicitTimeOut,
                string homePageUrl,
                string[] optionsParams = null)
        {
            this.BrowserName = browserName;
            this.ImplicitWaitTimeOut = implicitWaitTimeOut;
            this.ExplicitTimeOut = explicitTimeOut;
            this.HomePageUrl = homePageUrl;
            SetOptions(optionsParams);
            
        }

        private void SetOptions(string[] optionsParams)
        {
            if (optionsParams == null)
            {
                this.optionsParams = new string[] {""};
            }
            else
            {

            }
        }
    }
}
