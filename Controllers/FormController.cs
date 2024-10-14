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

        [HttpGet]
        public async Task<ActionResult<List<Form>>> GetCandidates()
        {
            var allForm = await _formService.GetAllForm();

            return Ok(allForm);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Form>> GetCandidateById(Guid id)
        {
            var form = await _formService.GetFormById(id);
            return Ok(form);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteForm(Guid id)
        {
            return Ok(await _formService.DeleteForm(id));
        }
    }
}
