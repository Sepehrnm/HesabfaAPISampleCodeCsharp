using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

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
            var response = await contactService.GetContact<object>(code);
            if (response is Contact)
            {
                return Ok(response as Contact);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetList()
        {
            var response = await contactService.GetContactList();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.List));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] int[] idList)
        {
            List<Contact> response = await contactService.GetContactById(idList);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] object contact)
        {
            var response = await contactService.SaveContact<object>(contact);
            if (response is Contact)
            {
                return Ok(response as Contact);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string code)
        {
            var response = await contactService.DeleteContact(code);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetContactLink([FromBody] ContactLinkRequest contactLinkRequest)
        {
            var response = await contactService.GetContactLink<object>(contactLinkRequest.Code, contactLinkRequest.ShowAllAccounts, contactLinkRequest.Days);
            if (response is ContactLink)
            {
                return Ok(response as ContactLink);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
