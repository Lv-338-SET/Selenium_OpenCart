using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools.SearchWebElements;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_OpenCart.Tools
{
    public class TestsApplication
    {
        //Fields
        private volatile static TestsApplication instance;
        private ISearchStrategy search;
        //For Parallel work
        private Dictionary<int, AllBrowsers> browsers;

        //Properties
        public ApplicationSource ApplicationSource { get; private set; }
        public AllBrowsers Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (!browsers.ContainsKey(currentThread))
                {
                    InitBrowser(currentThread);
                }
                return browsers[currentThread];
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

        private TestsApplication(ApplicationSource applicationSource)
        {
            browsers = new Dictionary<int, AllBrowsers>();
            this.ApplicationSource = applicationSource;
        }

        public static TestsApplication Get()
        {
            return Get(null);
        }

        public static TestsApplication Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                if (applicationSource == null)
                {
                    applicationSource = ApplicationSourceRepository.Default();
                }
                instance = new TestsApplication(applicationSource);
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                foreach (KeyValuePair<int, AllBrowsers> currentBrowser in instance.browsers)
                {
                    currentBrowser.Value.Quit();
                }
                instance = null;
            }
        }

        private void InitBrowser(int currentThread)
        {
            browsers.Add(currentThread, new AllBrowsers(ApplicationSource));
        }

        private void InitSearch()
        {
            this.Search = new SearchElement();
        }
    }
}
