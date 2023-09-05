using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System.Text;
using System.Text.Json.Nodes;

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
            var response = await settingService.SetCurrencyTable(table.ToArray());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrencyTable()
        {
            List<CurrencyTable> table = await settingService.GetCurrencyTable();
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> GetFiscalYears()
        {
            List<FiscalYearList> list = await settingService.GetFiscalYears();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> GetBanks()
        {
            List<Bank> banks = await settingService.GetBanks();
            return Ok(banks);
        }

        [HttpPost]
        public async Task<IActionResult> GetCashes()
        {
            List<Cash> cashes = await settingService.GetCashes();
            return Ok(cashes);
        }

        [HttpPost]
        public async Task<IActionResult> GetPettyCashes()
        {
            List<PettyCash> pettyCashes = await settingService.GetPettyCashes();
            return Ok(pettyCashes);
        }

        [HttpPost]
        public async Task<IActionResult> GetAccounts()
        {
            List<Account> accounts = await settingService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> GetSalesmen()
        {
            List<Salesman> salesmen = await settingService.GetSalesmen();
            return Ok(salesmen);
        }

        [HttpPost]
        public async Task<IActionResult> GetWarehouses()
        {
            List<Warehouse> warehouses = await settingService.GetWarehouses();
            return Ok(warehouses);
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrency()
        {
            CurrencyValue currency = await settingService.GetCurrency();
            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> GetProjects()
        {
            List<Project> projects = await settingService.GetProjects();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> GetFiscalYear()
        {
            FiscalYear fiscalYear = await settingService.GetFiscalYear();
            return Ok(fiscalYear);
        }

        [HttpPost]
        public async Task<IActionResult> GetBusinessInfo()
        {
            BusinessInfo businessInfo = await settingService.GetBusinessInfo();
            return Ok(businessInfo);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductCategories()
        {
            Category categories = await settingService.GetProductCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetContactCategories()
        {
            Category categories = await settingService.GetContactCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetServiceCategories()
        {
            Category categories = await settingService.GetServiceCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetLastChanges([FromBody] int start)
        {
            List<UserLog> userLogs = await settingService.GetLastChanges(start);
            return Ok(userLogs);
        }

    }
}
