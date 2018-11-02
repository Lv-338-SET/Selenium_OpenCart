using NUnit.Framework;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    [Parallelizable]
    class CustomerTest
    {
        string api_token;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            APIMethod api = new APIMethod();
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            var token = (Login)api.ApiGetToken(username, key).Value;
            api_token = token.GetApiToken();
        }   

        [Test]
        public void CustomerAdd()
        {
            APIMethod aPIMethod = new APIMethod();
            var expected = aPIMethod.ApiSetCustomer("Andrii", "Tru", "atv@gmail.com", "+380124565789", api_token);

            Assert.AreEqual(expected.Key, HttpStatusCode.OK);
        }
    }
}
