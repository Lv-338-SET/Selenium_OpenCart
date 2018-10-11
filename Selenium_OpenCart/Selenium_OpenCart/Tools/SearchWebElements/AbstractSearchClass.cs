using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public abstract class AbstractSearchClass : ISearch
    {

        public const long WITHOUT_MILLISECONDS = 10000000;
        public const int TIME_SLEEP_MILLISECONDS = 500;
        private const string ELEMENT_NOT_FIND = "Not Find element(s):";

        protected long GetSecondStamp()
        {
            return DateTime.Now.ToFileTime() / WITHOUT_MILLISECONDS;
        }

        //Abstract Methods
        public abstract IWebElement GetWebElement(By by);
        public abstract IReadOnlyCollection<IWebElement> GetWebElements(By by);
        public abstract bool PresenceOfWebElement(IWebElement IWebElement);
        public abstract bool WebElementDisappearance(By by);
        public abstract void ResetWaits();

        //Try Get Web Element
        private IWebElement SearchWebElement(By by)
        {
            try
            {
                return GetWebElement(by);
            }
            catch (Exception)
            {
                throw new Exception(ELEMENT_NOT_FIND);
            }
        }

        //Try Get Web Elements
        private IReadOnlyCollection<IWebElement> SearchWebElements(By by)
        {
            try
            {
                return GetWebElements(by);
            }
            catch (Exception)
            {
                throw new Exception(ELEMENT_NOT_FIND);
            }
        }

        #region Search Web Element Methods
        public IWebElement ElementById(string id)
        {
            return SearchWebElement(By.Id(id));
        }

        public IWebElement ElementByName(string name)
        {
            return SearchWebElement(By.Name(name));
        }

        public IWebElement ElementByXPath(string xpath)
        {
            return SearchWebElement(By.XPath(xpath));
        }

        public IWebElement ElementByCssSelector(string cssSelector)
        {
            return SearchWebElement(By.CssSelector(cssSelector));
        }

        public IWebElement ElementByClassName(String className)
        {
            return SearchWebElement(By.ClassName(className));
        }

        public IWebElement ElementByPartialLinkText(string partialLinkText)
        {
            return SearchWebElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement ElementByLinkText(string linkText)
        {
            return SearchWebElement(By.LinkText(linkText));
        }

        public IWebElement ElementByTagName(string tagName)
        {
            return SearchWebElement(By.TagName(tagName));
        }
        #endregion

        #region Search Web Elements Methods
        public IReadOnlyCollection<IWebElement> ElementsByName(string name)
        {
            return SearchWebElements(By.Name(name));
        }

        public IReadOnlyCollection<IWebElement> ElementsByXPath(string xpath)
        {
            return SearchWebElements(By.XPath(xpath));
        }

        public IReadOnlyCollection<IWebElement> ElementsByCssSelector(string cssSelector)
        {
            return SearchWebElements(By.CssSelector(cssSelector));
        }

        public IReadOnlyCollection<IWebElement> ElementsByClassName(string className)
        {
            return SearchWebElements(By.ClassName(className));
        }

        public IReadOnlyCollection<IWebElement> ElementsByPartialLinkText(string partialLinkText)
        {
            return SearchWebElements(By.PartialLinkText(partialLinkText));
        }

        public IReadOnlyCollection<IWebElement> ElementsByLinkText(string linkText)
        {
            return SearchWebElements(By.LinkText(linkText));
        }

        public IReadOnlyCollection<IWebElement> ElementsByTagName(string tagName)
        {
            return SearchWebElements(By.TagName(tagName));
        }
        #endregion
    }
}
