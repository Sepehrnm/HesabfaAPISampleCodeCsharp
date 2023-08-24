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
        object SavePayment(PaymentRequest requestObject);
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

        public object SavePayment(PaymentRequest requestObject)
        {
            var parameters = new List<(string, object)>
            {
                ("number", requestObject.Number),
                ("type", requestObject.Type),
                ("bankCode", requestObject.BankCode),
                ("date", requestObject.Date),
                ("amount", requestObject.Amount),
                ("transactionNumber", requestObject.TransactionNumber),
                ("description", requestObject.Description),
                ("transactionFee", requestObject.TransactionFee),
            };
            var result = BaseService.Post<object>("invoice/savepayment", parameters);

            return result.Result;
        }
        
    }
}
