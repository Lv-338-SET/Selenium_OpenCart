using NUnit.Framework;
using Selenium_OpenCart.Data.Application;
using Selenium_OpenCart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_OpenCart.Tests
{
    [TestFixture]
    class CurrencyTests
    {
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            TestsApplication.Get();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {

            TestsApplication.Remove();
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void CheckChangeProductPriceCurrency()
        {
        }

        [Test]
        public void CheckChangeProductPriceCurrencyInWishList()
        {
        }

        [Test]
        public void CheckChangeProductPriceCurrencyInShopingCart()
        {
        }
    }
}
