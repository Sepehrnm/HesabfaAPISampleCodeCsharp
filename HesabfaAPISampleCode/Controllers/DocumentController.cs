using HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Mvc;

namespace HesabfaAPISampleCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] int take)
        {
            return Ok(await documentService.GetList(take));
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] int number)
        {
            return Ok(await documentService.Get(number));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int number)
        {
            return Ok(await documentService.Delete(number));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Document document)
        {
            return Ok(await documentService.Save(document));
        }
    }
}
