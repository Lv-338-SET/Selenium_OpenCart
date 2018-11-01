using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using Selenium_OpenCart.Logic;
using Selenium_OpenCart.Data.Search;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Data.Message;
using Selenium_OpenCart.Data.Order;
using System.Net;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    [Parallelizable]
    class APITests
    {
        string username;
        string key;
        APIMethod api;

        [SetUp]
        public void SetUp()
        {
            api = new APIMethod();
            key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            username = "Default";            
        }

        [Test]
        public void TestAPILogin()
        {
            var expected = api.ApiGetToken(username, key);
            
            string api_token = (expected.Value as ILogin).GetApiToken();

            Assert.IsNotNull((expected.Value as ILogin).GetApiToken());
            Assert.AreEqual(expected.Key, HttpStatusCode.OK);   
        }

        [TestCase ("USD")]
        [TestCase("GBP")]
        public void TestAPICurrency(string code)
        {
            var login = api.ApiGetToken(username, key);
            string api_token = (login.Value as ILogin).GetApiToken();

            var expected = api.ApiSetCurrency(code, api_token);

            Assert.AreEqual(expected.Value.GetStatus(),"success");
            Assert.AreEqual(expected.Key, HttpStatusCode.OK);
        }

        [TestCase(28,1)]
        public void TestAPIAddProductToCart(int product_id, int quantity)
        {
            var login = api.ApiGetToken(username, key);
            string api_token = (login.Value as ILogin).GetApiToken();

            var expected = api.ApiAddProductToCart(product_id,quantity, api_token);

            Assert.AreEqual(expected.Value.GetStatus(), "success");
            Assert.AreEqual(expected.Key, HttpStatusCode.OK);
        }


    }
}

