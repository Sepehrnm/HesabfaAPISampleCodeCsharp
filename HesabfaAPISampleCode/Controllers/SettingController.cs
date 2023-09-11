using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService settingService;
        public SettingController(ISettingService settingService)
        {
            this.settingService = settingService;
        }

        [HttpPost]
        public async Task<IActionResult> SetCurrencyTable([FromBody] List<CurrencyTable> table)
        {
            return Ok(await settingService.SetCurrencyTable(table.ToArray()));
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrencyTable()
        {
            return Ok(await settingService.GetCurrencyTable());
        }

        [HttpPost]
        public async Task<IActionResult> GetFiscalYears()
        {
            return Ok(await settingService.GetFiscalYears());
        }

        [HttpPost]
        public async Task<IActionResult> GetBanks()
        {
            return Ok(await settingService.GetBanks());
        }

        [HttpPost]
        public async Task<IActionResult> GetCashes()
        {
            return Ok(await settingService.GetCashes());
        }

        [HttpPost]
        public async Task<IActionResult> GetPettyCashes()
        {
            return Ok(await settingService.GetPettyCashes());
        }

        [HttpPost]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await settingService.GetAccounts());
        }

        [HttpPost]
        public async Task<IActionResult> GetSalesmen()
        {
            return Ok(await settingService.GetSalesmen());
        }

        [HttpPost]
        public async Task<IActionResult> GetWarehouses()
        {
            return Ok(await settingService.GetWarehouses());
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrency()
        {
            return Ok(await settingService.GetCurrency());
        }

        [HttpPost]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await settingService.GetProjects());
        }

        [HttpPost]
        public async Task<IActionResult> GetFiscalYear()
        {
            return Ok(await settingService.GetFiscalYear());
        }

        [HttpPost]
        public async Task<IActionResult> GetBusinessInfo()
        {
            return Ok(await settingService.GetBusinessInfo());
        }

        [HttpPost]
        public async Task<IActionResult> GetProductCategories()
        {
            return Ok(await settingService.GetProductCategories());
        }

        [HttpPost]
        public async Task<IActionResult> GetContactCategories()
        {
            return Ok(await settingService.GetContactCategories());
        }

        [HttpPost]
        public async Task<IActionResult> GetServiceCategories()
        {
            return Ok(await settingService.GetServiceCategories());
        }

        [HttpPost]
        public async Task<IActionResult> GetLastChanges([FromBody] int start)
        {
            return Ok(await settingService.GetLastChanges(start));
        }

    }
}
