using FormApi.Abstractions;
using FormApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FormApi.Repositories
{
    public class RelativeRepository : IRelativeRepository
    {
        private readonly ApplicationDBContext _context;

        public RelativeRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<List<Relative>> Get()
        {
            var allRelatives = await _context.Relatives.ToListAsync();

            return allRelatives;
        }

        public async Task<Relative> GetRelativeById(Guid id)
        {
            var relative = await _context.Relatives.FindAsync(id);

            if (relative == null)
                 throw new Exception("Relative not found");

            return relative;
        }

        public async Task<List<Relative>> GetRelativesByOwnerId(Guid id)
        {
            var relativesByOwner = await _context.Relatives.Where(r => r.OwnerId == id).ToListAsync();

            return relativesByOwner;
        }
    }
}
