using FormApi.Abstractions;
using FormApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormApi.Repositories
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly ApplicationDBContext _context;

        public CandidatesRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Candidate>> Get()
        {
            var allCandidates = await _context.Candidates.ToListAsync();

            return allCandidates;
        }

        public async Task<Candidate> GetCandidateById(Guid CandidateId)
        {
            var candidate = await _context.Candidates.FindAsync(CandidateId);

            return candidate;
        }

        public async Task<Guid> Create(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();

            return candidate.Id;
        }

        public async Task<Guid> Update(Guid id, string firstName, string lastName, string middleName)
        {
            await _context.Candidates
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.FirstName, c => firstName)
                .SetProperty(c => c.LastName, c => lastName)
                .SetProperty(c => c.MiddleName, c => middleName));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Candidates.Where(c => c.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
