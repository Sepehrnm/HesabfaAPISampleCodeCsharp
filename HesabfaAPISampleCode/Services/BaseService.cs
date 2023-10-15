using HesabfaAPISampleCode.Models;
using Newtonsoft.Json;
using RestSharp;

namespace HesabfaAPISampleCode.Services
{
    public interface IBaseService
    {
        public Task<T> Post<T>(string method);
        public Task<T> Post<T>(string method, (string, object) parameter);
        public Task<T> Post<T>(string method, List<(string, object)> parameters);
    }

    public class BaseService : IBaseService
    {
        private readonly string loginToken;
        private readonly string apiKey;

        public BaseService()
        {
            //Add your login token and api key here properly
            loginToken = "af014d3ed841a5d23bfd378670e2fc7e2e15d42b606f62e6a719be090b501343f45531c55f640319dd131dd9649c3709";
            apiKey = "QZAIlbJQnCGENqB1lV0Ygx4rTIfln1yg";
        }

        public async Task<T> Post<T>(string method)
        {
            return await Post<T>(method, null);
        }
        public async Task<T> Post<T>(string method, (string, object) parameter)
        {
            return await Post<T>(method, new List<(string, object)> { parameter });
        }

        public async Task<T> Post<T>(string method, List<(string, object)> parameters)
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

            if(response.Content == null)
                throw new Exception("Unable to retrieve data");

            var result = JsonConvert.DeserializeObject<ApiResult<T>>(response.Content);

            if (result == null)
            {
                throw new Exception("Unable to retrieve data");
            }

            if (!result.Success)
            {
                throw new Exception($"ErrorCode: {result.ErrorCode} - {result.ErrorMessage}");
            }

            return result.Result;
        }
    }
}
