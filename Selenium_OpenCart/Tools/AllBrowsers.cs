using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Data.Constants;
using System.Collections.Generic;
using System;

namespace Selenium_OpenCart.Tools
{
    public interface IBrowser
    {
        IWebDriver GetBrowser(ApplicationSource applicationSource);
    }

    public class RemoteBrowser: IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {   
            Uri uriSelenium = new Uri(CONST_EN.SELENIUM_HUB_URL);
               
            switch (applicationSource.capabilitiesParams["browser"])
            {
                case ApplicationSourceRepository.CHROME_BROWSER:
                    return remoteChromeBrowser();                    
                case ApplicationSourceRepository.FIREFOX_BROWSER:
                    return remoteFirefoxBrowser();                   
                case ApplicationSourceRepository.INTERNET_EXPLORER_BROWSER:
                    return remoteIeBrowser();
                default:
                    Console.WriteLine("Browser name Error!");
                    return null;
            }

            RemoteWebDriver remoteChromeBrowser()
            {
                ChromeOptions options = new ChromeOptions();                                
                

                if (applicationSource.capabilitiesParams.Count > 0)
                {
                    foreach(var capabilities in applicationSource.capabilitiesParams)
                    {
                        options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);                        
                    }
                }
                options.AddArguments(applicationSource.optionsParams);
                return new RemoteWebDriver(uriSelenium, options.ToCapabilities());
            }

            RemoteWebDriver remoteFirefoxBrowser()
            {                
                FirefoxOptions options = new FirefoxOptions();                               
                options.AddArguments(applicationSource.optionsParams);

                if (applicationSource.capabilitiesParams.Count > 0)
                {
                    foreach (var capabilities in applicationSource.capabilitiesParams)
                    {
                        options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);
                    }
                }

                return new RemoteWebDriver(uriSelenium, options.ToCapabilities());
            }

            RemoteWebDriver remoteIeBrowser()
            {                
                DesiredCapabilities options = new DesiredCapabilities();

                if (applicationSource.capabilitiesParams.Count > 0)
                {
                    foreach (var capabilities in applicationSource.capabilitiesParams)
                    {
                        if(capabilities.Key != "browser")
                        {
                            options.SetCapability(capabilities.Key, capabilities.Value);
                        }
                        else
                        {
                            options.SetCapability("browserName", capabilities.Value);
                        }
                    }
                }

                return new RemoteWebDriver(uriSelenium, options);
            }      
        }
    }
    public class FirefoxBrowser : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments(applicationSource.optionsParams);
            return new FirefoxDriver(options);
        }
    }
    public class ChromeBrowser : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(applicationSource.optionsParams);
            return new ChromeDriver(options);
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
            Browsers.Add(ApplicationSourceRepository.REMOTE_BROWSER, new RemoteBrowser());
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
