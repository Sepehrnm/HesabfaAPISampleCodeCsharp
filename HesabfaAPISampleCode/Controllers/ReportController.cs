using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Generic;
using System.Text;

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
            Balancesheet response = await reportService.ReportBalancesheet(request.StartDate, request.EndDate, request.Project);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> DebtorsCreditors([FromBody] ReportRequest request)
        {
            List<DebtorCreditor> response = await reportService.ReportDebtorsCreditors(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Inventory([FromBody] ReportRequest request)
        {
            List<Inventory> response = await reportService.ReportInventory(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ProfitAndLossStatement([FromBody] ReportRequest request)
        {
            ProfitAndLossStatement response = await reportService.ReportProfitAndLossStatement(request.StartDate, request.EndDate, request.Project);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> TrialBalance([FromBody] ReportRequest request)
        {
            List<TrialBalance> response = await reportService.ReportTrialBalance(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> TrialBalanceItems([FromBody] ReportRequestWithAccountPath request)
        {
            var response = await reportService.ReportTrialBalanceItems<object>(request.StartDate, request.EndDate, request.Project, request.AccountPath);
            
            if (response is List<TrialBalanceItem>)
            {
                return Ok(response as List<TrialBalanceItem>);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
