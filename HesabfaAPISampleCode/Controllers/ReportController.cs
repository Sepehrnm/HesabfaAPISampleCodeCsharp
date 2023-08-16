using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;

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
            List<Balancesheet> response = reportService.ReportBalancesheet(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
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
            List<ProfitAndLossStatement> response = reportService.ReportProfitAndLossStatement(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult TrialBalance([FromBody] ReportRequest request)
        {
            List<TrialBalance> response = reportService.ReportTrialBalance(request.StartDate, request.EndDate, request.Project);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult TrialBalanceItems([FromBody] ReportRequest request)
        {
            List<TrialBalanceItem> response = reportService.ReportTrialBalanceItems(request.StartDate, request.EndDate, request.Project, request.AccountPath);
            return Ok(response);
        }
    }
}
