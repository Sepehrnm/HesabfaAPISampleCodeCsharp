using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IReceiptService
    {
        Receipt GetReceipts(int type);
        T GetReceipt<T>(int type, int number);
        ReceiptItem SaveReceipt(SaveReceiptItem receipt);
        T DeleteReceipt<T>(int type, int number);
    }
    public class ReceiptService : IReceiptService
    {
        private readonly IBaseService BaseService;
        public ReceiptService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public Receipt GetReceipts(int type)
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
            var result = BaseService.Post<Receipt>("receipt/getReceipts", parameters);

            return result.Result;
        }

        public T GetReceipt<T>(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            var result = BaseService.Post<ReceiptItem>("receipt/get", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(object)result.Result;
            }
        }
        public ReceiptItem SaveReceipt(SaveReceiptItem receipt)
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

            var result = BaseService.Post<ReceiptItem>("receipt/save", parameters);

            return result.Result;
        }

        public T DeleteReceipt<T>(int type, int number)
        {

            var parameters = new List<(string, object)>
            {
                ("type", type),
                ("number", number),
            };
            var result = BaseService.Post<object>("receipt/delete", parameters);

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
