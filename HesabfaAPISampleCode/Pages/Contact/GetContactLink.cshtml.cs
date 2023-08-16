using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Contact
{
    public class GetContactLinkModel : PageModel
    {
        private readonly IContactService ContactService;
        public GetContactLinkModel(IContactService ContactService)
        {
            this.ContactService = ContactService;
        }   

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string code, bool showAllAccounts=false, int days=30)
        {
            var response = ContactService.GetContactLink(code, showAllAccounts, days);
            ViewData["link"] = response;
            return Page();
        }
    }
}
