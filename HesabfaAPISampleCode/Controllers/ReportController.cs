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
        public IActionResult Balancesheet([FromBody] ReportRequest request)
        {
            Balancesheet response = reportService.ReportBalancesheet(request.StartDate, request.EndDate, request.Project);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult DebtorsCreditors([FromBody] ReportRequest request)
        {
            List<DebtorsCreditors> response = reportService.ReportDebtorsCreditors(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Inventory([FromBody] ReportRequest request)
        {
            List<Inventory> response = reportService.ReportInventory(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult ProfitAndLossStatement([FromBody] ReportRequest request)
        {
            ProfitAndLossStatement response = reportService.ReportProfitAndLossStatement(request.StartDate, request.EndDate, request.Project);
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult TrialBalance([FromBody] ReportRequest request)
        {
            List<TrialBalance> response = reportService.ReportTrialBalance(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult TrialBalanceItems([FromBody] ReportRequestWithAccountPath request)
        {
            var response = reportService.ReportTrialBalanceItems<object>(request.StartDate, request.EndDate, request.Project, request.AccountPath);
            
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
