using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Invoice
{
    public class GetOnlineURLModel : PageModel
    {
        private readonly IInvoiceService invoiceService;
        public GetOnlineURLModel(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(int number, int type)
        {
            ViewData["OnlineInvoiceURL"] = invoiceService.GetOnlineInvoiceURL(number, type);
            return Page();
        }
    }
}
