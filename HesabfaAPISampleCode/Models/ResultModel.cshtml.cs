using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Models
{
    public class ResultModelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
    public class ResultItems {
        public string Id { get; set; }
        public string Code { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Currency { get; set; }
    }
}
