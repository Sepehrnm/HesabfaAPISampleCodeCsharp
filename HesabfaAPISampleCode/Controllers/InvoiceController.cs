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
            var response = await invoiceService.GetInvoice(jsonBody.Number, jsonBody.Type);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            var response = await invoiceService.GetInvoiceById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int type)
        {
            Invoice response = await invoiceService.GetInvoicesList(type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.List));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetOnlineInvoiceURL([FromBody] InvoiceRequest jsonBody)
        {
            OnlineInvoiceURL response = await invoiceService.GetOnlineInvoiceURL(jsonBody.Number, jsonBody.Type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> SavePayment([FromBody] PaymentRequest jsonBody)
        {
            var response = await invoiceService.SavePayment<object>(jsonBody);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] InvoiceRequest jsonBody)
        {
            var response = await invoiceService.Delete(jsonBody.Number, jsonBody.Type);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] InvoiceItem invoice)
        {
            var response = await invoiceService.Save<object>(invoice);
            if (response is InvoiceItem)
            {
                return Ok(response as InvoiceItem);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveWarehouseReceipt([FromBody] WarehouseReceipt receipt)
        {
            var response = await invoiceService.SaveWarehouseReceipt<object>(receipt);
            return Ok(response);
        }
    }
}
