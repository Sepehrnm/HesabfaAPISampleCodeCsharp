using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IDocumentService
    {
        Task<ListResult<Document>> GetList(int take);
        Task<Document> Get(int number);
        Task<bool> Delete(int number);
        Task<Document> Save(Document document);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IBaseService baseService;
        public DocumentService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ListResult<Document>> GetList(int take)
        {
            var queryInfo = new QueryInfo();
            queryInfo.SortBy = "Date";
            queryInfo.SortDesc = true;
            queryInfo.Take = take;
            queryInfo.Skip = 0;

            return await baseService.Post<ListResult<Document>>("document/getdocuments", ("queryInfo", queryInfo));
        }

        public async Task<Document> Get(int number)
        {
            return await baseService.Post<Document>("document/get", ("number", number));
        }

        public async Task<bool> Delete(int number)
        {
            return await baseService.Post<bool>("document/delete", ("number", number));
        }

        public async Task<Document> Save(Document document)
        {
            return await baseService.Post<Document>("document/save", ("document", document));
        }
    }
}
