using NUnit.Framework;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Logic;
using System.Net;
using NLog;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class OrderTests
    {
        const string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
        const string username = "Default";
        string api_token;
        APIMethod api_executor;

        readonly string order_id = "1";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            api_executor = new APIMethod();
            api_token = (api_executor.ApiGetToken(username, key).Value as ILogin).GetApiToken();
        }


        [Test]
        public void AddOrderHTTPStatusTest()
        {
            //Arrange           
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiOrderAdd(api_token).Key;

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }

        [Test]
        public void EditOrderHTTPStatusTest()
        {
            //Arrange           
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiOrderEdit(api_token, order_id).Key;

            //Assert
            Assert.AreEqual(expected, expected, "Error Http status code, " + actual);
        }

        [Test]
        public void DeleteOrderHTTPStatusTest()
        {
            //Arrange           
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiOrderDelete(api_token, order_id).Key;

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }

        [Test]
        public void OrderInfoHTTPStatusTest()
        {
            //Arrange           
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiOrderInfo(api_token, order_id).Key;

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }

        [Test]
        public void OrderHistoryHTTPStatusTest()
        {
            //Arrange           
            var expected = HttpStatusCode.OK;

            //Act
            var actual = api_executor.ApiOrderHistory(api_token, order_id).Key;

            //Assert
            Assert.AreEqual(expected, actual, "Error Http status code, " + actual);
        }
    }
}