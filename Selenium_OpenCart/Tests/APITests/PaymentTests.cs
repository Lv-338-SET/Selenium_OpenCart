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
    [Parallelizable(ParallelScope.All)]
    class PaymentTests
    {
        string api_token;
        [OneTimeSetUp]
        public void BeforeClass()
        {
            APIMethod api = new APIMethod();
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            api_token = (api.ApiGetToken(username, key).Value as ILogin).GetApiToken();
        }
        [Test]
        public void TestApiSetPaymentAddress()
        {
                APIMethod aPIMethod = new APIMethod();
                var expected = aPIMethod.ApiSetPaymentAddress("Customer", "Dear", "Somewhere", "KLD", "RUS", "KGD", api_token);

                Assert.AreEqual(expected.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }

        [Test]
        public void TestApiGetPaymentMethods()
        {
            APIMethod aPIMethod = new APIMethod();
            var expected = aPIMethod.ApiGetPaymentMethods(api_token);

            Assert.AreEqual(expected.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }

        [Test]
        public void TestApiSetPaymentMethod()
        {
            APIMethod aPIMethod = new APIMethod();
            var expected = aPIMethod.ApiSetPaymentMethod("bank_transfer", api_token);

            Assert.AreEqual(expected.Key, HttpStatusCode.OK, "Wrong HTTP code returned");
        }
    }
}
