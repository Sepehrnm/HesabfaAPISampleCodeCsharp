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
        public async Task<IActionResult> GetList()
        {
            Product response = await itemService.GetItems();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int[] idList)
        {
            var response = await itemService.GetItemById<object>(idList);
            if (response is List<ProductItem>)
            {
                return Ok(response as List<ProductItem>);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByBarcode([FromBody] string barcode)
        {
            var response = await itemService.GetItemByBarcode<object>(barcode);
            if (response is ProductItem)
            {
                return Ok(response as ProductItem);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] string code)
        {
            var response = await itemService.GetItem<object>(code);
            if (response is ProductItem)
            {
                return Ok(response as ProductItem);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetQuantityList([FromBody] QuantityRequest requestBody)
        {
            List<QuantityItem> response = await itemService.GetQuantity(requestBody.WarehouseCode, requestBody.Codes);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] object item)
        {
            var response = await itemService.Save<object>(item);
            if (response is ProductItem)
            {
                return Ok(response as ProductItem);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string code)
        {
            var response = await itemService.Delete<object>(code);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOpeningQuantity([FromBody] object items)
        {
            var response = await itemService.UpdateOpeningQuantity(items);
            return Ok(response);
        }
    }
}
