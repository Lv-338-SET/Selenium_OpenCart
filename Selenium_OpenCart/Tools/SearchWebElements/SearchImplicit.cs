using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public class SearchImplicit : AbstractSearchClass
    {
        public SearchImplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
        }

        public override bool PresenceOfWebElement(IWebElement element)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.ImplicitWaitTimeOut)
                   && !result)
            {
                try
                {
                    result = element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override bool WebElementDisappearance(By by)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.ImplicitWaitTimeOut)
                  && !result)
            {
                try
                {
                    result = GetWebElement(by) == null || !GetWebElement(by).Enabled || !GetWebElement(by).Displayed;
                }
                catch (Exception)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override IReadOnlyCollection<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }
    }
}
