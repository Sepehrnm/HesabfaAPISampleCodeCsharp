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
        public IActionResult Get([FromBody] string code)
        {
            var response = contactService.GetContact<object>(code);
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
        public IActionResult GetList()
        {
            var response = contactService.GetContactList();
            var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.List));
            return new FileContentResult(jsonBytes, "application/json; charset=utf-8");
        }

        [HttpPost]
        public IActionResult GetById([FromBody] int[] idList)
        {
            List<Contact> response = contactService.GetContactById(idList);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Save([FromBody] object contact)
        {
            Contact response = contactService.SaveContact(contact);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] string code)
        {
            var response = contactService.DeleteContact(code);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetContactLink([FromBody] ContactLinkRequest contactLinkRequest)
        {
            ContactLink response = contactService.GetContactLink(contactLinkRequest.Code, contactLinkRequest.ShowAllAccounts, contactLinkRequest.Days);
            return Ok(response);
        }
    }
}
