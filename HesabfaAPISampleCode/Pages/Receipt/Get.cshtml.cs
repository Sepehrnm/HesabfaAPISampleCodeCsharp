using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Receipt
{
    public class GetModel : PageModel
    {
        private readonly IReceiptService receiptService;
        public GetModel(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int type, int number)
        {
            ViewData["receipt"] = receiptService.GetReceipt(type, number);
            return Page();
        }
    }
}
