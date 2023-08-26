using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IInvoiceService
    {
        Invoice GetInvoicesList(int type);
        InvoiceItem GetInvoice(int number, int type);
        InvoiceItem GetInvoiceById(int id);
        OnlineInvoiceURL GetOnlineInvoiceURL(int number, int type);
        T SavePayment<T>(PaymentRequest paymentRequest);
        object Delete(int number, int type);
        T Save<T>(InvoiceItem invoice);
        T SaveWarehouseReceipt<T>(WarehouseReceipt receipt);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IBaseService BaseService;
        public InvoiceService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public Invoice GetInvoicesList(int type)
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

            var result = BaseService.Post<Invoice>("invoice/getinvoices", parameters);

            return result.Result;
        }

        public InvoiceItem GetInvoice(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            var result = BaseService.Post<InvoiceItem>("invoice/get", parameters);

            return result.Result;
        }

        public InvoiceItem GetInvoiceById(int id)
        {
            var parameters = new List<(string, object)>
            {
                ("id", id)
            };
            var result = BaseService.Post<InvoiceItem>("invoice/getById", parameters);

            return result.Result;
        }

        public OnlineInvoiceURL GetOnlineInvoiceURL(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            var result = BaseService.Post<OnlineInvoiceURL>("invoice/getonlineinvoiceurl", parameters);

            return result.Result;
        }

        public T SavePayment<T>(PaymentRequest paymentRequest)
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
            var result = BaseService.Post<object>("invoice/savepayment", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(InvoiceItem)result.Result;
            }
        }

        public object Delete(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type),
            };

            var result = BaseService.Post<object>("invoice/delete", parameters);

            return result.Result;
        }

        public T Save<T>(InvoiceItem invoice)
        {
            var result = BaseService.Post<InvoiceItem>("invoice/save", ("invoice", invoice));
            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(InvoiceItem)result.Result;
            }
        }

        public T SaveWarehouseReceipt<T>(WarehouseReceipt receipt)
        {
            var result = BaseService.Post<WarehouseReceipt>("invoice/SaveWarehouseReceipt", ("receipt", receipt));

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
