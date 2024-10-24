using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface ICandidatesRepository
    {
        Task<List<Candidate>> Get();
        Task<Candidate> GetCandidateById(Guid id);
        Task<Guid> Create(Candidate candidate);
        Task<Guid> Delete(Guid id);
        Task<Guid> Update(Guid id, string firstName, string lastName, string middleName);
    }
}