using FormApi.Abstractions;
using FormApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormApi.Repositories
{
    public class RelativeRepository : IRelativeRepository
    {
        private readonly ApplicationDBContext _context;

        public RelativeRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Guid> CreateRelative (RelativeEntity relative)
        {
            relative.CreateDate = DateTime.UtcNow;

            await _context.Relatives.AddAsync(relative);
            await _context.SaveChangesAsync();

            return relative.Id;
        }

        public async Task<List<RelativeEntity>> Get()
        {
            var allRelatives = await _context.Relatives.ToListAsync();

            return allRelatives;
        }

        public async Task<RelativeEntity> GetRelativeById(Guid id)
        {
            var relative = await _context.Relatives.FindAsync(id);

            if (relative == null)
                 throw new Exception("Relative not found");

            return relative;
        }

        public async Task<List<RelativeEntity>> GetRelativesByForm(FormEntity form)
        {
            var relativesByOwner = await _context.Relatives.Where(r => r.Form == form).ToListAsync();

            return relativesByOwner;
        }
    }
}
