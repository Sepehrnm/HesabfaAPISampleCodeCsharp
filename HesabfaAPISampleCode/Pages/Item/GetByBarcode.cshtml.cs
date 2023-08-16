using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Item
{
    public class GetByBarcodeModel : PageModel
    {
        private readonly IProductService productService;
        public GetByBarcodeModel(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string barcode)
        {
            ViewData["item"] = productService.GetItemByBarcode(barcode);
            return Page();
        }
    }
}
