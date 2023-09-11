using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] InvoiceRequest jsonBody)
        {
            return Ok(await invoiceService.GetInvoice(jsonBody.Number, (int)jsonBody.Type));
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            return Ok(await invoiceService.GetInvoiceById(id));
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int type)
        {
            return Ok(await invoiceService.GetInvoicesList(type));
        }

        [HttpPost]
        public async Task<IActionResult> GetOnlineInvoiceURL([FromBody] InvoiceRequest jsonBody)
        {
            var response = await invoiceService.GetOnlineInvoiceURL(jsonBody.Number, (int)jsonBody.Type);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SavePayment([FromBody] PaymentRequest jsonBody)
        {
            return Ok(await invoiceService.SavePayment(jsonBody));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] InvoiceRequest jsonBody)
        {
            return Ok(await invoiceService.Delete(jsonBody.Number, (int)jsonBody.Type));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Invoice invoice)
        {
            return Ok(await invoiceService.Save(invoice));
        }

        [HttpPost]
        public async Task<IActionResult> SaveWarehouseReceipt([FromBody] WarehouseReceipt receipt)
        {
            return Ok(await invoiceService.SaveWarehouseReceipt(receipt));
        }
    }
}
