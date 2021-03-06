﻿using System;
using System.Collections.Generic;

namespace Selenium_OpenCart.Data.Application
{
    public class ApplicationSource
    {
        //Browser Data
        public string BrowserName { get; private set; }
        public string RemoteBrowserName { get; private set; }

        //Implicit and Implicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        //Implicit and Explicit Waits
        public long ExplicitTimeOut { get; private set; }

        //Params for brouser. Each Arguments most be preceeded by two dashes ("--")
        public string[] optionsParams = null;
        public Dictionary<string, object> capabilitiesParams = null;
        public string LoginPagetUrl { get { return $"{HomePageUrl}index.php?route=account/login"; } }
        public string LogoutPageUrl { get { return $"{HomePageUrl}index.php?route=account/logout"; } }
        public string HomePageUrl { get; private set; }

        public Uri Uri { get; private set; }

        public ApplicationSource(string browserName, long implicitWaitTimeOut,
                long explicitTimeOut, string homePageUrl, string[] optionsParams = null, Dictionary<string, object> capabilities = null, Uri Uri = null)
        {
            this.BrowserName = browserName;
            this.ImplicitWaitTimeOut = implicitWaitTimeOut;
            this.ExplicitTimeOut = explicitTimeOut;
            this.HomePageUrl = homePageUrl;            
            SetOptions(optionsParams);
            SetCapabilities(capabilities);
            this.Uri = Uri;
        }

        private void SetOptions(string[] optionsParams)
        {
            if (optionsParams == null)
            {
                this.optionsParams = new string[] {""};
            }
            else
            {
                this.optionsParams = optionsParams;
            }
        }
        private void SetCapabilities(Dictionary<string, object> capabilitiesParams)
        {
            if (capabilitiesParams == null)
            {
                this.capabilitiesParams = new Dictionary<string, object>(0);
            }
            else
            {
                this.capabilitiesParams = new Dictionary<string, object>(capabilitiesParams);
            }
        }
    }
}
