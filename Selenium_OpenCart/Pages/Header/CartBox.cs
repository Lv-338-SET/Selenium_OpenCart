using OpenQA.Selenium;
using System.Threading;

namespace Selenium_OpenCart.Pages.Header
{
    public class CartBox : Header
    {
        protected IWebElement Image { get { return Search.ElementByXPath("//td[@class='text-center']//img"); } }
        protected IWebElement ProductName { get { return Search.ElementByCssSelector(".text-left >a"); } }
        protected IWebElement Quantity { get { return Search.ElementByXPath("//td[@class='text-right' and string-length(text()) > 0]"); } }
        protected IWebElement ProductPrice { get { return Search.ElementByXPath("//td[@class='text-right' and not(contains(text(),'"+GetProductPrice()+"'))]"); } }
        public CartBox()
        {

        }
        #region Atomic Operations
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetQuantity()
        {
            return Quantity.Text;
        }
        public string GetProductPrice()
        {
            Thread.Sleep(2000);
            return ProductPrice.Text;
        }
        #endregion
    }
}
