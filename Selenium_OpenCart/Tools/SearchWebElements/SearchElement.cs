using OpenQA.Selenium;
using System.Collections.Generic;

namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public class SearchElement : ISearchStrategy
    {
        public AbstractSearchClass Search { get; private set; }

        public SearchElement()
        {
            InitSearch();
        }

        private void InitSearch()
        {
            Search = new SearchImplicit();
        }

        public void SetStrategy(AbstractSearchClass search)
        {
            Search = search;
        }

        public void SetImplicitStrategy()
        {
            SetStrategy(new SearchImplicit());
        }

        public void SetExplicitStrategy()
        {
            SetStrategy(new SearchExplicit());
        }

        //Check presence of web element on page
        public bool PresenceOfWebElement(IWebElement webElement)
        {
            return Search.PresenceOfWebElement(webElement);
        }

        //Check Disappearance of web element on page
        public bool WebElementDisappearance(By by)
        {
            return Search.WebElementDisappearance(by);
        }

        #region Get web element Methods
        public IWebElement ElementById(string id)
        {
            return Search.ElementById(id);
        }

        public IWebElement ElementByName(string name)
        {
            return Search.ElementByName(name);
        }

        public IWebElement ElementByXPath(string xpath)
        {
            return Search.ElementByXPath(xpath);
        }

        public IWebElement ElementByCssSelector(string cssSelector)
        {
            return Search.ElementByCssSelector(cssSelector);
        }

        public IWebElement ElementByClassName(string className)
        {
            return Search.ElementByClassName(className);
        }

        public IWebElement ElementByPartialLinkText(string partialLinkText)
        {
            return Search.ElementByPartialLinkText(partialLinkText);
        }

        public IWebElement ElementByLinkText(string linkText)
        {
            return Search.ElementByLinkText(linkText);
        }

        public IWebElement ElementByTagName(string tagName)
        {
            return Search.ElementByTagName(tagName);
        }
        #endregion

        #region Get List web elements methods
        public IReadOnlyCollection<IWebElement> ElementsByName(string name)
        {
            return Search.ElementsByName(name);
        }

        public IReadOnlyCollection<IWebElement> ElementsByXPath(string xpath)
        {
            return Search.ElementsByXPath(xpath);
        }

        public IReadOnlyCollection<IWebElement> ElementsByCssSelector(string cssSelector)
        {
            return Search.ElementsByCssSelector(cssSelector);
        }

        public IReadOnlyCollection<IWebElement> ElementsByClassName(string className)
        {
            return Search.ElementsByClassName(className);
        }

        public IReadOnlyCollection<IWebElement> ElementsByPartialLinkText(string partialLinkText)
        {
            return Search.ElementsByPartialLinkText(partialLinkText);
        }

        public IReadOnlyCollection<IWebElement> ElementsByLinkText(string linkText)
        {
            return Search.ElementsByLinkText(linkText);
        }

        public IReadOnlyCollection<IWebElement> ElementsByTagName(string tagName)
        {
            return Search.ElementsByTagName(tagName);
        }
        #endregion
    }
}
