using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSite.Logic;

namespace TestSite.Pages
{
    class Content : Header
    {

        protected IWebElement searchLabel { get; private set; }
        protected IWebElement searchTextBoxInsideContent { get; private set; }
        protected IWebElement searchCategoryCheck { get; private set; }
        protected IWebElement searchDescriptionChek { get; private set; }
        protected IWebElement searchButtonInsideContent { get; private set; }
        protected IWebElement listShowButton { get; private set; }
        protected IWebElement gridShowButton { get; private set; }
        protected IWebElement productCompareLabel { get; private set; }
        protected IWebElement productPageLabel { get; private set; }

        protected SelectElement selectCategory { get; private set; }
        protected SelectElement selectSortBy { get; private set; }
        protected SelectElement selectShow { get; private set; }

        protected List<ProductItem> listProduct;

        public Content(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

            this.searchLabel = driver.FindElement(By.CssSelector("#content h1"));
            this.searchTextBoxInsideContent = driver.FindElement(By.Id("input-search"));
            this.searchCategoryCheck = driver.FindElement(By.Name("sub_category"));
            this.searchDescriptionChek = driver.FindElement(By.Name("description"));
            this.searchButtonInsideContent = driver.FindElement(By.Id("button-search"));
            this.listShowButton = driver.FindElement(By.Id("list-view"));
            this.gridShowButton = driver.FindElement(By.Id("grid-view"));
            this.productCompareLabel = driver.FindElement(By.Id("compare-total"));
            this.productPageLabel = driver.FindElement(By.ClassName("text-right"));

            this.selectCategory = new SelectElement(driver.FindElement(By.Name("category_id")));
            this.selectSortBy = new SelectElement(driver.FindElement(By.Id("input-sort")));
            this.selectShow = new SelectElement(driver.FindElement(By.Id("input-limit")));

            var elements = driver.FindElements(By.ClassName("product-layout"));
            this.listProduct = new List<ProductItem>();

            foreach (var current in elements) {
                this.listProduct.Add(new ProductItem(driver, current));
            }
        }

        public List<ProductItem> GetListProduct() {
            return this.listProduct;
        }

        public string GetTextFromSearchLabel() {
            return this.searchLabel.Text;
        }

        public Content ClearsearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Clear();
            return this;
        }
        public Content ClicksearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Click();
            return this;
        }
        public Content SetTextInsearchTextBoxInsideContent(string text)
        {
            this.searchTextBoxInsideContent.SendKeys(text);
            return this;
        }
        public string GetTextFromsearchTextBoxInsideContent()
        {
            return this.searchTextBoxInsideContent.Text;
        }

        public Content ClickSearchCategoryCheck() {
            this.searchCategoryCheck.Click();
            return this;
        }
        public bool GetSearchCategoryValue() {
            return this.searchCategoryCheck.Selected;
        }

        public bool GetSearchDescriptionValue()
        {
            return this.searchDescriptionChek.Selected;
        }
        public Content ClickSearchDescription()
        {
            this.searchDescriptionChek.Click();
            return this;
        }

        public Content ClickSearchButtonInsideContent() {
            this.searchButtonInsideContent.Click();
            return new Content(this.driver);
        }

        public Content ClickListShowButton()
        {
            this.listShowButton.Click();
            return this;
        }

        public Content ClickGridShowButton()
        {
            this.gridShowButton.Click();
            return this;
        }

        public Content ClickProductCompareLabel() {
            this.productCompareLabel.Click();
            return this;
        }
        public string GetProductCompareText() {
            return this.productCompareLabel.Text;
        }

        public string GetProductPageLabelText()
        {
            return this.productPageLabel.Text;
        }

        public List<string> GetListOfCategories() {
            List<string> list = new List<string>();
            foreach (var current in this.selectCategory.Options) {
                list.Add(current.Text);
            }
            return list;
        }

        public Content SetCategoryValue(string category) {
            this.selectCategory.SelectByText(category);
            return this;
        }
        public string GetSelectedCategory() {
            return this.selectCategory.SelectedOption.Text;
        }

        public Content SetSortedByValue(string sorted)
        {
            this.selectSortBy.SelectByText(sorted);
            return this;
        }
        public string GetSelectedSortBy()
        {
            return this.selectSortBy.SelectedOption.Text;
        }

        public Content SetShowValue(string category)
        {
            this.selectShow.SelectByText(category);
            return this;
        }
        public string GetSelectedShow()
        {
            return this.selectShow.SelectedOption.Text;
        }



    }
}
