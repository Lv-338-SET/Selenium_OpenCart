using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Pages.Header;
using Selenium_OpenCart.Pages.Body.ProductPage;
using System.Threading;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Tools.SearchWebElements;

namespace Selenium_OpenCart.Pages.Body.SearchPage
{
    //header
    public class SearchPage
    {
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        protected IWebElement searchLabel
            { get { return Search.ElementByCssSelector("#content h1"); } }
        protected IWebElement searchTextBoxInsideContent
            { get { return Search.ElementById("input-search"); } }
        protected IWebElement searchCategoryCheck
            { get { return Search.ElementByName("sub_category"); } }
        protected IWebElement searchDescriptionChek
            { get { return Search.ElementByName("description"); } }
        protected IWebElement searchButtonInsideContent
            { get { return Search.ElementById("button-search"); } }
        protected IWebElement listShowButton
            { get { return Search.ElementById("list-view"); } }
        protected IWebElement gridShowButton
            { get { return Search.ElementById("grid-view"); } }
        protected IWebElement productCompareLabel
            { get { return Search.ElementById("compare-total"); } }
        protected IWebElement productPageLabel
            { get { return Search.ElementByClassName("text-right"); } }
        protected IWebElement successAlertMessage
        { get { return Search.ElementByXPath("//div[@class='alert alert-success alert-dismissible']"); } }


        protected SelectElement selectCategory
            { get { return new SelectElement(Search.ElementByName("category_id")); } }
        protected SelectElement selectSortBy
            { get { return new SelectElement(Search.ElementById("input-sort")); } }
        protected SelectElement selectShow
            { get { return new SelectElement(Search.ElementById("input-limit")); } }

        protected List<ProductItem> listProduct
            { get { return InitializeListProduct(Search.ElementsByClassName("product-layout")); } }

        public SearchPage()
        {
            Initialize();
        }

        #region Initialization

        private void Initialize()
        {
            IWebElement element = searchLabel;
            element = searchTextBoxInsideContent;
            element = searchCategoryCheck;
            element = searchDescriptionChek;
            element = searchButtonInsideContent;
            element = listShowButton;
            element = gridShowButton;
            element = productCompareLabel;
            element = productPageLabel;

            SelectElement selement = selectCategory;
            selement = selectSortBy;
            selement = selectShow;

            var listP = listProduct;
        }

        private List<ProductItem> InitializeListProduct(IReadOnlyCollection<IWebElement> elements)
        {

            List<ProductItem> list = new List<ProductItem>();

            foreach (var current in elements)
            {
                list.Add(new ProductItem(current));
            }
            return list;
        }

        #endregion

        #region AtomicOperation
        public List<ProductItem> GetListProduct()
        {
            return this.listProduct;
        }

        public string GetTextFromSearchLabel()
        {
            return this.searchLabel.Text;
        }

        public SearchPage ClearsearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Clear();
            return this;
        }
        public SearchPage ClicksearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Click();
            return this;
        }
        public SearchPage SetTextInsearchTextBoxInsideContent(string text)
        {
            this.searchTextBoxInsideContent.SendKeys(text);
            return this;
        }
        public string GetTextFromsearchTextBoxInsideContent()
        {
            return this.searchTextBoxInsideContent.Text;
        }

        public SearchPage ClickSearchCategoryCheck()
        {
            this.searchCategoryCheck.Click();
            return this;
        }
        public bool GetSearchCategoryValue()
        {
            return this.searchCategoryCheck.Selected;
        }

        public bool GetSearchDescriptionValue()
        {
            return this.searchDescriptionChek.Selected;
        }
        public SearchPage ClickSearchDescription()
        {
            this.searchDescriptionChek.Click();
            return this;
        }

        public SearchPage ClickSearchButtonInsideContent()
        {
            this.searchButtonInsideContent.Click();
            return new SearchPage();
        }

        public SearchPage ClickListShowButton()
        {
            this.listShowButton.Click();
            return this;
        }

        public SearchPage ClickGridShowButton()
        {
            this.gridShowButton.Click();
            return this;
        }

        public SearchPage ClickProductCompareLabel()
        {
            this.productCompareLabel.Click();
            return this;
        }
        public string GetProductCompareText()
        {
            return this.productCompareLabel.Text;
        }

        public string GetProductPageLabelText()
        {
            return this.productPageLabel.Text;
        }

        public List<string> GetListOfCategories()
        {
            List<string> list = new List<string>();
            foreach (var current in this.selectCategory.Options)
            {
                list.Add(current.Text);
            }
            return list;
        }

        public SearchPage SetCategoryValue(string category)
        {
            this.selectCategory.SelectByText(category);
            return this;
        }
        public string GetSelectedCategory()
        {
            return this.selectCategory.SelectedOption.Text;
        }

        public SearchPage SetSortedByValue(string sorted)
        {
            this.selectSortBy.SelectByText(sorted);
            return this;
        }
        public string GetSelectedSortBy()
        {
            return this.selectSortBy.SelectedOption.Text;
        }

        public SearchPage SetShowValue(string category)
        {
            this.selectShow.SelectByText(category);
            return this;
        }
        public string GetSelectedShow()
        {
            return this.selectShow.SelectedOption.Text;
        }

        public ProductItem FindAppropriateProduct(string product)
        {
            foreach (var item in listProduct)
            {
                if (item.IsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }

        public SearchPage AddAppropriateItemToWishList(string product)
        {
            FindAppropriateProduct(product).ClickCartFavourite();
            return new SearchPage();
        }

        public SearchPage AddAppropriateItemToShopingCart(string product)
        {
            FindAppropriateProduct(product).ClickCartButton();
            return new SearchPage();
        }

        public SearchPage AddAppropriateProductToComparison(string product)
        {
            FindAppropriateProduct(product).ClickCompareButton();
            return new SearchPage();
        }

        public ProductPage.ProductPage OpenAppropriateProductPage(string product)
        {
            FindAppropriateProduct(product).ClickProductName();
            return new ProductPage.ProductPage();
        }

        public string successAlertMessageText()
        {
            return successAlertMessage.Text;
        }
        public bool isSuccessMessageDisplayed()
        {
            return successAlertMessage.Displayed;
        }
        #endregion



    }
}
