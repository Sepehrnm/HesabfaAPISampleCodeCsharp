using HesabfaAPISampleCode.Models;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IDocumentService
    {
        Task<object> GetList(int take);
        Task<Document> Get(int number);
        Task<object> Delete(int number);
        Task<T> Save<T>(Document document);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IBaseService BaseService;
        public DocumentService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public async Task<object> GetList(int take)
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "Date";
            queryInfo.SortDesc = true;
            queryInfo.Take = take;
            queryInfo.Skip = 0;

            var result = await BaseService.Post<object>("document/getdocuments", ("queryInfo", queryInfo));

            return result.Result;
        }

        public async Task<Document> Get(int number)
        {
            var result = await BaseService.Post<Document>("document/get", ("number", number));

            return result.Result;
        }

        public async Task<object> Delete(int number)
        {
            var result = await BaseService.Post<object>("document/delete", ("number", number));
            return result;
        }

        public async Task<T> Save<T>(Document document)
        {
            var result = await BaseService.Post<Document>("document/save", ("document", document));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(Document)result.Result;
            }
        }
    }
}
