using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Pages.Body.ProductPage.ProductPageAlerts
{
    public sealed class NotSelectedRatingAlertPage : ProductPageReview
    {
        #region Properties
        private IWebElement WarningAlert
        {
            get
            {
                return driver.FindElement(By.CssSelector("#form-review > div.alert.alert-danger.alert-dismissible"));
            }
        }
        #endregion

        #region Initialization and Verifycation        
        public NotSelectedRatingAlertPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyPage();
        }

        private void VerifyPage()
        {
            IWebElement tmp = WarningAlert;
        }
        #endregion

        #region Atomic operations
        #region Atomic operations for WarningAlert
        public bool IsWarningAlertDisplayed()
        {
            return this.WarningAlert.Displayed;
        }

        public string GetWarningAlertText()
        {
            return this.WarningAlert.Text;
        }
        #endregion
        #endregion
    }
}
