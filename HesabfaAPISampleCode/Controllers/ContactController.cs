using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] string code)
        {
            return Ok(await contactService.GetContact(code));
        }

        [HttpPost]
        public async Task<IActionResult> GetList()
        {
            return Ok(await contactService.GetContactList());
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int[] idList)
        {
            return Ok(await contactService.GetContactById(idList));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveContactRequest contact)
        {
            return Ok(await contactService.SaveContact(contact));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string code)
        {
            return Ok(await contactService.DeleteContact(code));
        }

        [HttpPost]
        public async Task<IActionResult> GetContactLink([FromBody] ContactLinkRequest contactLinkRequest)
        {
            return Ok(await contactService.GetContactLink(contactLinkRequest.Code, contactLinkRequest.ShowAllAccounts, contactLinkRequest.Days));
        }
    }
}
