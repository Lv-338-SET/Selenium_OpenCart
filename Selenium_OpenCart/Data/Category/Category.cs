using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Category
{
    public class Category : ICategory, ICategoryBuilder, ISetName
    {
        private int ID;
        private string name;
        private string description;
        private int parent;

        private Category()
        {

        }

        public ICategory Build()
        {
            return this;
        }

        public static ISetName Get()
        {
            return new Category();
        }

        public ICategoryBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public ICategoryBuilder SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public ICategoryBuilder SetID(int id)
        {
            this.ID = id;
            return this;
        }

        public ICategoryBuilder SetParent(int parent)
        {
            this.parent = parent;
            return this;
        }

        public string GetName()
        {
            return name;
        }

        
        public string GetDescription()
        {
            return description;
        }

        public double GetID()
        {
            return ID;
        }

        public int GetParent()
        {
            return parent;
        }

    }

    public interface ICategory
    {
        string GetName();
        string GetDescription();
        double GetID();
        int GetParent();
    }

    public interface ICategoryBuilder
    {
        ICategoryBuilder SetParent(int parent);
        ICategoryBuilder SetDescription(string description);
        ICategoryBuilder SetID(int id);

        ICategory Build();
    }

    public interface ISetName
    {
        ICategoryBuilder SetName(string name);
    }


}
