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
    public class ProductComparisonPage : MainComparisonPage
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
        #endregion

        #region Properties
        protected IWebElement ProductDetailsLabel
        {
            get
            {
                return Search.ElementByXPath(PRODUCT_DETAILS_LABEL);
            }
        }

        protected IWebElement ProductLabel
        {
            get
            {
                return Search.ElementByXPath(PRODUCT_LABEL);
            }
        }

        protected IWebElement FirstProductName
        {
            get
            {
                return Search.ElementByXPath(FIRST_PRODUCT_NAME);
            }
        }

        protected IWebElement LastProductName
        {
            get
            {
                return Search.ElementByXPath(LAST_PRODUCT_NAME);
            }
        }

        protected IWebElement AddToCartFirst
        {
            get
            {
                return Search.ElementByXPath(ADD_TO_CART_FIRST);
            }
        }

        protected IWebElement AddToCartLast
        {
            get
            {
                return Search.ElementByXPath(ADD_TO_CART_LAST);
            }
        }

        protected IWebElement RemoveFirstProduct
        {
            get
            {
                return Search.ElementByXPath(REMOVE_FIRST);
            }
        }

        protected IWebElement RemoveLastProduct
        {
            get
            {
                return Search.ElementByXPath(REMOVE_LAST);
            }
        }
        #endregion

        #region Initialization & Verifycation
        public ProductComparisonPage()
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = ProductDetailsLabel;
            temp = ProductLabel;
            temp = FirstProductName;
            temp = AddToCartFirst;
            temp = RemoveFirstProduct;
        }
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
            return new ProductComparisonPageWhithMessage();
        }

        public ProductComparisonPageWhithMessage ClickAddToCartLast()
        {
            AddToCartLast.Click();
            return new ProductComparisonPageWhithMessage();
        }

        public  EmptyProductComparisonPageWhithMessage ClickRemoveFirstProduct()
        {
            RemoveFirstProduct.Click();
            return new EmptyProductComparisonPageWhithMessage();
        }

        public ProductComparisonPageWhithMessage ClickRemoveLastProduct()
        {
            RemoveLastProduct.Click();
            return new ProductComparisonPageWhithMessage();
        }

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
            return Search.ElementsByXPath(REMOVE_FIRST).Count;
        }
        #endregion
    }
}
