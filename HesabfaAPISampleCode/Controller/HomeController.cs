using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using RestSharp;
using RestSharp.Authenticators;

namespace HesabfaAPISampleCode.Controller
{
    public class HomeController : ControllerBase
    {
        public Function GetBanks()
            {
                var options = new RestClientOptions("https://api.hesabfa.com/v1");

                var client = new RestClient(options);

                var request = new RestRequest("/setting/getbanks");

                request.AddJsonBody(
                    "apiKey:QZAIlbJQnCGENqB1lV0Ygx4rTIfln1yg" +
                    "loginToken:af014d3ed841a5d23bfd378670e2fc7e2e15d42b606f62e6a719be090b501343f45531c55f640319dd131dd9649c3709" +
                );

                var response = client.Post(request);

                return (Function)(IActionResult)response;
            }
        }
    }
}
