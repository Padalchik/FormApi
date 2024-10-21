using FormApi.Services;
using Microsoft.AspNetCore.Mvc;
using FormApi.Contracts;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace FormApi.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class PhoneRecordController : Controller
    {
        private readonly IPhoneRecordService _phoneRecordService;
        private readonly IFormService _formService;

        public PhoneRecordController(IPhoneRecordService phoneRecordService, IFormService formService)
        {
            _phoneRecordService = phoneRecordService;
            _formService = formService;
        }

        [HttpPut("add-phone-record")]
        public async Task<ActionResult> AddPhoneRecord([FromBody] CreatePhoneRecordRequest request)
        {
            await _phoneRecordService.AddPhoneRecordToForm(request.OwnerId, request.PhoneNumber, request.Type, request.Model);

            var a = await _formService.GetFormById(request.OwnerId);

            return Ok();
        }

        [HttpDelete("delete-phone-record")]
        public async Task<ActionResult> DeletePhoneRecord([FromBody] DeletePhoneRecordRequest request)
        {
            await _phoneRecordService.DeletePhoneRecordFromForm(request.FormId, request.PhoneRecordId);
            return Ok();
        }
    }
}
