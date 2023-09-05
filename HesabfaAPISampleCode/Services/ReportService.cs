using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HesabfaAPISampleCode.Services
{
    public interface IReportService
    {
        Task<Balancesheet> ReportBalancesheet(string startDate, string endDate, string project);
        Task<List<DebtorCreditor>> ReportDebtorsCreditors(string startDate, string endDate, string project);
        Task<List<Inventory>> ReportInventory(string startDate, string endDate, string project);
        Task<ProfitAndLossStatement> ReportProfitAndLossStatement(string startDate, string endDate, string project);
        Task<List<TrialBalance>> ReportTrialBalance(string startDate, string endDate, string project);
        Task<T> ReportTrialBalanceItems<T>(string startDate, string endDate, string project, string accountPath);
    }
    public class ReportService : IReportService
    {
        private readonly IBaseService BaseService;
        public ReportService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }
        public async Task<Balancesheet> ReportBalancesheet(string startDate, string endDate, string project)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }
            var result = await BaseService.Post<Balancesheet>("report/balancesheet", parameters);

            return result.Result;
        }

        public async Task<List<DebtorCreditor>> ReportDebtorsCreditors(string startDate, string endDate, string project)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }

            var result = await BaseService.Post<List<DebtorCreditor>>("report/debtorscreditors", parameters);

            return result.Result;
        }

        public async Task<List<Inventory>> ReportInventory(string startDate, string endDate, string project)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }
            var result = await BaseService.Post<List<Inventory>>("report/inventory", parameters);

            return result.Result;
        }

        public async Task<ProfitAndLossStatement> ReportProfitAndLossStatement(string startDate, string endDate, string project)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }
            var result = await BaseService.Post<ProfitAndLossStatement>("report/profitandlossstatement", parameters);

            return result.Result;
        }

        public async Task<List<TrialBalance>> ReportTrialBalance(string startDate, string endDate, string project)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }
            var result = await BaseService.Post<List<TrialBalance>>("report/trialbalance", parameters);

            return result.Result;
        }

        public async Task<T> ReportTrialBalanceItems<T>(string startDate, string endDate, string project, string accountPath)
        {
            var parameters = new List<(string, object)>();

            if (!string.IsNullOrEmpty(startDate))
            {
                parameters.Add(("startDate", startDate));
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                parameters.Add(("endDate", endDate));
            }

            if (!string.IsNullOrEmpty(project))
            {
                parameters.Add(("project", project));
            }

            if (!string.IsNullOrEmpty(accountPath))
            {
                parameters.Add(("accountPath", accountPath));
            }
            var result = await BaseService.Post<List<TrialBalanceItem>>("report/trialbalanceitems", parameters);
            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(List<TrialBalanceItem>)result.Result;
            }
        }

    }
}
