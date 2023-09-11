using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var response = await itemService.GetItems();
            return Ok(response.List);
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int[] idList)
        {
            return Ok(await itemService.GetItemById(idList));
        }

        [HttpPost]
        public async Task<IActionResult> GetByBarcode([FromBody] string barcode)
        {
            return Ok(await itemService.GetItemByBarcode(barcode));
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] string code)
        {
            return Ok(await itemService.GetItem(code));
        }

        [HttpPost]
        public async Task<IActionResult> GetQuantityList([FromBody] QuantityRequest requestBody)
        {
            return Ok(await itemService.GetQuantity(requestBody.WarehouseCode, requestBody.Codes));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] object item)
        {
            return Ok(await itemService.Save(item));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string code)
        {
            return Ok(await itemService.Delete(code));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOpeningQuantity([FromBody] object items)
        {
            var response = await itemService.UpdateOpeningQuantity(items);
            if (response == null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
