using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoicesList(int type);
        Task<InvoiceItem> GetInvoice(int number, int type);
        Task<InvoiceItem> GetInvoiceById(int id);
        Task<OnlineInvoiceURL> GetOnlineInvoiceURL(int number, int type);
        Task<T> SavePayment<T>(PaymentRequest paymentRequest);
        Task<object> Delete(int number, int type);
        Task<T> Save<T>(InvoiceItem invoice);
        Task<T> SaveWarehouseReceipt<T>(WarehouseReceipt receipt);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IBaseService BaseService;
        public InvoiceService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public async Task<Invoice> GetInvoicesList(int type)
        {
            var queryInfo = new
            {
                SortBy = "Date",
                SortDesc = true,
                Take = 200000,
                Skip = 0
            };

            var parameters = new List<(string, object)>
            {
                ("queryInfo", queryInfo),
                ("type", type)
            };

            var result = await BaseService.Post<Invoice>("invoice/getinvoices", parameters);

            return result.Result;
        }

        public async Task<InvoiceItem> GetInvoice(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            var result = await BaseService.Post<InvoiceItem>("invoice/get", parameters);

            return result.Result;
        }

        public async Task<InvoiceItem> GetInvoiceById(int id)
        {
            var parameters = new List<(string, object)>
            {
                ("id", id)
            };
            var result = await BaseService.Post<InvoiceItem>("invoice/getById", parameters);

            return result.Result;
        }

        public async Task<OnlineInvoiceURL> GetOnlineInvoiceURL(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            var result = await BaseService.Post<OnlineInvoiceURL>("invoice/getonlineinvoiceurl", parameters);

            return result.Result;
        }

        public async Task<T> SavePayment<T>(PaymentRequest paymentRequest)
        {
            var parameters = new List<(string, object)>
            {
                ("number", paymentRequest.Number),
                ("type", paymentRequest.Type),
                ("bankCode", paymentRequest.BankCode),
                ("date", paymentRequest.Date),
                ("amount", paymentRequest.Amount),
                ("transactionNumber", paymentRequest.TransactionNumber),
                ("description", paymentRequest.Description),
                ("transactionFee", paymentRequest.TransactionFee),
                ("currency", paymentRequest.Currency),
                ("currencyRate", paymentRequest.CurrencyRate),
            };
            var result = await BaseService.Post<object>("invoice/savepayment", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(InvoiceItem)result.Result;
            }
        }

        public async Task<object> Delete(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type),
            };

            var result = await BaseService.Post<object>("invoice/delete", parameters);

            return result.Result;
        }

        public async Task<T> Save<T>(InvoiceItem invoice)
        {
            var result = await BaseService.Post<InvoiceItem>("invoice/save", ("invoice", invoice));
            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(InvoiceItem)result.Result;
            }
        }

        public async Task<T> SaveWarehouseReceipt<T>(WarehouseReceipt receipt)
        {
            var result = await BaseService.Post<WarehouseReceipt>("invoice/SaveWarehouseReceipt", ("receipt", receipt));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(WarehouseReceipt)result.Result;
            }
        }

    }
}
