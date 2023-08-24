using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Pages;
using HesabfaAPISampleCode.Pages.Contact;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Dynamic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Channels;

namespace HesabfaAPISampleCode.Services
{
    public interface IBaseService
    {
        public ApiResult<T> Post<T>(string method);
        public ApiResult<T> Post<T>(string method, (string, object) parameter);
        public ApiResult<T> Post<T>(string method, List<(string, object)> parameters);
    }

    public class BaseService : IBaseService
    {
        private readonly string loginToken;
        private readonly string apiKey;

        public BaseService()
        {
            loginToken = "af014d3ed841a5d23bfd378670e2fc7e2e15d42b606f62e6a719be090b501343f45531c55f640319dd131dd9649c3709";
            apiKey = "QZAIlbJQnCGENqB1lV0Ygx4rTIfln1yg";
        }

        public ApiResult<T> Post<T>(string method)
        {
            return Post<T>(method, null);
        }
        public ApiResult<T> Post<T>(string method, (string, object) parameter)
        {
            return Post<T>(method, new List<(string, object)> { parameter });
        }

        public ApiResult<T> Post<T>(string method, List<(string, object)> parameters)
        {
            var client = new RestClient("https://api.hesabfa.com/v1/");
            var request = new RestRequest(method);

            var body = new Dictionary<string, object>();
            body["apiKey"] = apiKey;
            body["loginToken"] = loginToken;

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    body[item.Item1] = item.Item2;
                }
            }

            request.AddJsonBody(body);

            var response = client.Post(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Request failed!");
            }

            var result = JsonConvert.DeserializeObject<ApiResult<T>>(response.Content);

            CheckResult(result);

            return result;
        }

        public void CheckResult<T>(ApiResult<T> result)
        {
            if (result == null)
                throw new Exception("Could not receive data from hesabfa servers");

            if (!result.Success)
            {
                throw new Exception(result.ErrorCode + ": " + result.ErrorMessage);
            }
        }
    }
}
