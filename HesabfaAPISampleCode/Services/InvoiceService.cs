using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IInvoiceService
    {
        Task<ListResult<Invoice>> GetInvoicesList(int type);
        Task<Invoice> GetInvoice(int number, int type);
        Task<Invoice> GetInvoiceById(int id);
        Task<OnlineInvoiceURL> GetOnlineInvoiceURL(int number, int type);
        Task<bool> SavePayment(PaymentRequest paymentRequest);
        Task<bool> Delete(int number, int type);
        Task<Invoice> Save(Invoice invoice);
        Task<WarehouseReceipt> SaveWarehouseReceipt(WarehouseReceipt receipt);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IBaseService baseService;
        public InvoiceService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ListResult<Invoice>> GetInvoicesList(int type)
        {
            var queryInfo = new
            {
                SortBy = "Date",
                SortDesc = true,
                Take = 200,
                Skip = 0
            };

            var parameters = new List<(string, object)>
            {
                ("queryInfo", queryInfo),
                ("type", type)
            };

            return await baseService.Post<ListResult<Invoice>>("invoice/getinvoices", parameters);
        }

        public async Task<Invoice> GetInvoice(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            return await baseService.Post<Invoice>("invoice/get", parameters);
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            var parameters = new List<(string, object)>
            {
                ("id", id)
            };
            return await baseService.Post<Invoice>("invoice/getById", parameters);
        }

        public async Task<OnlineInvoiceURL> GetOnlineInvoiceURL(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type)
            };
            return await baseService.Post<OnlineInvoiceURL>("invoice/getonlineinvoiceurl", parameters);
        }

        public async Task<bool> SavePayment(PaymentRequest paymentRequest)
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
            return await baseService.Post<bool>("invoice/savepayment", parameters);
        }

        public async Task<bool> Delete(int number, int type)
        {
            var parameters = new List<(string, object)>
            {
                ("number", number),
                ("type", type),
            };

            return await baseService.Post<bool>("invoice/delete", parameters);
        }

        public async Task<Invoice> Save(Invoice invoice)
        {
            return await baseService.Post<Invoice>("invoice/save", ("invoice", invoice));
        }

        public async Task<WarehouseReceipt> SaveWarehouseReceipt(WarehouseReceipt receipt)
        {
            return await baseService.Post<WarehouseReceipt>("invoice/SaveWarehouseReceipt", ("receipt", receipt));
        }

    }
}
