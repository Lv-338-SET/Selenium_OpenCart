using NUnit.Framework;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Data.Message;
using Selenium_OpenCart.Logic;
using System.Net;
using System;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class CouponTests
    {
        const string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
        const string username = "Default";
        string api_token;
        APIMethod api_executor;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            api_executor = new APIMethod();
            api_token = (api_executor.ApiGetToken(username, key).Value as ILogin).GetApiToken();
        }

        [TestCase("2222")]
        public void CouponHttpStatusCodeTest(string coupon_code)
        {
            //Arrange            
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiApplyExistingCoupon(coupon_code, api_token).Key;

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }

        [TestCase("2222")]
        public void ApplyCouponTest(string coupon_code)
        {
            //Arrange 
            string expected = "error";

            //Act
            string actual = api_executor.ApiApplyExistingCoupon(coupon_code, api_token).Value.GetStatus();

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }

        [TestCase("0000")]
        public void ApplyCouponInvalidTest(string coupon_code)
        {
            //Arrange 
            string expected = "error";

            //Act
            string actual = api_executor.ApiApplyExistingCoupon(coupon_code, api_token).Value.GetStatus();

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }
    }
}