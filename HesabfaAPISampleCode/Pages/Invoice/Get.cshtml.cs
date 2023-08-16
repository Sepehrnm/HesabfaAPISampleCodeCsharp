using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Invoice
{
    public class GetModel : PageModel
    {
        private readonly IInvoiceService invoiceService;
        public GetModel(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int number, int type)
        {
            ViewData["invoice"] = invoiceService.GetInvoice(number, type);
            return Page();
        }
    }
}
