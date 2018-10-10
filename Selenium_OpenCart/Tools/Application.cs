using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Pages.Body.MainPage;
using Selenium_OpenCart.Tools.SearchWebElements;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_OpenCart.Tools
{
    public class Application
    {
        //Fields
        private volatile static Application instance;
        private static object lockingObject = new object();
        private ISearchStrategy search;
        //For Parallel work
        private Dictionary<int, AllBrowsers> browser;

        //Properties
        public ApplicationSource ApplicationSource { get; private set; }
        public AllBrowsers Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (!browser.ContainsKey(currentThread))
                {
                    InitBrowser(currentThread);
                }
                return browser[currentThread];
            }
        }

        public ISearchStrategy Search
        {
            get
            { if (search == null)
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

        private Application(ApplicationSource applicationSource)
        {
            browser = new Dictionary<int, AllBrowsers>();
            this.ApplicationSource = applicationSource;
        }

        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                if (applicationSource == null)
                {
                    applicationSource = ApplicationSourceRepository.Default();
                }
                instance = new Application(applicationSource);
                Thread.Sleep(500);
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                foreach (KeyValuePair<int, AllBrowsers> kvp in instance.browser)
                {
                    kvp.Value.Quit();
                }
                instance = null;
            }
        }

        private void InitBrowser(int currentThread)
        {
            browser.Add(currentThread, new AllBrowsers(ApplicationSource));
        }

        private void InitSearch()
        {
            this.Search = new SearchElement();
        }

        //public HomePage LogoutAction()
        //{
        //    //TO DO!!!!!!!!!!!!!!!!
        //    Browser.OpenUrl(ApplicationSource.HomePageUrl);
        //    return new HomePage();
        //}
    }
}
