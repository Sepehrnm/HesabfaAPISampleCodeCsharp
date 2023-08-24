using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IDocumentService
    {
        object GetList(int take);
        Document Get(int number);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IBaseService BaseService;
        public DocumentService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public object GetList(int take)
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "Date";
            queryInfo.SortDesc = true;
            queryInfo.Take = take;
            queryInfo.Skip = 0;

            var result = BaseService.Post<object>("document/getdocuments", ("queryInfo", queryInfo));

            return result.Result;
        }

        public Document Get(int number)
        {
            var result = BaseService.Post<Document>("document/get", ("number", number));

            return result.Result;
        }
    }
}
