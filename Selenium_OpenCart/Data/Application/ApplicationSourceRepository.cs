namespace Selenium_OpenCart.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        public const string FIREFOX_BROWSER = "Firefox";
        public const string CHROME_BROWSER = "Chrome";
        public const string INTERNET_EXPLORER_BROWSER = "InternetExplore";
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
            var option = new[] { "-heedless", "-no-proxy-server", "-ignore-certificate-errors"
                        , "-disable-extensions", "-start-maximized"};
            return new ApplicationSource(CHROME_BROWSER, 10L, 10L,
                "http://40.118.125.245/", option);
        }
        public static ApplicationSource RemoteChromeNew()
        {
            var option = new[] { "-heedless", "-no-proxy-server", "-ignore-certificate-errors"
                        , "-disable-extensions", "-start-maximized"};
            return new ApplicationSource(REMOTE_BROWSER, 10L, 10L,
                "http://40.118.125.245/", option, CHROME_BROWSER);
        }
        public static ApplicationSource ChromeDemo()
        {
            var option = new[] {"-heedless", "--test-type", "--no-proxy-server", "--ignore-certificate-errors"
                        , "--disable-extensions", "--start-maximized"};
            return new ApplicationSource(CHROME_BROWSER, 10L, 10L,
                "https://demo.opencart.com/");
        }

        public static ApplicationSource InternetExplorerDemo()
        {
            return new ApplicationSource(INTERNET_EXPLORER_BROWSER, 10L, 10L,
                "http://regres.herokuapp.com/login");
        }

        public static ApplicationSource FirefoxDemo()
        {
            return new ApplicationSource(FIREFOX_BROWSER, 10L, 10L,
                "http://atqc-shop.epizy.com/");
        }
        public static ApplicationSource RemoteFirefoxNew()
        {
            var option = new[] { "-heedless", "-no-proxy-server", "-ignore-certificate-errors"
                        , "-disable-extensions", "-start-maximized"};
            return new ApplicationSource(REMOTE_BROWSER, 10L, 10L,
                "http://40.118.125.245/", option, FIREFOX_BROWSER);
        }
    }
}
