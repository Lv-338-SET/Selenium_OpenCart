using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Data.Address
{
    public class Adress : 
        IAdress, 
        IAdressBuilder, 
        ISetFirstName, 
        ISetLastName, 
        ISetAddress1, 
        ISetCity, 
        ISetPostCode, 
        ISetCountry, 
        ISetRegion
    {
        private int ID;
        
        private string firstname;
        private string lastname;
        private string company;
        private string address_1;
        private string address_2;
        private string city;
        private string postcode;
        private string country;
        private string zone;
        private string custom_field;

      
        private Adress()
        {

        }
        
        public IAdress Build()
        {
            return this;
        }

        public static ISetFirstName Get()
        {
            return new Adress();
        }

        public string GetAddress1()
        {
            return address_1;
        }

        public string GetAddress2()
        {
            return address_2;
        }

        public string GetCity()
        {
            return city;
        }

        public string GetCompany()
        {
            return company;
        }

        public string GetCountry()
        {
            return country;
        }

        public string GetCustomField()
        {
            return custom_field;
        }

        public string GetFirstName()
        {
            return firstname;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetLastName()
        {
            return lastname;
        }

        public string GetPostCode()
        {
            return postcode;
        }

        public string GetZone()
        {
            return zone;
        }

        public ISetCity SetAddress1(string adress_1)
        {
            this.address_1 = adress_1;
            return this;
        }

        public IAdressBuilder SetAddress2(string address_2)
        {
            this.address_2 = address_2;
            return this;
        }

        public ISetPostCode SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public IAdressBuilder SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public ISetRegion SetCountry(string country)
        {
            this.country = country;
            return this;
        }
        

        public IAdressBuilder SetCustomField(string custom_field)
        {
            this.custom_field = custom_field;
            return this;
        }

        public ISetLastName SetFirstName(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public IAdressBuilder SetID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ISetAddress1 SetLastName(string lastname)
        {
            this.lastname = lastname;
            return this;
        }

        public ISetCountry SetPostCode(string post_code)
        {
            this.postcode = post_code;
            return this;
        }

        public IAdressBuilder SetRegion(string zone)
        {
            this.zone = zone;
            return this;
        }
    }

    public interface IAdress
    {
        int GetID();
        string GetFirstName();
        string GetLastName();
        string GetCompany();
        string GetAddress1();
        string GetAddress2();
        string GetCity();
        string GetPostCode();
        string GetCountry();
        string GetZone();
        string GetCustomField();
    }

    public interface IAdressBuilder
    {
        IAdressBuilder SetID(int ID);
        IAdressBuilder SetCompany(string company);
        IAdressBuilder SetAddress2(string address_2);
        IAdressBuilder SetCustomField(string custom_field);

        IAdress Build();
    }

    public interface ISetFirstName
    {
        ISetLastName SetFirstName(string firstname);
    }
    public interface ISetLastName
    {
        ISetAddress1 SetLastName(string lastname);
    }
    public interface ISetAddress1
    {
        ISetCity SetAddress1(string adress_1);
    }
    public interface ISetCity
    {
        ISetPostCode SetCity(string city);
    }
    public interface ISetPostCode
    {
        ISetCountry SetPostCode(string post_code);
    }
    public interface ISetCountry
    {
        ISetRegion SetCountry(string country);
    }
    public interface ISetRegion
    {
        IAdressBuilder SetRegion(string zone);
    }


}
