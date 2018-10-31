using NUnit.Framework;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Logic;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    class CartTest
    {
        string api_token;

        [OneTimeSetUp]
        public void StartBeforeTests()
        {
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            APIMethod api = new APIMethod();
            api_token = (api.ApiGetToken(username, key).Value as ILogin).GetApiToken();
        }
        
        [Test]
        public void CartEditTest()
        {
            APIMethod api = new APIMethod();
            var result = api.ApiEditProductQuantityCart(40, 2, api_token);
            Assert.AreEqual(result.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }

        [Test]
        public void CartRemoveTest()
        {
            APIMethod api = new APIMethod();
            var result = api.ApiRemoveProductFromCart(40, api_token);
            Assert.AreEqual(result.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }

        [Test]
        public void CartProductsTest()
        {
            APIMethod api = new APIMethod();
            var result = api.ApiGetCartContent(api_token);
            Assert.AreEqual(result.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }

    }
}
