using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public class SearchExplicit : AbstractSearchClass
    {
        public SearchExplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            TestsApplication.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(0);
        }

        //Check Whether Missing Element
        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public override bool PresenceOfWebElement(IWebElement IWebElement)
        {
            return new WebDriverWait(TestsApplication.Get().Browser.Driver,
                    TimeSpan.FromSeconds(TestsApplication.Get().ApplicationSource.ExplicitTimeOut))
                    .Until(StalenessOf(IWebElement));
        }

        //Check if the element is invisible.
        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        //Check Disappearance of web element on page
        public override bool WebElementDisappearance(By by)
        {
            return new WebDriverWait(TestsApplication.Get().Browser.Driver,
                    TimeSpan.FromSeconds(TestsApplication.Get().ApplicationSource.ExplicitTimeOut))
                    .Until(InvisibilityOfElementLocated(by));
        }

        public override IWebElement GetWebElement(By by)
        {
            return new WebDriverWait(TestsApplication.Get().Browser.Driver,
                    TimeSpan.FromSeconds(TestsApplication.Get().ApplicationSource.ExplicitTimeOut))
                    .Until(driver => driver.FindElement(by));
        }

        public static Func<IWebDriver, IReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By by)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(by);
                    if (elements.Any(element => !element.Displayed))
                    {
                        return null;
                    }

                    return elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public override IReadOnlyCollection<IWebElement> GetWebElements(By by)
        {
            return new WebDriverWait(TestsApplication.Get().Browser.Driver,
                    TimeSpan.FromSeconds(TestsApplication.Get().ApplicationSource.ExplicitTimeOut))
                    .Until(VisibilityOfAllElementsLocatedBy(by));
        }
    }
}
