using HesabfaAPISampleCode.Models;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IContactService
    {
        Task<ContactList> GetContactList();
        Task<T> GetContact<T>(string code);
        Task<List<Contact>> GetContactById(Array idList);
        Task<T> SaveContact<T>(object contact);
        Task<object> DeleteContact(string code);
        Task<T> GetContactLink<T>(string code, bool showAllAccounts, int days);
    }
    public class ContactService : IContactService
    {
        private readonly IBaseService BaseService;
        public ContactService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public async Task<T> GetContact<T>(string code)
        {
            var result = await BaseService.Post<Contact>("contact/get", ("code", code));
            if(!result.Success)
            {
                return (T)(object)new { Success = false , ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            } else
            {
                return (T)(object)(Contact)result.Result;
            }
        }

        public async Task<List<Contact>> GetContactById(Array idList)
        {
            var result = await BaseService.Post<List<Contact>>("contact/getById", ("idList", idList));

            return result.Result;
        }

        public async Task<T> SaveContact<T>(object contact)
        {
            var result = await BaseService.Post<Contact>("contact/save", ("contact", contact));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(Contact)result.Result;
            }
        }

        public async Task<object> DeleteContact(string code)
        {
            var result = await BaseService.Post<object>("contact/delete", ("code", code));

            return result;
        }
        public async Task<T> GetContactLink<T>(string code, bool showAllAccounts, int days)
        {
            var parameters = new List<(string, object)>
            {
                ("code", code),
                ("showAllAccounts", showAllAccounts),
                ("days", days)
            };

            var result = await BaseService.Post<ContactLink>("contact/getContactLink", parameters);

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(ContactLink)result.Result;
            }
        }

        public async Task<ContactList> GetContactList()
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "Code";
            queryInfo.SortDesc = true;
            queryInfo.Take = 20000;
            queryInfo.Skip = 0;

            var result = await BaseService.Post<ContactList>("contact/getcontacts", ("queryInfo", queryInfo));

            return result.Result;
        }
    }
}
