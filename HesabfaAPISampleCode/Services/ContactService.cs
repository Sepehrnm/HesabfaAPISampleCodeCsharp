using HesabfaAPISampleCode.Models;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IContactService
    {
        ContactList GetContactList();
        T GetContact<T>(string code);
        List<Contact> GetContactById(Array idList);
        Contact SaveContact(object contact);
        object DeleteContact(string code);
        ContactLink GetContactLink(string code, bool showAllAccounts, int days);
    }
    public class ContactService : IContactService
    {
        private readonly IBaseService BaseService;
        public ContactService(IBaseService BaseService)
        {
            this.BaseService = BaseService;
        }

        public T GetContact<T>(string code)
        {
            var result = BaseService.Post<Contact>("contact/get", ("code", code));
            if(!result.Success)
            {
                return (T)(object)new { Success = false , ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            } else
            {
                return (T)(object)(Contact)result.Result;
            }
        }

        public List<Contact> GetContactById(Array idList)
        {
            var result = BaseService.Post<List<Contact>>("contact/getById", ("idList", idList));

            return result.Result;
        }

        public Contact SaveContact(object contact)
        {
            var result = BaseService.Post<Contact>("contact/save", ("contact", contact));

            return result.Result;
        }

        public object DeleteContact(string code)
        {
            var result = BaseService.Post<object>("contact/delete", ("code", code));

            return result.Result;
        }
        public ContactLink GetContactLink(string code, bool showAllAccounts, int days)
        {
            var parameters = new List<(string, object)>
            {
                ("code", code),
                ("showAllAccounts", showAllAccounts),
                ("days", days)
            };

            var result = BaseService.Post<ContactLink>("contact/getContactLink", parameters);

            return result.Result;
        }

        public ContactList GetContactList()
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "Code";
            queryInfo.SortDesc = true;
            queryInfo.Take = 20000;
            queryInfo.Skip = 0;

            var result = BaseService.Post<ContactList>("contact/getcontacts", ("queryInfo", queryInfo));

            return result.Result;
        }
    }
}
