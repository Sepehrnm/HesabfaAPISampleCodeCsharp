using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IReceiptService
    {
        Task<Receipt> GetReceipts(int type);
        Task<T> GetReceipt<T>(int type, int number);
        Task<ReceiptItem> SaveReceipt(SaveReceiptItem receipt);
        Task<T> DeleteReceipt<T>(int type, int number);
    }
    public class ReceiptService : IReceiptService
    {
        private readonly IBaseService BaseService;
        public ReceiptService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public async Task<Receipt> GetReceipts(int type)
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "DateTime";
            queryInfo.SortDesc = true;
            queryInfo.Take = 20000;
            queryInfo.Skip = 0;

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("queryInfo", queryInfo),
            };
            var result = await BaseService.Post<Receipt>("receipt/getReceipts", parameters);

            return result.Result;
        }

        public async Task<T> GetReceipt<T>(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            var result = await BaseService.Post<ReceiptItem>("receipt/get", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(object)result.Result;
            }
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

            var result = await BaseService.Post<ReceiptItem>("receipt/save", parameters);

            return result.Result;
        }

        public async Task<T> DeleteReceipt<T>(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            var result = await BaseService.Post<object>("receipt/delete", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(object)result.Result;
            }
        }
    }
}
