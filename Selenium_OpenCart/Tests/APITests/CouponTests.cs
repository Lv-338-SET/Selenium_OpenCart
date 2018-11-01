using NUnit.Framework;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Logic;
using System.Net;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class CouponTests
    {
        string api_token;
        readonly string coupon_code = "2222";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            APIMethod api = new APIMethod();
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            api_token = (api.ApiGetToken(username, key).Value as ILogin).GetApiToken();
        }

        [Test]
        public void AddOrderHTTPStatusTest()
        {
            APIMethod api = new APIMethod();
            var expected = api.ApiApplyExistingCoupon(coupon_code, api_token).Key;

            Assert.AreEqual(expected, HttpStatusCode.OK);
        }
    }
}
