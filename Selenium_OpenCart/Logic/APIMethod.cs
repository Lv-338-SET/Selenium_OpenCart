using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;
using System.Web.Script.Serialization;
using Selenium_OpenCart.Data.Login;
using Selenium_OpenCart.Data.Message;
using Selenium_OpenCart.Data.Address;
using Selenium_OpenCart.Data.Order;
using Selenium_OpenCart.Data.Product;
using System.Net;

namespace Selenium_OpenCart.Logic
{
    class APIMethod
    {
        public string ApiURL = "http://40.118.125.245/index.php?route=api/";
        public string key = "d5YFz2RyNjnNXpkTqpNaoGAIPHuipKbmKnlRwOP2Jrls05gZJi3hDNbS8Orvbm5XAYJZ1ckrL3SQqikPo1V7FyPPiG7JEfYhWqjLHhjvXb0HED3EyNt2CHSVLzNIlgpzWzjXFh2HiHfCJd2XSubGlCTczDR5uXP2V5rNX1Gjt8uK05Hd1eeRiytEmoIEDjeXW1mw14oL1qxSBATmmv5CZJzmSTayghm2cXWZYw1msbPEhuItfrBzXJcuaV188neq";
        public string Username = "Default";

        public KeyValuePair<HttpStatusCode,string> GetResponceContent(string URLEnd, Method method, List<Parameter> parameters = null)
        {
            string client_string = ApiURL + URLEnd;

            var client = new RestClient(ApiURL + URLEnd);
            var request = new RestRequest(method);

            if (parameters != null)
            {
                foreach (var current in parameters)
                {
                    request.AddParameter(current);
                }
            }

            IRestResponse responsw = client.Execute(request);
            
            return new KeyValuePair<HttpStatusCode, string>(responsw.StatusCode, responsw.Content);
        }

        public IMessage GetErrorMessage(dynamic item) {
            return Message.Get()
                    .SetMessage(item["error"])
                    .SetStatus("error")
                    .Build;
        }

        public IMessage GetSuccessMessage(dynamic item)
        {
            return Message.Get()
                    .SetMessage(item["success"])
                    .SetStatus("success")
                    .Build;
        }
        //
        public KeyValuePair<HttpStatusCode,object> ApiGetToken(string username, string key)
        {

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("username", username, ParameterType.GetOrPost));
            parameters.Add(new Parameter("key", key, ParameterType.GetOrPost));


            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var response = GetResponceContent("login", Method.POST, parameters);

            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, Login.Get()
                    .SetApiToken(item["api_token"])
                    .SetMessage(item["success"])
                    .Build());
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiSetCurrency(string code, string api_token)
        {

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("currency", code, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("currency", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key,GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiAddProductToCart(int product_id, int quantity, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("product_id", product_id, ParameterType.GetOrPost));
            parameters.Add(new Parameter("quantity", quantity, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("cart/add", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key,GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key,GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiEditProductQuantityCart(int key, int quantity, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("key", key, ParameterType.GetOrPost));
            parameters.Add(new Parameter("quantity", quantity, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response =GetResponceContent("cart/edit", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiRemoveProductFromCart(int key, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("key", key, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("cart/remove", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiGetCartContent(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("cart/products", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                List<IProduct> result = new List<IProduct>();
                foreach (var current in item["products"])
                {
                    result.Add(Product.Get()
                            .SetName(current["name"])
                            .SetID(Int32.Parse(current["product_id"]))
                            .SetPrice(Convert.ToDouble(current["price"]))
                            .SetQuantity(Int32.Parse(current["quantity"]))
                            .Build());
                }
                return new KeyValuePair<HttpStatusCode, object>(response.Key, result);
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiApplyExistingCoupon(string coupon, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("coupon", coupon, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("coupon", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiSetCustomer(string firstname, string lastname, string email, string telephone, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("firstname", firstname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("lastname", lastname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("email", email, ParameterType.GetOrPost));
            parameters.Add(new Parameter("telephone", telephone, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("customer", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiApplyExistingVoucher(string voucher, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("voucher", voucher, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("voucher", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiAddVoucher(string from_name, string from_email, string to_name, string to_email, string amount, string code, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter("from_name", from_name, ParameterType.GetOrPost));
            parameters.Add(new Parameter("from_email", from_email, ParameterType.GetOrPost));
            parameters.Add(new Parameter("to_name", to_name, ParameterType.GetOrPost));
            parameters.Add(new Parameter("to_email", to_email, ParameterType.GetOrPost));
            parameters.Add(new Parameter("amount", amount, ParameterType.GetOrPost));
            parameters.Add(new Parameter("code", code, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("voucher/add", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiSetShippingAddress(string firstname, string lastname, string address_1, string city, string country_id, string zone_id, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter("firstname ", firstname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("lastname ", lastname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("address_1 ", address_1, ParameterType.GetOrPost));
            parameters.Add(new Parameter("city ", city, ParameterType.GetOrPost));
            parameters.Add(new Parameter("country_id ", country_id, ParameterType.GetOrPost));
            parameters.Add(new Parameter("zone_id", zone_id, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("shipping/address", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, (Dictionary<string, object> ) item["error"]);
            }

        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiGetAvaliableShippingMethods(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("shipping/methods", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key,(Dictionary<string, object>)item["shipping_methods"]);
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiShippingMethod(string shipping_method, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("shipping_method", shipping_method, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("shipping/method", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key,GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, string> ApiGetReward(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            return GetResponceContent("reward", Method.POST, parameters);
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiGetRewardMaximum(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("reward/maximum", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key,Message.Get()
                    .SetMessage(item["maximum"])
                    .SetStatus("maximum")
                    .Build);
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, string> ApiGetRewardAvaliable(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            
            return GetResponceContent("reward/avaliable", Method.POST, parameters);
        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiOrderAdd(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("order/add", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, Order.Get()
                    .SetOrderID(item["order_id"])
                    .SetMessage(GetSuccessMessage(item))
                    .Build());
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiOrderEdit(string api_token, string order_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            parameters.Add(new Parameter("order_id", order_id, ParameterType.GetOrPost));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("order/edit", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiOrderDelete(string api_token, string order_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            parameters.Add(new Parameter("order_id", order_id, ParameterType.GetOrPost));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("order/delete", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiOrderInfo(string api_token, string order_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            parameters.Add(new Parameter("order_id", order_id, ParameterType.GetOrPost));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("order/info", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiOrderHistory(string api_token, string order_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));
            parameters.Add(new Parameter("order_id", order_id, ParameterType.GetOrPost));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("order/history", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, item["order"]);
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, object> ApiSetPaymentAddress(string firstname, string lastname, string address_1, string city, string country_id, string zone_id, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.Add(new Parameter("firstname ", firstname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("lastname ", lastname, ParameterType.GetOrPost));
            parameters.Add(new Parameter("address_1 ", address_1, ParameterType.GetOrPost));
            parameters.Add(new Parameter("city ", city, ParameterType.GetOrPost));
            parameters.Add(new Parameter("country_id ", country_id, ParameterType.GetOrPost));
            parameters.Add(new Parameter("zone_id", zone_id, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("payment/address", Method.POST, parameters);

            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, object>(response.Key, (Dictionary<string, object>)item["error"]);
            }
        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiGetPaymentMethods(string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("payment/methods", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }

        }
        //
        public KeyValuePair<HttpStatusCode, IMessage> ApiSetPaymentMethod(string payment_method, string api_token)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("payment_method", payment_method, ParameterType.GetOrPost));
            parameters.Add(new Parameter("api_token", api_token, ParameterType.QueryString));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var response = GetResponceContent("payment/method", Method.POST, parameters);
            dynamic item = serializer.Deserialize<object>(response.Value);

            try
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetSuccessMessage(item));
            }
            catch
            {
                return new KeyValuePair<HttpStatusCode, IMessage>(response.Key, GetErrorMessage(item));
            }
        }

    }
}
