using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IInvoiceService
    {
        Invoice GetInvoicesList(int type);
        InvoiceItem GetInvoice(int number, int type);
        OnlineInvoiceURL GetOnlineInvoiceURL(int number, int type);
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
    }
}
