using FormApi.Abstractions;
using FormApi.Contracts;
using FormApi.Contracts.Examples;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace FormApi.Controllers
{
    public class RelativeController : Controller
    {
        public readonly IRelativeService _relativeService;
        public readonly IRelativeRepository _relativeRepository;
        public RelativeController(IRelativeService relativeService, IRelativeRepository relativeRepository)
        {
            _relativeService = relativeService;
            _relativeRepository = relativeRepository;
        }

        [HttpPut("CreateRelative")]
        [SwaggerRequestExample(typeof(CreateRelativeRequest), typeof(CreateRelativeRequestExample))]
        public async Task<ActionResult> CreateRelative([FromBody] CreateRelativeRequest request)
        {
            var createRelativeParams = new Dictionary<string, object>
            {
                { "FirstName", request.FirstName },
                { "LastName", request.LastName },
                { "MiddleName", request.MiddleName },
                { "RelativeType", request.relativeType }
            };

            var relativeId = await _relativeService.CreateRelative(request.FormId, createRelativeParams);

            return Ok(relativeId);
        }
    }
}
