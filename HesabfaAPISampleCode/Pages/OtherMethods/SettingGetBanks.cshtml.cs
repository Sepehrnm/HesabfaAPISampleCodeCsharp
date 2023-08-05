using HesabfaAPISampleCode.Controllers;
using HesabfaAPISampleCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabfaAPISampleCode.Pages.OtherMethods
{
    public class SettingGetBanksModel : PageModel
    {
        private readonly HomeController _homeController;

        public SettingGetBanksModel(HomeController homeController)
        {
            _homeController = homeController;
        }

        public IActionResult OnGet()
        {
            var bankData = _homeController.GetBanks();
            //ResultItems resultItems = new ResultItems();
            //resultItems.Name = "Not Found";

            return Page();
        }
    }
}