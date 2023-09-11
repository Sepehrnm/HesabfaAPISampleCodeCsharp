using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IReceiptService
    {
        Task<ListResult<ReceiptItem>> GetReceipts(int type);
        Task<ReceiptItem> GetReceipt(int type, int number);
        Task<ReceiptItem> SaveReceipt(SaveReceiptItem receipt);
        Task<bool> DeleteReceipt(int type, int number);
    }
    public class ReceiptService : IReceiptService
    {
        private readonly IBaseService baseService;
        public ReceiptService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ListResult<ReceiptItem>> GetReceipts(int type)
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "DateTime";
            queryInfo.SortDesc = true;
            queryInfo.Take = 100;
            queryInfo.Skip = 0;

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("queryInfo", queryInfo),
            };
            return await baseService.Post<ListResult<ReceiptItem>>("receipt/getReceipts", parameters);
        }

        public async Task<ReceiptItem> GetReceipt(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            return await baseService.Post<ReceiptItem>("receipt/get", parameters);
        }
        public async Task<ReceiptItem> SaveReceipt(SaveReceiptItem receipt)
        {

            var parameters = new List<(string, object)>
            {
                ("type", receipt.Type),
                ("amount", receipt.Amount),
                ("contactCode", receipt.ContactCode),
                ("bankCode", receipt.BankCode),
                ("Number", receipt.Number),
                ("description", receipt.Description),
            };

            return await baseService.Post<ReceiptItem>("receipt/save", parameters);
        }

        public async Task<bool> DeleteReceipt(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            return await baseService.Post<bool>("receipt/delete", parameters);
        }
    }
}
