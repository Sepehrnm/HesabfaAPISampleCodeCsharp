using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Invoice
{
    public class GetListModel : PageModel
    {
        private readonly IInvoiceService invoiceService;
        public GetListModel(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int type)
        {
            ViewData["invoices"] = invoiceService.GetInvoicesList(type);
            return Page();
        }
    }
}
