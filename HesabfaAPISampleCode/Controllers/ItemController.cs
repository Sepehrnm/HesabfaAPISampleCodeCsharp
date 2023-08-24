using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost]
        public IActionResult GetList()
        {
            Product response = itemService.GetItems();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetById([FromBody] int[] idList)
        {
            List<ProductItem> response = itemService.GetItemById(idList);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetByBarcode([FromBody] string barcode)
        {
            ProductItem response = itemService.GetItemByBarcode(barcode);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Get([FromBody] string code)
        {
            ProductItem response = itemService.GetItem(code);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetQuantityList([FromBody] QuantityRequest requestBody)
        {
            List<QuantityItem> response = itemService.GetQuantity(requestBody.WarehouseCode, requestBody.Codes);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Save([FromBody] object item)
        {
            ProductItem response = itemService.Save(item);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] string code)
        {
            var response = itemService.Delete(code);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult UpdateOpeningQuantity([FromBody] object items)
        {
            var response = itemService.UpdateOpeningQuantity(items);
            return Ok(response);
        }
    }
}
