using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IWarehouseService
    {
        Task<WarehouseReceiptDraft> GetWarehouseReceipt(int number);
        Task<List<WarehouseReceiptDraft>> GetWarehouseReceiptById(Array idList);
        Task<WarehouseReceiptDraft> SaveWarehouseReceipt(WarehouseReceiptDraft receipt);
        Task<bool> DeleteWarehouseReceipt(int number);
        Task<ListResult<WarehouseReceiptDraft>> GetWarehouseReceipts(int type);
    }
    public class WarehouseService : IWarehouseService
    {
        private readonly IBaseService baseService;
        public WarehouseService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<WarehouseReceiptDraft> GetWarehouseReceipt(int number)
        {
            return await baseService.Post<WarehouseReceiptDraft>("warehouse/get", ("number", number));
        }

        public async Task<List<WarehouseReceiptDraft>> GetWarehouseReceiptById(Array idList)
        {
            return await baseService.Post<List<WarehouseReceiptDraft>>("warehouse/getById", ("idList", idList));
        }

        public async Task<WarehouseReceiptDraft> SaveWarehouseReceipt(WarehouseReceiptDraft receipt)
        {
            return await baseService.Post<WarehouseReceiptDraft>("warehouse/save", ("receipt", receipt));
        }

        public async Task<bool> DeleteWarehouseReceipt(int number)
        {
            return await baseService.Post<bool>("warehouse/delete", ("number", number));
        }

        public async Task<ListResult<WarehouseReceiptDraft>> GetWarehouseReceipts(int type)
        {
            var queryInfo = new QueryInfo();
            queryInfo.SortBy = "Date";
            queryInfo.SortDesc = true;
            queryInfo.Take = 100;
            queryInfo.Skip = 0;

            var parameters = new List<(string, object)>
            {
                ("queryInfo", queryInfo),
                ("type", type)
            };

            return await baseService.Post<ListResult<WarehouseReceiptDraft>>("warehouse/getReceipts", parameters);
        }
    }
}
