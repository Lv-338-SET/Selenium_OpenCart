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
using System.Net;

namespace Selenium_OpenCart.Tests.APITests
{
    [TestFixture]
    class LoginTests
    {
        [Test]
        public void TestAPILogin()
        {
            APIMethod api = new APIMethod();
            string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
            string username = "Default";
            var expected = api.ApiGetToken(username, key);

            Assert.AreEqual(expected.Key, HttpStatusCode.OK);
            Assert.IsNotNull((expected.Value as ILogin).GetApiToken());

        }

    }
}

