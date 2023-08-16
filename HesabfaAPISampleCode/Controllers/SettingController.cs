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
        public IActionResult SetCurrencyTable([FromBody] List<CurrencyTable> table)
        {
            var response = settingService.SetCurrencyTable(table.ToArray());
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetCurrencyTable()
        {
            List<CurrencyTable> table = settingService.GetCurrencyTable();
            return Ok(table);
        }

        [HttpPost]
        public IActionResult GetFiscalYears()
        {
            List<FiscalYearList> list = settingService.GetFiscalYears();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult GetBanks()
        {
            List<Bank> banks = settingService.GetBanks();
            return Ok(banks);
        }

        [HttpPost]
        public IActionResult GetCashes()
        {
            List<Cash> cashes = settingService.GetCashes();
            return Ok(cashes);
        }

        [HttpPost]
        public IActionResult GetPettyCashes()
        {
            List<PettyCash> pettyCashes = settingService.GetPettyCashes();
            return Ok(pettyCashes);
        }

        [HttpPost]
        public IActionResult GetAccounts()
        {
            List<Account> accounts = settingService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public IActionResult GetSalesmen()
        {
            List<Salesman> salesmen = settingService.GetSalesmen();
            return Ok(salesmen);
        }

        [HttpPost]
        public IActionResult GetWarehouses()
        {
            List<Warehouse> warehouses = settingService.GetWarehouses();
            return Ok(warehouses);
        }

        [HttpPost]
        public IActionResult GetCurrency()
        {
            CurrencyValue currency = settingService.GetCurrency();
            return Ok(currency);
        }

        [HttpPost]
        public IActionResult GetProjects()
        {
            List<Project> projects = settingService.GetProjects();
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult GetFiscalYear()
        {
            FiscalYear fiscalYear = settingService.GetFiscalYear();
            return Ok(fiscalYear);
        }

        [HttpPost]
        public IActionResult GetBusinessInfo()
        {
            BusinessInfo businessInfo = settingService.GetBusinessInfo();
            return Ok(businessInfo);
        }

        [HttpPost]
        public IActionResult GetProductCategories()
        {
            Category categories = settingService.GetProductCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetContactCategories()
        {
            Category categories = settingService.GetContactCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetServiceCategories()
        {
            Category categories = settingService.GetServiceCategories();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categories.Root));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetLastChanges([FromBody] int start)
        {
            List<UserLog> userLogs = settingService.GetLastChanges(start);
            return Ok(userLogs);
        }

    }
}
