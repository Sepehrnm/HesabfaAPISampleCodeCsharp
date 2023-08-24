using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HesabfaAPISampleCode.Services
{
    public interface IReportService
    {
        Balancesheet ReportBalancesheet(string startDate, string endDate, string project);
        List<DebtorsCreditors> ReportDebtorsCreditors(string startDate, string endDate, string project);
        List<Inventory> ReportInventory(string startDate, string endDate, string project);
        ProfitAndLossStatement ReportProfitAndLossStatement(string startDate, string endDate, string project);
        List<TrialBalance> ReportTrialBalance(string startDate, string endDate, string project);
        List<TrialBalanceItem> ReportTrialBalanceItems(string startDate, string endDate, string project, string accountPath);

    }
    public class ReportService : IReportService
    {
        private readonly IBaseService BaseService;
        public ReportService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }
        public Balancesheet ReportBalancesheet(string startDate, string endDate, string project)
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
            var result = BaseService.Post<Balancesheet>("report/balancesheet", parameters);

            return result.Result;
        }

        public List<DebtorsCreditors> ReportDebtorsCreditors(string startDate, string endDate, string project)
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

            var result = BaseService.Post<List<DebtorsCreditors>>("report/debtorscreditors", parameters);

            return result.Result;
        }

        public List<Inventory> ReportInventory(string startDate, string endDate, string project)
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
            var result = BaseService.Post<List<Inventory>>("report/inventory", parameters);

            return result.Result;
        }

        public ProfitAndLossStatement ReportProfitAndLossStatement(string startDate, string endDate, string project)
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
            var result = BaseService.Post<ProfitAndLossStatement>("report/profitandlossstatement", parameters);

            return result.Result;
        }

        public List<TrialBalance> ReportTrialBalance(string startDate, string endDate, string project)
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
            var result = BaseService.Post<List<TrialBalance>>("report/trialbalance", parameters);

            return result.Result;
        }

        public List<TrialBalanceItem> ReportTrialBalanceItems(string startDate, string endDate, string project, string accountPath)
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
            var result = BaseService.Post<List<TrialBalanceItem>>("report/trialbalanceitems", parameters);

            return result.Result;
        }

    }
}
