using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Logic.ProductPageLogic;
using Selenium_OpenCart.Pages.Body.SearchPage;

namespace Selenium_OpenCart.Pages.Body.ProductComparisonPage
{
    public class ProductComparisonPage : EmptyProductComparisonPage
    {
        #region Constants
        private const string PRODUCT_DETAILS_LABEL = "//strong[text()='Product Details']"; //XPath
        private const string PRODUCT_LABEL = "//td[text() = 'Product']"; //XPath
        private const string FIRST_PRODUCT_NAME = "//td[text() = 'Product']/following-sibling::td"; //XPath
        private const string LAST_PRODUCT_NAME = "//td[text() = 'Product']/following-sibling::td[last()]"; //XPath
        private const string ADD_TO_CART_FIRST = "//tbody[last()]/descendant::input"; //XPath
        private const string ADD_TO_CART_LAST = "//tbody[last()]/descendant::input[last()]"; //XPath
        private const string REMOVE_FIRST = "//tbody[last()]/descendant::a"; //XPath
        private const string REMOVE_LAST = "//tbody[last()]/tr[last()]/descendant::a[last()]"; //XPath
        //private const string PRODUCT_COLUMN = "tr .text-center"; //CSS

        #endregion

        #region Properties
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

        //protected List<ProductComparisonPage> ListProductColumn
        //{
        //    get
        //    {
        //        return InitializeListProductColumn(driver.FindElements(By.CssSelector(PRODUCT_COLUMN)));
        //    }
        //}
        #endregion

        #region Initialization & Verifycation
        public ProductComparisonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = ProductDetailsLabel;
            temp = ProductLabel;
            temp = FirstProductName;
            temp = AddToCartFirst;
            temp = RemoveFirstProduct;

            //var listProductColumn = ListProductColumn;
        }

        //private List<ProductComparisonPage> InitializeListProductColumn(IReadOnlyCollection<IWebElement> elements)
        //{
        //    List<ProductComparisonPage> list = new List<ProductComparisonPage>();
        //    foreach (var current in elements)
        //    {
        //        list.Add(new ProductComparisonPage(driver));
        //    }
        //    return list;
        //}
        #endregion

        #region Atomic operations
        public string GetProductDetailsLabelText()
        {
            return ProductDetailsLabel.Text;
        }

        public string GetProductLabelText()
        {
            return ProductLabel.Text;
        }

        public string GetFirstProductNameText()
        {
            return FirstProductName.Text;
        }

        public ProductPageLogic ClickFirstProductName()
        {
            FirstProductName.Click();
            return new ProductPageLogic();
        }

        public string LastProductNameText()
        {
            return LastProductName.Text;
        }

        public ProductPageLogic ClickLastProductName()
        {
            LastProductName.Click();
            return new ProductPageLogic();
        }

        public ProductComparisonPageWhithMessage ClickAddToCartFirst()
        {
            AddToCartFirst.Click();
            return new ProductComparisonPageWhithMessage(driver);
        }

        public ProductComparisonPageWhithMessage ClickAddToCartLast()
        {
            AddToCartLast.Click();
            return new ProductComparisonPageWhithMessage(driver);
        }

        //TODO !!!!!!!!!!!! як взнати яку сторінку ретурнити, оскільки після видалення може бути або пуста або ще заповнена
        public ProductComparisonPageWhithMessage ClickRemoveFirstProduct()
        {
            RemoveFirstProduct.Click();
            return new ProductComparisonPageWhithMessage(driver);
        }

        public EmptyProductComparisonPageWhithMessage ClickRemoveLastProduct()
        {
            RemoveLastProduct.Click();
            return new EmptyProductComparisonPageWhithMessage(driver);
        }

        //public ProductComparisonPage ColumnsCount()
        //{
        //    int i = 0;
        //    foreach (var item in ListProductColumn)
        //    {
        //        i++;
        //    }
        //    return null;
        //}

        public bool IsElementPresent()
        {
            try
            {
                GetFirstProductNameText();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public int CountColumns()
        {
            return driver.FindElements(By.XPath("//tbody[last()]/descendant::tr")).Count;//try different locator, then replace to constants
        }
        #endregion
    }
}
