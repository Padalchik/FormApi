using FormApi.Contracts;
using FormApi.Entities;
using FormApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        private readonly ICandidatesService _candidatesService;

        public CandidateController(ICandidatesService candidatesService)
        {
            _candidatesService = candidatesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CandidateResponse>>> GetCandidates()
        {
            var candidates = await _candidatesService.GetAllCandidates();

            var response = candidates.Select(o => new CandidateResponse(o.Id, o.FirstName, o.LastName, o.MiddleName));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CandidateResponse>> GetCandidateById(Guid id)
        {
            var candidate = await _candidatesService.GetCandidateById(id);

            var response = new CandidateResponse(candidate.Id, candidate.FirstName, candidate.LastName, candidate.MiddleName);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCandidate([FromBody] CandidateRequest request)
        {
            var (candidate, error) = Candidate.Create(
                request.firstName,
                request.lastName,
                request.middleName);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);
            
            var candidateId = await _candidatesService.CreateCandidate(candidate);

            return Ok(candidateId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCandidate(Guid id, [FromBody] CandidateRequest request )
        {
            var candidateId = await _candidatesService.UpdateCandidate(id, request.firstName, request.lastName, request.middleName);

            return Ok(candidateId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCandidate(Guid id)
        {
            return Ok( await _candidatesService.DeleteCandidate(id));
        }
    }
}
