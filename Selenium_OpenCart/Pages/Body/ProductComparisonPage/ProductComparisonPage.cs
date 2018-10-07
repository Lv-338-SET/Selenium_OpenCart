using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class ProductComparisonPage : Header.Header
    {
        #region Constants
        private const string COMPARISON_TABLE_NAME = "#content h1"; //CSS
        private const string PRODUCT_DETAILS_LABEL = "//strong[text()='Product Details']"; //XPath
        private const string PRODUCT_LABEL = "//td[text() = 'Product']"; //XPath
        //TODO
        private const string NO_COMPARE_PRODUCTS_MESSAGE = "#content p"; //CSS
        private const string FIRST_PRODUCT_NAME = "//td[text() = 'Product']/following-sibling::td"; //XPath
        private const string LAST_PRODUCT_NAME = "//td[text() = 'Product']/following-sibling::td[last()]"; //XPath
        private const string ADD_TO_CART_FIRST = "//tbody[last()]/descendant::input"; //XPath
        private const string ADD_TO_CART_LAST = "//tbody[last()]/descendant::input[last()]"; //XPath
        private const string REMOVE_FIRST = "//tbody[last()]/descendant::a"; //XPath
        private const string REMOVE_LAST = "//tbody[last()]/tr[last()]/descendant::a[last()]"; //XPath
        #endregion

        #region Properties
        protected IWebElement ComparisonTableName
        {
            get
            {
                return driver.FindElement(By.CssSelector(COMPARISON_TABLE_NAME));
            }
        }

        protected IWebElement ProductDetailsLabel
        {
            get
            {
                return driver.FindElement(By.XPath(PRODUCT_DETAILS_LABEL));
            }
        }

        protected IWebElement ProductLabel
        {
            get
            {
                return driver.FindElement(By.XPath(PRODUCT_LABEL));
            }
        }

        //TODO
        protected IWebElement NoCompareProductsMessage
        {
            get
            {
                return driver.FindElement(By.CssSelector(NO_COMPARE_PRODUCTS_MESSAGE));
            }
        }

        protected IWebElement FirstProductName
        {
            get
            {
                return driver.FindElement(By.XPath(FIRST_PRODUCT_NAME));
            }
        }

        protected IWebElement LastProductName
        {
            get
            {
                return driver.FindElement(By.XPath(LAST_PRODUCT_NAME));
            }
        }

        protected IWebElement AddToCartFirst
        {
            get
            {
                return driver.FindElement(By.XPath(ADD_TO_CART_FIRST));
            }
        }

        protected IWebElement AddToCartLast
        {
            get
            {
                return driver.FindElement(By.XPath(ADD_TO_CART_LAST));
            }
        }

        protected IWebElement RemoveFirstProduct
        {
            get
            {
                return driver.FindElement(By.XPath(REMOVE_FIRST));
            }
        }

        protected IWebElement RemoveLastProduct
        {
            get
            {
                return driver.FindElement(By.XPath(REMOVE_LAST));
            }
        }

        //TODO
        protected List<IWebElement> AllProducts
        {
            get
            {
                return driver.FindElements(By.XPath(FIRST_PRODUCT_NAME)).ToList();
            }
        }
        #endregion

        #region Initialization & Verifycation
        public ProductComparisonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = ComparisonTableName;
            temp = ProductDetailsLabel;
            temp = ProductLabel;
            temp = FirstProductName;
            temp = AddToCartFirst;
            temp = RemoveFirstProduct;
        }
        #endregion

        #region Atomic operations
        public string GetComparisonTableNameText()
        {
            return ComparisonTableName.Text;
        }

        public string GetProductDetailsLabelText()
        {
            return ProductDetailsLabel.Text;
        }

        public string GetProductLabelText()
        {
            return ProductLabel.Text;
        }

        //TODO
        public string GetNoProductsToCompareLabelText()
        {
            return NoCompareProductsMessage.Text;
        }

        public string GetFirstProductNameText()
        {
            return FirstProductName.Text;
        }

        public void ClickFirstProductName()
        {
            FirstProductName.Click();
        }

        public string LastProductNameText()
        {
            return LastProductName.Text;
        }

        public void ClickLastProductName()
        {
            LastProductName.Click();
        }

        public void ClickAddToCartFirst()
        {
            AddToCartFirst.Click();
        }

        public void ClickAddToCartLast()
        {
            AddToCartLast.Click();
        }

        public void ClickRemoveFirstProduct()
        {
            RemoveFirstProduct.Click();
        }

        public void ClickRemoveLastProduct()
        {
            RemoveLastProduct.Click();
        }
        #endregion
    }
}
