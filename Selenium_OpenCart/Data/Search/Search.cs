using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_OpenCart.Data.Search
{
    public class Search : ISearch, ISearchBuilder, ISetName
    {
        private string name;
        private string category;
        private int count;

        private Search()
        {

        }

        public ISearch Build()
        {
            return this;
        }

        public static ISetName Get()
        {
            return new Search();
        }

        public ISearchBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public ISearchBuilder SetCategory(string category)
        {
            this.category = category;
            return this;
        }

        public ISearchBuilder SetCount(int count)
        {
            this.count = count;
            return this;
        }

        public string GetName()
        {
            return name;
        }

        public string GetCategory()
        {
            return category;
        }

        public int GetCount()
        {
            return count;
        }

        public IWebElement ElementByCssSelector(string v)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISearch
    {
        string GetName();
        string GetCategory();
        int GetCount();
        IWebElement ElementByCssSelector(string v);
    }

    public interface ISearchBuilder
    {
        ISearchBuilder SetCategory(string category);
        ISearchBuilder SetCount(int count);

        ISearch Build();
    }

    public interface ISetName
    {
        ISearchBuilder SetName(string name);
    }
}