using HesabfaAPISampleCode.Models;
using RestSharp;
using Newtonsoft.Json;

namespace HesabfaAPISampleCode.Services
{
    public interface ISettingService
    {
        List<Bank> GetBanks();
        List<Cash> GetCashes();
        List<PettyCash> GetPettyCashes();
        CurrencyValue GetCurrency();
        List<FiscalYearList> GetFiscalYears();
        List<Warehouse> GetWarehouses();
        List<Project> GetProjects();
        List<Salesman> GetSalesmen();
        List<CurrencyTable> GetCurrencyTable();
        object SetCurrencyTable(Array table);
        BusinessInfo GetBusinessInfo();
        FiscalYear GetFiscalYear();
        List<Account> GetAccounts();
        Category GetProductCategories();
        Category GetServiceCategories();
        Category GetContactCategories();
        List<UserLog> GetLastChanges(int start);
    }
    public class SettingService : ISettingService
    {
        private readonly IBaseService BaseService;
        public SettingService(IBaseService baseService)
        {
            this.BaseService = baseService;
        }

        public List<Bank> GetBanks()
        {
            var result = BaseService.Post<List<Bank>>("setting/GetBanks");

            return result.Result;
        }

        public List<Cash> GetCashes()
        {
            var result = BaseService.Post<List<Cash>>("setting/GetCashes");

            return result.Result;
        }

        public List<PettyCash> GetPettyCashes()
        {
            var result = BaseService.Post<List<PettyCash>>("setting/GetPettyCashes");

            return result.Result;
        }

        public CurrencyValue GetCurrency()
        {
            var result = BaseService.Post<CurrencyValue>("setting/GetCurrency");

            return result.Result;
        }

        public List<FiscalYearList> GetFiscalYears()
        {
            var result = BaseService.Post<List<FiscalYearList>>("setting/GetFiscalYears");

            return result.Result;
        }

        public List<Warehouse> GetWarehouses()
        {
            var result = BaseService.Post<List<Warehouse>>("setting/GetWarehouses");

            return result.Result;
        }

        public List<Project> GetProjects()
        {
            var result = BaseService.Post<List<Project>>("setting/GetProjects");

            return result.Result;
        }

        public List<Salesman> GetSalesmen()
        {
            var result = BaseService.Post<List<Salesman>>("setting/GetSalesmen");

            return result.Result;
        }

        public List<CurrencyTable> GetCurrencyTable()
        {
            var result = BaseService.Post<List<CurrencyTable>>("setting/GetCurrencyTable");

            return result.Result;
        }

        public object SetCurrencyTable(Array table)
        {
            var result = BaseService.Post<object>("setting/SetCurrencyTable", ("Table", table));

            return result.Result;
        }
        public BusinessInfo GetBusinessInfo()
        {
            var result = BaseService.Post<BusinessInfo>("setting/GetBusinessInfo");

            return result.Result;
        }

        public FiscalYear GetFiscalYear()
        {
            var result = BaseService.Post<FiscalYear>("setting/GetFiscalYear");

            return result.Result;
        }

        public List<Account> GetAccounts()
        {
            var result = BaseService.Post<List<Account>>("setting/GetAccounts");

            return result.Result;
        }

        public Category GetProductCategories()
        {
            var result = BaseService.Post<Category>("setting/GetProductCategories");

            return result.Result;
        }

        public Category GetServiceCategories()
        {
            var result = BaseService.Post<Category>("setting/GetServiceCategories");

            return result.Result;
        }

        public Category GetContactCategories()
        {
            var result = BaseService.Post<Category>("setting/GetContactCategories");

            return result.Result;
        }

        public List<UserLog> GetLastChanges(int start)
        {
            var result = BaseService.Post<List<UserLog>>("setting/GetChanges", ("start", start));
            return result.Result;
        }
    }
}
