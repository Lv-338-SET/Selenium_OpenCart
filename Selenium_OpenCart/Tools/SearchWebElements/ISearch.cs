using OpenQA.Selenium;
using System.Collections.Generic;

namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public interface ISearch
    {
        bool PresenceOfWebElement(IWebElement IWebElement);
        bool WebElementDisappearance(By by);

        #region Search Web Element
        IWebElement ElementById(string id);
        IWebElement ElementByName(string name);
        IWebElement ElementByXPath(string xpath);
        IWebElement ElementByCssSelector(string cssSelector);
        IWebElement ElementByClassName(string className);
        IWebElement ElementByPartialLinkText(string partialLinkText);
        IWebElement ElementByLinkText(string linkText);
        IWebElement ElementByTagName(string tagName);
        #endregion

        #region Search List Web Elements
        IReadOnlyCollection<IWebElement> ElementsByName(string name);
        IReadOnlyCollection<IWebElement> ElementsByXPath(string xpath);
        IReadOnlyCollection<IWebElement> ElementsByCssSelector(string cssSelector);
        IReadOnlyCollection<IWebElement> ElementsByClassName(string className);
        IReadOnlyCollection<IWebElement> ElementsByPartialLinkText(string partialLinkText);
        IReadOnlyCollection<IWebElement> ElementsByLinkText(string linkText);
        IReadOnlyCollection<IWebElement> ElementsByTagName(string tagName);
        #endregion
    }
}
