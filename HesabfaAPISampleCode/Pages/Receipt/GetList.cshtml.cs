using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Receipt
{
    public class GetListModel : PageModel
    {
        private readonly IReceiptService receiptService;
        public GetListModel(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int type)
        {
            ViewData["receipts"] = receiptService.GetReceipts(type);
            return Page();
        }
    }
}
