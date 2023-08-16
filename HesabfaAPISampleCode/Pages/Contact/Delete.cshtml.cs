using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.Contact
{
    public class DeleteModel : PageModel
    {
        private readonly IContactService ContactService;
        public DeleteModel(IContactService ContactService)
        {
            this.ContactService = ContactService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(string code)
        {
            ViewData["result"] = ContactService.DeleteContact(code);
            return Page();
        }
    }
}
