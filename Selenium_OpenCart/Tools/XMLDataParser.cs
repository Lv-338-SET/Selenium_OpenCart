using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Data.Product;
using Selenium_OpenCart.Data.Currency;
using Selenium_OpenCart.Data.ProductReview;

using Selenium_OpenCart.Data.User;
using Selenium_OpenCart.Data.Category;
using Selenium_OpenCart.Data.Cart;
using Selenium_OpenCart.Data.Search;
using System.Xml;
using EasyEncryption;


namespace Selenium_OpenCart.Tools
{
    public class XMLDataParser
    {
        const string XML_PATH = "Selenium_OpenCart/XML/";
        const string PRODUCT_FILE_NAME = "product.xml";
        const string CART_FILE_NAME = "cart.xml";
        const string CATEGORY_FILE_NAME = "category.xml";
        const string CURRENCY_FILE_NAME = "currency.xml";
        const string PRODUCT_REVIEW_FILE_NAME = "product_review.xml";
        const string RATING_FILE_NAME = "rating.xml";
        const string USER_FILE_NAME = "user.xml";
        const string SEARCH_FILE_NAME = "search.xml";

        public ISearch GetSearchInputData() {

            XmlDocument doc = new XmlDocument();
            doc.Load(XML_PATH + SEARCH_FILE_NAME);
            XmlElement node = doc.DocumentElement;
            return Search.Get()
                    .SetName(node.GetElementsByTagName("search")[0].InnerText)
                    .SetCategory(node.GetElementsByTagName("category")[0].InnerText)
                    .SetCount(Int32.Parse(node.GetElementsByTagName("count")[0].InnerText))
                    .Build();
        }

        public IUser GetUserInputData()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(XML_PATH + USER_FILE_NAME);
            XmlElement node = doc.DocumentElement;
            return User.Get()
                    .SetUsername(node.GetElementsByTagName("username")[0].InnerText)
                    .SetPassword(HashPassword(node.GetElementsByTagName("password")[0].InnerText,
                                 node.GetElementsByTagName("sault")[0].InnerText))
                    .Build();
        }


        public IProduct GetInputProduct() {

            XmlDocument doc = new XmlDocument();
            doc.Load(XML_PATH + PRODUCT_FILE_NAME);
            XmlElement node = doc.DocumentElement;

            string str = node.GetElementsByTagName("name")[0].InnerText;

            return Product.Get()
                .SetName(node.GetElementsByTagName("name")[0].InnerText)
                .SetDescription(node.GetElementsByTagName("description")[0].InnerText)
                .SetID(Int32.Parse(node.GetElementsByTagName("id")[0].InnerText))
                .SetImage(node.GetElementsByTagName("image")[0].InnerText)
                .SetPrice(Double.Parse(node.GetElementsByTagName("price")[0].InnerText))
                .SetQuantity(Int32.Parse(node.GetElementsByTagName("quantity")[0].InnerText))
                .Build();

        }


        public void CreateProductXML(string name, string description, double price, int quantity, string image = "") {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("product"));
            el.AppendChild(doc.CreateElement("name")).InnerText = name;
            el.AppendChild(doc.CreateElement("description")).InnerText = description;
            el.AppendChild(doc.CreateElement("image")).InnerText = image;
            el.AppendChild(doc.CreateElement("price")).InnerText = price.ToString();
            el.AppendChild(doc.CreateElement("quantity")).InnerText = quantity.ToString();
            doc.Save("product.xml");   
        }
        public void CreateCartXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("cart"));
            el.AppendChild(doc.CreateElement("id")).InnerText = "1";
            el.AppendChild(doc.CreateElement("customer_id")).InnerText = "5";
            el.AppendChild(doc.CreateElement("session_id")).InnerText = "1";
            el.AppendChild(doc.CreateElement("product_id")).InnerText = "12";
            el.AppendChild(doc.CreateElement("date")).InnerText = "20/16/5200";

            doc.Save("cart.xml");

        }
        public void CreateCategoryXML(string name, string description)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("category"));
            el.AppendChild(doc.CreateElement("id")).InnerText = "2";
            el.AppendChild(doc.CreateElement("name")).InnerText = name;
            el.AppendChild(doc.CreateElement("description")).InnerText = description;
            el.AppendChild(doc.CreateElement("parent")).InnerText = "2";
            doc.Save("category.xml");
        }
        public void CreateCurrencyXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("currency"));
            el.AppendChild(doc.CreateElement("pound")).InnerText = "1,2";
            el.AppendChild(doc.CreateElement("dollar")).InnerText = "0,6";
            el.AppendChild(doc.CreateElement("euro")).InnerText = "1,2";

            doc.Save("currency.xml");

        }
        public void CreateProductReviewXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("productreview"));
            el.AppendChild(doc.CreateElement("productname")).InnerText = "PName1";
            el.AppendChild(doc.CreateElement("reviewername")).InnerText = "RName1";
            el.AppendChild(doc.CreateElement("reviewtext")).InnerText = "Text";
            el.AppendChild(doc.CreateElement("rating")).InnerText = "1";
            el.AppendChild(doc.CreateElement("date")).InnerText = "20/20/2000";

            doc.Save("productreview.xml");

        }
        public void CreateUserXML(string user, string password)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("user"));
            el.AppendChild(doc.CreateElement("id")).InnerText = "12";
            el.AppendChild(doc.CreateElement("username")).InnerText = user;
            el.AppendChild(doc.CreateElement("password")).InnerText = password;
            el.AppendChild(doc.CreateElement("firstname")).InnerText = "firstname1";
            el.AppendChild(doc.CreateElement("lastname")).InnerText = "lastname1";
            el.AppendChild(doc.CreateElement("email")).InnerText = user;
            el.AppendChild(doc.CreateElement("telephone")).InnerText = "telephone1";
            el.AppendChild(doc.CreateElement("subscribe")).InnerText = "1";


            doc.Save("user.xml");

        }

        public void CreateSearchXML() { }

        public string HashPassword(string password, string sault) {

            return SHA.ComputeSHA1Hash(String.Concat(sault, SHA.ComputeSHA1Hash(
                String.Concat(sault, SHA.ComputeSHA1Hash(password))
                )));
        }

    }
}
