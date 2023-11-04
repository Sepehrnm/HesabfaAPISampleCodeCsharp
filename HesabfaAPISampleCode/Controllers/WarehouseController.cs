using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;
using System.Text.Json.Nodes;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] int number)
        {
            return Ok(await warehouseService.GetWarehouseReceipt(number));
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int[] idList)
        {
            return Ok(await warehouseService.GetWarehouseReceiptById(idList));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] WarehouseReceiptDraft receipt)
        {
           return Ok(await warehouseService.SaveWarehouseReceipt(receipt));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int number)
        {
            return Ok(await warehouseService.DeleteWarehouseReceipt(number));
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int type)
        {
            return Ok(await warehouseService.GetWarehouseReceipts(type));
        }
    }
}
