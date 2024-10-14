using FormApi.Contracts;
using FormApi.Entities;
using FormApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("{candidateId:guid}")]
        public async Task<ActionResult<Guid>> CreateForm(Guid candidateId)
        {
            var formId = await _formService.CreateForm(candidateId);
            return Ok(formId);
        }
    }
}
