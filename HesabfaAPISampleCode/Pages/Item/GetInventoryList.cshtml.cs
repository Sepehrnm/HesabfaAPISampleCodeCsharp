using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Item
{
    public class InventoryListModel : PageModel
    {
        private readonly IProductService ProductService;
        
        public InventoryListModel(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(int warehouseCode, Array codes)
        {
            ViewData["inventory"] = ProductService.GetQuantity(warehouseCode, codes);
            return Page();
        }
    }
}
