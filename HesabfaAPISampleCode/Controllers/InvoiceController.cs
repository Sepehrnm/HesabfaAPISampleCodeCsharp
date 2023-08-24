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
        public IActionResult Get([FromBody] InvoiceRequest jsonBody)
        {
            var response = invoiceService.GetInvoice(jsonBody.Number, jsonBody.Type);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetById([FromBody] int id)
        {
            var response = invoiceService.GetInvoiceById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetList([FromBody] int type)
        {
            Invoice response = invoiceService.GetInvoicesList(type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.List));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetOnlineInvoiceURL([FromBody] InvoiceRequest jsonBody)
        {
            OnlineInvoiceURL response = invoiceService.GetOnlineInvoiceURL(jsonBody.Number, jsonBody.Type);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult SavePayment([FromBody] PaymentRequest jsonBody)
        {
            var response = invoiceService.SavePayment(jsonBody);
            return Ok(response);
        }
    }
}
