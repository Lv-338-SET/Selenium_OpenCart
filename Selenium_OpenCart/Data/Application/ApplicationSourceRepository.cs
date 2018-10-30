using OpenQA.Selenium.Remote;
using Selenium_OpenCart.Data.Constants;
using System.Collections.Generic;

namespace Selenium_OpenCart.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        public const string FIREFOX_BROWSER = "firefox";
        public const string CHROME_BROWSER = "chrome";
        public const string INTERNET_EXPLORER_BROWSER = "internet explorer";
        public const string REMOTE_BROWSER = "RemoteBrowser";

        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return RemoteChromeNew();
        }

        public static ApplicationSource myStart(ApplicationSource returnNew)
        {
            return returnNew;
        }
        public static ApplicationSource ChromeTAQC()
        {
            var option = new[] { "--no-proxy-server", "--ignore-certificate-errors" 
                        , "--disable-extensions", "--start-maximized"};
            return new ApplicationSource(CHROME_BROWSER, 10L, 10L,
                "http://atqc-shop.epizy.com/", option);
        }

        public static ApplicationSource ChromeNew()
        {
            var option = new[] { "--heedless", "--no-proxy-server", "--ignore-certificate-errors"
                        , "--disable-extensions", "--start-maximized"};           
            return new ApplicationSource(CHROME_BROWSER, 10L, 10L,
                CONST_EN.TEST_SITE_URL, option);
        }
        public static ApplicationSource RemoteChromeNew()
        {            
            var option = new[] {  "--heedless", "--no-proxy-server", "--ignore-certificate-errors"
                        , "--disable-extensions", "--start-maximized" };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CHROME_BROWSER },
                { CapabilityType.Platform, "Windows" }
            };

            return new ApplicationSource(REMOTE_BROWSER, 20L, 20L,
               CONST_EN.TEST_SITE_URL, option, capabilities);
        }

        public static ApplicationSource RemoteLinuxChromeNew()
        {
            var option = new[] {"--no-sandbox","--display=:99.0"}; //Runs tests using virtual desktop 
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", "chrome" },
                { CapabilityType.Platform, "Linux" }
            };

            return new ApplicationSource(REMOTE_BROWSER, 20L, 20L,
                CONST_EN.TEST_SITE_URL, option, capabilities);
        }
        public static ApplicationSource ChromeDemo()
        {
            var option = new[] {"--heedless", "--test-type", "--no-proxy-server", "--ignore-certificate-errors"
                        , "--disable-extensions", "--start-maximized"};
            return new ApplicationSource(CHROME_BROWSER, 10L, 10L,
                "https://demo.opencart.com/");
        }

        public static ApplicationSource InternetExplorerDemo()
        {            
            return new ApplicationSource(INTERNET_EXPLORER_BROWSER, 10L, 10L,
                "http://regres.herokuapp.com/login");
        }
        public static ApplicationSource RemoteInternetExplorerNew()
        {
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", INTERNET_EXPLORER_BROWSER },
                { "javascriptEnabled", true },
                { "nativeEvents", false },
                { "ignoreProtectedModeSettings", true },
                { "requireWindowFocus", true },
                { "unexpectedAlertBehaviour", true },
                { "ignoreZoomSetting", true }
            };

            return new ApplicationSource(REMOTE_BROWSER, 10L, 10L,
                CONST_EN.TEST_SITE_URL, null, capabilities);
        }

        public static ApplicationSource FirefoxDemo()
        {
            return new ApplicationSource(FIREFOX_BROWSER, 10L, 10L,
                "http://atqc-shop.epizy.com/");
        }
        public static ApplicationSource RemoteFirefoxNew()
        {
            var option = new[] { "--ignore-certificate-errors" };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", FIREFOX_BROWSER },
                {"acceptInsecureCerts", true }
                
            };
            return new ApplicationSource(REMOTE_BROWSER, 10L, 10L,
                CONST_EN.TEST_SITE_URL, option, capabilities);
        }
    }
}
