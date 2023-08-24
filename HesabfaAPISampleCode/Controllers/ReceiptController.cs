using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService receiptService;
        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [HttpPost]
        public IActionResult Get([FromBody] ReceiptRequest jsonBody)
        {
            ReceiptItem response = receiptService.GetReceipt(jsonBody.type, jsonBody.number);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult Delete([FromBody] ReceiptRequest jsonBody)
        {
            var response = receiptService.DeleteReceipt(jsonBody.type, jsonBody.number);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetList([FromBody] int type)
        {
            Receipt response = receiptService.GetReceipts(type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult Save([FromBody] SaveReceiptItem receipt)
        {
            object response = receiptService.SaveReceipt(receipt);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }
    }
}
