﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_OpenCart.Logic;

namespace Selenium_OpenCart.Pages
{
    class SearchPage : Header
    {

        protected IWebElement searchLabel
            { get { return driver.FindElement(By.CssSelector("#content h1")); } }
        protected IWebElement searchTextBoxInsideContent
            { get { return driver.FindElement(By.Id("input-search")); } }
        protected IWebElement searchCategoryCheck
            { get { return driver.FindElement(By.Name("sub_category")); } }
        protected IWebElement searchDescriptionChek
            { get { return driver.FindElement(By.Name("description")); } }
        protected IWebElement searchButtonInsideContent
            { get { return driver.FindElement(By.Id("button-search")); } }
        protected IWebElement listShowButton
            { get { return driver.FindElement(By.Id("list-view")); } }
        protected IWebElement gridShowButton
            { get { return driver.FindElement(By.Id("grid-view")); } }
        protected IWebElement productCompareLabel
            { get { return driver.FindElement(By.Id("compare-total")); } }
        protected IWebElement productPageLabel
            { get { return driver.FindElement(By.ClassName("text-right")); } }

        protected SelectElement selectCategory
            { get { return new SelectElement(driver.FindElement(By.Name("category_id"))); } }
        protected SelectElement selectSortBy
            { get { return new SelectElement(driver.FindElement(By.Id("input-sort"))); } }
        protected SelectElement selectShow
            { get { return new SelectElement(driver.FindElement(By.Id("input-limit"))); } }

        protected List<ProductItem> listProduct
            { get { return InitializeListProduct(driver.FindElements(By.ClassName("product-layout"))); } }

        public SearchPage(IWebDriver driver) : base(driver)
        {
            Initialize();
            this.driver = driver;
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
                list.Add(new ProductItem(driver, current));
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
            return new SearchPage(this.driver);
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
        #endregion

        #region BussinesLogic

        public string GetSearchHeader(string search)
        {
            SearchPage content = Search(search);
            return content.GetTextFromSearchLabel();
        }

        public bool TestCategoriesValue(List<string> list)
        {
            SearchPage content = new SearchPage(this.driver);
            List<string> actual = content.GetListOfCategories();
            int count = 0;
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i].Replace(" ", "") == list[i].Replace(" ", ""))
                {
                    count++;
                }
            }

            return count == actual.Count;
        }

        public int SearchByCategory(string textSearch, string category)
        {

            SearchPage content = Search(textSearch);
            content.SetCategoryValue(category);

            content = content.ClickSearchButtonInsideContent();

            return content.GetListProduct().Count;
        }

        public void SearchingMethod(string testSearch, string category, bool chekSubcategory = false, bool checkSearchInDesc = false)
        {
            SearchPage content = new SearchPage(this.driver);

            content.SetTextInSearchTextBox(testSearch);
            content.SetCategoryValue(category);

            if (chekSubcategory != content.GetSearchCategoryValue())
            {
                content.ClickSearchCategoryCheck();
            }

            if (checkSearchInDesc != content.GetSearchDescriptionValue())
            {
                content.ClickSearchDescription();
            }

            content.ClickSearchButton();
        }


        #endregion


    }
}