using FormApi.Repositories;
using FormApi.Entities;

namespace FormApi.Services
{
    public class CandidatesService : ICandidatesService
    {
        private readonly ICandidatesRepository _candidatesRepository;

        public CandidatesService(ICandidatesRepository candidatesRepository)
        {
            _candidatesRepository = candidatesRepository;
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            return await _candidatesRepository.Get();
        }

        public async Task<Candidate> GetCandidateById(Guid CandidateId)
        {
            var candidate = await _candidatesRepository.GetCandidateById(CandidateId);

            return candidate;
        }

        public async Task<Guid> CreateCandidate(Candidate candidate)
        {
            return await _candidatesRepository.Create(candidate);
        }

        public async Task<Guid> UpdateCandidate(Guid id, string firstName, string lastName, string middleName)
        {
            return await _candidatesRepository.Update(id, firstName, lastName, middleName);
        }

        public async Task<Guid> DeleteCandidate(Guid id)
        {
            return await _candidatesRepository.Delete(id);
        }
    }
}
