using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium_OpenCart.Data.Application;
using System.Collections.Generic;

namespace Selenium_OpenCart.Tools
{
    public interface IBrowser
    {
        IWebDriver GetBrowser(ApplicationSource applicationSource);
    }

    public class ChromeBrowser: IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(applicationSource.optionsParams);
            return new ChromeDriver();
        }
    }

    public class FirefoxBrowser: IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments(applicationSource.optionsParams);
            return new FirefoxDriver();
        }
    }

    public class InternetExplorerBrowser: IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            InternetExplorerOptions options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false,
            };

            return new InternetExplorerDriver(options);
        }
    }

    public class AllBrowsers
    {
        private const string DEFAULT_BROWSER = "DefaultBrowser";

        // Fields
        private Dictionary<string, IBrowser> Browsers;
        public IWebDriver Driver { get; private set; }

        public AllBrowsers(ApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            Browsers = new Dictionary<string, IBrowser>();
            Browsers.Add(DEFAULT_BROWSER, new ChromeBrowser());
            Browsers.Add(ApplicationSourceRepository.FIREFOX_BROWSER, new FirefoxBrowser());
            Browsers.Add(ApplicationSourceRepository.CHROME_BROWSER, new ChromeBrowser());
            Browsers.Add(ApplicationSourceRepository.INTERNET_EXPLORER_BROWSER, new InternetExplorerBrowser());
        }

        private void InitWebDriver(ApplicationSource applicationSource)
        {
            IBrowser currentBrowser = Browsers[DEFAULT_BROWSER];
            foreach (KeyValuePair<string, IBrowser> current in Browsers)
            {
                if (current.Key.ToString().ToLower()
                        .Equals(applicationSource.BrowserName.ToLower()))
                {
                    currentBrowser = current.Value;
                    break;
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
