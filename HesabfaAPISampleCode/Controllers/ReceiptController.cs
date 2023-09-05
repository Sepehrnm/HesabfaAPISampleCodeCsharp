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
        public async Task<IActionResult> Get([FromBody] ReceiptRequest jsonBody)
        {
            var response = await receiptService.GetReceipt<object>(jsonBody.type, jsonBody.number);

            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] ReceiptRequest jsonBody)
        {
            var response = await receiptService.DeleteReceipt<object>(jsonBody.type, jsonBody.number);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int type)
        {
            Receipt response = await receiptService.GetReceipts(type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveReceiptItem receipt)
        {
            object response = await receiptService.SaveReceipt(receipt);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }
    }
}
