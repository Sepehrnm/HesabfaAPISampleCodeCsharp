using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpPost]
        public IActionResult GetList([FromBody] int take)
        {
            var response = documentService.GetList(take);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult Get([FromBody] int number)
        {
            var response = documentService.Get(number);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult Delete([FromBody] int number)
        {
            var response = documentService.Delete(number);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Document document)
        {
            var response = documentService.Save<object>(document);
            if (response is Document)
            {
                return Ok(response as Document);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
