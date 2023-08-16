using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Item
{
    public class GetModel : PageModel
    {
        private readonly IProductService productService;
        public GetModel(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string code)
        {
            ViewData["item"] = productService.GetItem(code);
            return Page();
        }
    }
}
