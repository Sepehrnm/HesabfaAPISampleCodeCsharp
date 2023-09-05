using HesabfaAPISampleCode.Models;
using RestSharp;
using Newtonsoft.Json;

namespace HesabfaAPISampleCode.Services
{
    public interface ISettingService
    {
        Task<List<Bank>> GetBanks();
        Task<List<Cash>> GetCashes();
        Task<List<PettyCash>> GetPettyCashes();
        Task<CurrencyValue> GetCurrency();
        Task<List<FiscalYearList>> GetFiscalYears();
        Task<List<Warehouse>> GetWarehouses();
        Task<List<Project>> GetProjects();
        Task<List<Salesman>> GetSalesmen();
        Task<List<CurrencyTable>> GetCurrencyTable();
        Task<object> SetCurrencyTable(Array table);
        Task<BusinessInfo> GetBusinessInfo();
        Task<FiscalYear> GetFiscalYear();
        Task<List<Account>> GetAccounts();
        Task<Category> GetProductCategories();
        Task<Category> GetServiceCategories();
        Task<Category> GetContactCategories();
        Task<List<UserLog>> GetLastChanges(int start);
    }
    public class SettingService : ISettingService
    {
        private readonly IBaseService BaseService;
        public SettingService(IBaseService baseService)
        {
            this.BaseService = baseService;
        }

        public async Task<List<Bank>> GetBanks()
        {
            var result = await BaseService.Post<List<Bank>>("setting/GetBanks");

            return result.Result;
        }

        public async Task<List<Cash>> GetCashes()
        {
            var result = await BaseService.Post<List<Cash>>("setting/GetCashes");

            return result.Result;
        }

        public async Task<List<PettyCash>> GetPettyCashes()
        {
            var result = await BaseService.Post<List<PettyCash>>("setting/GetPettyCashes");

            return result.Result;
        }

        public async Task<CurrencyValue> GetCurrency()
        {
            var result = await BaseService.Post<CurrencyValue>("setting/GetCurrency");

            return result.Result;
        }

        public async Task<List<FiscalYearList>> GetFiscalYears()
        {
            var result = await BaseService.Post<List<FiscalYearList>>("setting/GetFiscalYears");

            return result.Result;
        }

        //public List<Warehouse> GetWarehouses()
        //{
        //    var result = BaseService.Post<List<Warehouse>>("setting/GetWarehouses");

        //    return result.Result;
        //}

        public async Task<List<Warehouse>> GetWarehouses()
        {
            var result = await BaseService.Post<List<Warehouse>>("setting/GetWarehouses");
            return result.Result;
        }

        public async Task<List<Project>> GetProjects()
        {
            var result = await BaseService.Post<List<Project>>("setting/GetProjects");

            return result.Result;
        }

        public async Task<List<Salesman>> GetSalesmen()
        {
            var result = await BaseService.Post<List<Salesman>>("setting/GetSalesmen");

            return result.Result;
        }

        public async Task<List<CurrencyTable>> GetCurrencyTable()
        {
            var result = await BaseService.Post<List<CurrencyTable>>("setting/GetCurrencyTable");

            return result.Result;
        }

        public async Task<object> SetCurrencyTable(Array table)
        {
            var result = await BaseService.Post<object>("setting/SetCurrencyTable", ("Table", table));

            return result.Result;
        }
        public async Task<BusinessInfo> GetBusinessInfo()
        {
            var result = await BaseService.Post<BusinessInfo>("setting/GetBusinessInfo");

            return result.Result;
        }

        public async Task<FiscalYear> GetFiscalYear()
        {
            var result = await BaseService.Post<FiscalYear>("setting/GetFiscalYear");

            return result.Result;
        }

        public async Task<List<Account>> GetAccounts()
        {
            var result = await BaseService.Post<List<Account>>("setting/GetAccounts");

            return result.Result;
        }

        public async Task<Category> GetProductCategories()
        {
            var result = await BaseService.Post<Category>("setting/GetProductCategories");

            return result.Result;
        }

        public async Task<Category> GetServiceCategories()
        {
            var result = await BaseService.Post<Category>("setting/GetServiceCategories");

            return result.Result;
        }

        public async Task<Category> GetContactCategories()
        {
            var result = await BaseService.Post<Category>("setting/GetContactCategories");

            return result.Result;
        }

        public async Task<List<UserLog>> GetLastChanges(int start)
        {
            var result = await BaseService.Post<List<UserLog>>("setting/GetChanges", ("start", start));
            return result.Result;
        }
    }
}
