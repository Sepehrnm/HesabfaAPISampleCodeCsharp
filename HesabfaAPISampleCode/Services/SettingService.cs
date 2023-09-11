using HesabfaAPISampleCode.Models;

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
        Task<bool> SetCurrencyTable(Array table);
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
        private readonly IBaseService baseService;
        public SettingService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<List<Bank>> GetBanks()
        {
            return await baseService.Post<List<Bank>>("setting/GetBanks");
        }

        public async Task<List<Cash>> GetCashes()
        {
            return await baseService.Post<List<Cash>>("setting/GetCashes");
        }

        public async Task<List<PettyCash>> GetPettyCashes()
        {
            return await baseService.Post<List<PettyCash>>("setting/GetPettyCashes");
        }

        public async Task<CurrencyValue> GetCurrency()
        {
            return await baseService.Post<CurrencyValue>("setting/GetCurrency");
        }

        public async Task<List<FiscalYearList>> GetFiscalYears()
        {
            return await baseService.Post<List<FiscalYearList>>("setting/GetFiscalYears");
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await baseService.Post<List<Warehouse>>("setting/GetWarehouses");
        }

        public async Task<List<Project>> GetProjects()
        {
            return await baseService.Post<List<Project>>("setting/GetProjects");
        }

        public async Task<List<Salesman>> GetSalesmen()
        {
            return await baseService.Post<List<Salesman>>("setting/GetSalesmen");
        }

        public async Task<List<CurrencyTable>> GetCurrencyTable()
        {
            return await baseService.Post<List<CurrencyTable>>("setting/GetCurrencyTable");
        }

        public async Task<bool> SetCurrencyTable(Array table)
        {
            return await baseService.Post<bool>("setting/SetCurrencyTable", ("Table", table));
        }
        public async Task<BusinessInfo> GetBusinessInfo()
        {
            return await baseService.Post<BusinessInfo>("setting/GetBusinessInfo");
        }

        public async Task<FiscalYear> GetFiscalYear()
        {
            return await baseService.Post<FiscalYear>("setting/GetFiscalYear");
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await baseService.Post<List<Account>>("setting/GetAccounts");
        }

        public async Task<Category> GetProductCategories()
        {
            return await baseService.Post<Category>("setting/GetProductCategories");
        }

        public async Task<Category> GetServiceCategories()
        {
            return await baseService.Post<Category>("setting/GetServiceCategories");
        }

        public async Task<Category> GetContactCategories()
        {
            return await baseService.Post<Category>("setting/GetContactCategories");
        }

        public async Task<List<UserLog>> GetLastChanges(int start)
        {
            return await baseService.Post<List<UserLog>>("setting/GetChanges", ("start", start));
        }
    }
}
