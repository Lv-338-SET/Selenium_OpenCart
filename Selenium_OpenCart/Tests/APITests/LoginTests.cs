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
using System.Net;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    class LoginTests
    {
        [Test]
        public void TestAPILogin()
        {
           
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            //var expected = api.ApiGetToken(username, key);
            //(expected.Value as IMessage).GetMessage();
            //string a[pi_token = (expected as ILogin).GetApiToken();

            APIMethod api = new APIMethod();

            string api_token = (api.ApiGetToken(username, key).Value as ILogin).GetApiToken();

            var result = api.ApiSetCurrency("USD", api_token);
            result.Value.GetMessage();


            //Assert.IsNotNull((expected.Value as ILogin).GetApiToken());
            //Assert.AreEqual(expected.Key, HttpStatusCode.OK);
        }

    }
}

