using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Item
{
    public class GetListModel : PageModel
    {
        private readonly IProductService ProductService;
        public GetListModel(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public IActionResult OnGet()
        {
            ViewData["List"] = ProductService.GetItems();
            return Page();
        }
    }
}
