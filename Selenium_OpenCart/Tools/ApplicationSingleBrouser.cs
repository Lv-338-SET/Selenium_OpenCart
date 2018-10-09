using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.LoginPage;
using Selenium_OpenCart.Pages.Body.LogoutPage;
using Selenium_OpenCart.Tools.SearchWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tools
{
    class ApplicationSingleBrouser
    {
        //Fields
        private volatile static ApplicationSingleBrouser instance;
        private static object lockingObject = new object();
        private ISearchStrategy search;
        private AllBrowsers browser;

        //Properties
        public ApplicationSource ApplicationSource { get; private set; }

        public AllBrowsers Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (browser == null)
                {
                    InitBrowser();
                }
                return browser;
            }
        }

        public ISearchStrategy Search
        {
            get
            {
                if (search == null)
                {
                    InitSearch();
                }
                return search;
            }
            private set
            {
                search = value;
            }
        }

        private ApplicationSingleBrouser(ApplicationSource applicationSource)
        {
            this.ApplicationSource = applicationSource;
        }

        public static ApplicationSingleBrouser Get()
        {
            return Get(null);
        }

        public static ApplicationSingleBrouser Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                if (applicationSource == null)
                {
                    applicationSource = ApplicationSourceRepository.Default();
                }
                instance = new ApplicationSingleBrouser(applicationSource);
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                instance.Browser.Quit();
                instance = null;
            }
        }

        private void InitBrowser()
        {
            browser = new AllBrowsers(ApplicationSource);
        }

        private void InitSearch()
        {
            this.Search = new SearchElement();
        }

        public LoginPage LoadLoginPage()
        {
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            return new LoginPage();//driver remowe
        }

        public LoginPage ActionLogout()
        {
            Browser.OpenUrl(ApplicationSource.LoginOut);
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            return new LoginPage();
        }
    }
}
