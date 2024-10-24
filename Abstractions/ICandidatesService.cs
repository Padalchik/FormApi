using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface ICandidatesService
    {
        Task<List<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(Guid id);
        Task<Guid> CreateCandidate(Candidate candidate);
        Task<Guid> DeleteCandidate(Guid id);
        Task<Guid> UpdateCandidate(Guid id, string firstName, string lastName, string middleName);
    }
}