using FormApi.Abstractions;
using FormApi.Entities;
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
        public async Task<ActionResult<List<FormEntity>>> GetAllForm()
        {
            var allForm = await _formService.GetAllForm();

            return Ok(allForm);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FormEntity>> GetFormById(Guid id)
        {
            var form = await _formService.GetFormById(id);
            return Ok(form);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteForm(Guid id)
        {
            await _formService.DeleteForm(id);
            return Ok();
        }
    }
}
