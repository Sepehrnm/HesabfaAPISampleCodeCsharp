using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> Balancesheet([FromBody] ReportRequest request)
        {
            var response = await reportService.ReportBalancesheet(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DebtorsCreditors([FromBody] ReportRequest request)
        {
            return Ok(await reportService.ReportDebtorsCreditors(request.StartDate, request.EndDate, request.Project));
        }

        [HttpPost]
        public async Task<IActionResult> Inventory([FromBody] ReportRequest request)
        {
            return Ok(await reportService.ReportInventory(request.StartDate, request.EndDate, request.Project));
        }

        [HttpPost]
        public async Task<IActionResult> ProfitAndLossStatement([FromBody] ReportRequest request)
        {
            return Ok(await reportService.ReportProfitAndLossStatement(request.StartDate, request.EndDate, request.Project));
        }

        [HttpPost]
        public async Task<IActionResult> TrialBalance([FromBody] ReportRequest request)
        {
            return Ok(await reportService.ReportTrialBalance(request.StartDate, request.EndDate, request.Project));
        }

        [HttpPost]
        public async Task<IActionResult> TrialBalanceItems([FromBody] ReportRequestWithAccountPath request)
        {
            return Ok(await reportService.ReportTrialBalanceItems(request.StartDate, request.EndDate, request.Project, request.AccountPath));
        }
    }
}
