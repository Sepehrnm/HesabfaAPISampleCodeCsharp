using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IReportService
    {
        Task<Balancesheet> ReportBalancesheet(string startDate, string endDate, string project);
        Task<List<DebtorCreditor>> ReportDebtorsCreditors(string startDate, string endDate, string project);
        Task<List<Inventory>> ReportInventory(string startDate, string endDate, string project);
        Task<ProfitAndLossStatement> ReportProfitAndLossStatement(string startDate, string endDate, string project);
        Task<List<TrialBalance>> ReportTrialBalance(string startDate, string endDate, string project);
        Task<List<TrialBalanceItem>> ReportTrialBalanceItems(string startDate, string endDate, string project, string accountPath);
    }
    public class ReportService : IReportService
    {
        private readonly IBaseService baseService;
        public ReportService(IBaseService baseService)
        {
            this.baseService = baseService;
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
            return await baseService.Post<Balancesheet>("report/balancesheet", parameters);
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

            return await baseService.Post<List<DebtorCreditor>>("report/debtorscreditors", parameters);
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
            return await baseService.Post<List<Inventory>>("report/inventory", parameters);
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
            return await baseService.Post<ProfitAndLossStatement>("report/profitandlossstatement", parameters);
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
            return await baseService.Post<List<TrialBalance>>("report/trialbalance", parameters);
        }

        public async Task<List<TrialBalanceItem>> ReportTrialBalanceItems(string startDate, string endDate, string project, string accountPath)
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
            return await baseService.Post<List<TrialBalanceItem>>("report/trialbalanceitems", parameters);
        }

    }
}
