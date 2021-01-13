using BlockCypher.API.Csharp.Client.Domain.Abstract;
using BlockCypher.API.Csharp.Client.Domain.Interfaces;
using BlockCypher.API.Csharp.Client.Models.Enums;
using BlockCypher.API.Csharp.Client.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlockCypher.API.Csharp.Client
{
    public class ApiClient : ApiClientAbstract, IApiClient
    {
        static Policy BinancePolicy;
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="token">Key used to authenticate within the API.</param>
        /// <param name="apiUrl">API base url.</param>
        public ApiClient(string token, string apiUrl = @"https://api.blockcypher.com", bool addDefaultHeaders = true) : base(token, apiUrl, addDefaultHeaders)
        {
            BinancePolicy = Policy.Handle<Exception>(ex => ex.Message.Contains("-1021")).WaitAndRetry(new[]
            {
                    TimeSpan.FromMilliseconds(100),
                    TimeSpan.FromMilliseconds(200),
                    TimeSpan.FromMilliseconds(300)
               }, (exception, timeSpan) =>
               {
                   Console.WriteLine($"Error conecting to binance api. (Timestamp for this request is outside of the recvWindow)" +
                       $"Retrying in {timeSpan.TotalMilliseconds} ms", true, 2);
               });

        }

        /// <summary>
        /// Calls API Methods.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTPMethod (POST-GET-PUT-DELETE)</param>
        /// <param name="endpoint">Url endpoing.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        public async Task<T> CallAsync<T>(ApiMethod method, string endpoint, bool IsTokenRequst = false, string OrgParameters = null,object Content=null)
        {
            return await BinancePolicy.Execute(async () =>
             {
                 var parameters = OrgParameters;

                 var finalEndpoint = endpoint + (string.IsNullOrWhiteSpace(parameters) ? "" : $"?{parameters}");
                 if (IsTokenRequst)
                     finalEndpoint = finalEndpoint + $"?token={_token}";
                 if (!string.IsNullOrEmpty(finalEndpoint) && finalEndpoint.EndsWith("&"))
                     finalEndpoint.Remove(finalEndpoint.Length - 1);

                //if (isSigned)
                //{
                //    // Joining provided parameters
                //    parameters += (!string.IsNullOrWhiteSpace(parameters) ? "&timestamp=" : "timestamp=") + Utilities.GenerateTimeStamp(DateTime.Now.ToUniversalTime());

                //    // Creating request signature
                //    //var signature = Utilities.GenerateSignature(_apiSecret, parameters);
                //    //finalEndpoint = $"{endpoint}?{parameters}&signature={signature}";
                //}
                HttpResponseMessage response = new HttpResponseMessage();

                 if (Content != null)
                 {
                     var Jsontxt = JsonConvert.SerializeObject(Content, Formatting.Indented, new JsonSerializerSettings
                     {
                         NullValueHandling = NullValueHandling.Ignore,
                         DefaultValueHandling = DefaultValueHandling.Ignore
                     });

                     HttpContent content = new StringContent(Jsontxt, System.Text.Encoding.UTF8, "application/json");
                     response = await _httpClient.PostAsync(finalEndpoint, content);
                 }
                 else
                 {
                     var request = new HttpRequestMessage(Utilities.CreateHttpMethod(method.ToString()), finalEndpoint);

                     response =await _httpClient.SendAsync(request);
                 }
                 if (response.IsSuccessStatusCode)
                 {
                    // Get the result
                    var result = await response.Content.ReadAsStringAsync();

                    // Serialize and return result
                    return JsonConvert.DeserializeObject<T>(result);
                 }

                // We received an error
                if (response.StatusCode == HttpStatusCode.GatewayTimeout)
                 {
                     throw new BlockCypherException("Api Request Timeout.");
                 }

                // Get te error code and message
                var e = await response.Content.ReadAsStringAsync();

                // Error Values
                var eCode = 0;
                 string eMsg = "";
                 if (e.IsValidJson())
                 {
                     try
                     {
                         var i = JObject.Parse(e);

                         eCode = i["code"]?.Value<int>() ?? 0;
                         eMsg = i["msg"]?.Value<string>();
                     }
                     catch { }
                 }

                 throw new BlockCypherException(eCode, eMsg);
             });
        }

    }
}
