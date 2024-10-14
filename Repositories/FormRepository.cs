using FormApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormApi.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDBContext _context;

        public FormRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Form>> Get()
        {
            var allForm = await _context.Forms.ToListAsync();

            return allForm;
        }

        public async Task<Form> GetFormById(Guid FormId)
        {
            var form = await _context.Forms.FindAsync(FormId);

            return form;
        }

        public async Task<Guid> Create(Form form)
        {
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();

            return form.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Forms.Where(c => c.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
