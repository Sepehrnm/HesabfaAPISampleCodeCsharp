using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await receiptService.GetReceipt((int)jsonBody.Type, jsonBody.Number));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] ReceiptRequest jsonBody)
        {
            return Ok(await receiptService.DeleteReceipt((int)jsonBody.Type, jsonBody.Number));
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int type)
        {
            return Ok(await receiptService.GetReceipts(type));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveReceiptItem receipt)
        {
            return Ok(await receiptService.SaveReceipt(receipt));
        }
    }
}
