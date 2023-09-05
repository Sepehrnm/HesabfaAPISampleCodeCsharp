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
        public Task<ApiResult<T>> Post<T>(string method);
        public Task<ApiResult<T>> Post<T>(string method, (string, object) parameter);
        public Task<ApiResult<T>> Post<T>(string method, List<(string, object)> parameters);
    }

    public class BaseService : IBaseService
    {
        private readonly string loginToken;
        private readonly string apiKey;

        public BaseService()
        {
            //Add your login token and api key here properly
            loginToken = "#";
            apiKey = "#";
        }

        public async Task<ApiResult<T>> Post<T>(string method)
        {
            return await Post<T>(method, null);
        }
        public async Task<ApiResult<T>> Post<T>(string method, (string, object) parameter)
        {
            return await Post<T>(method, new List<(string, object)> { parameter });
        }

        public async Task<ApiResult<T>> Post<T>(string method, List<(string, object)> parameters)
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

            var response = await client.PostAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Request failed!");
            }

            var result = JsonConvert.DeserializeObject<ApiResult<T>>(response.Content);

            CheckResult(result);

            return result;
        }

        public ApiResult<T> CheckResult<T>(ApiResult<T> result)
        {
            if (result == null)
            {
                result = new ApiResult<T>
                {
                    Success = false,
                    ErrorMessage = "Could not receive data from hesabfa servers",
                    ErrorCode = 100
                };
            }

            if (!result.Success)
            {
                result = new ApiResult<T>
                {
                    Success = false,
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            return result;
        }
    }
}
