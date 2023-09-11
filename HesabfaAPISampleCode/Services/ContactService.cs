using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IContactService
    {
        Task<ListResult<Contact>> GetContactList();
        Task<Contact> GetContact(string code);
        Task<List<Contact>> GetContactById(Array idList);
        Task<Contact> SaveContact(SaveContactRequest contact);
        Task<bool> DeleteContact(string code);
        Task<ContactLink> GetContactLink(string code, bool showAllAccounts, int days);
    }
    public class ContactService : IContactService
    {
        private readonly IBaseService baseService;
        public ContactService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<Contact> GetContact(string code)
        {
            return await baseService.Post<Contact>("contact/get", ("code", code));
        }

        public async Task<List<Contact>> GetContactById(Array idList)
        {
            return await baseService.Post<List<Contact>>("contact/getById", ("idList", idList));
        }

        public async Task<Contact> SaveContact(SaveContactRequest contact)
        {
            return await baseService.Post<Contact>("contact/save", ("contact", contact));
        }

        public async Task<bool> DeleteContact(string code)
        {
            return await baseService.Post<bool>("contact/delete", ("code", code));
        }
        public async Task<ContactLink> GetContactLink(string code, bool showAllAccounts, int days)
        {
            var parameters = new List<(string, object)>
            {
                ("code", code),
                ("showAllAccounts", showAllAccounts),
                ("days", days)
            };

            return await baseService.Post<ContactLink>("contact/getContactLink", parameters);
        }

        public async Task<ListResult<Contact>> GetContactList()
        {
            dynamic queryInfo = new System.Dynamic.ExpandoObject();
            queryInfo.SortBy = "Code";
            queryInfo.SortDesc = true;
            queryInfo.Take = 20000;
            queryInfo.Skip = 0;

            return await baseService.Post<ListResult<Contact>>("contact/getcontacts", ("queryInfo", queryInfo));
        }
    }
}
