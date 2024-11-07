using FormApi.Abstractions;
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

        public async Task<List<FormEntity>> Get()
        {
            var allForm = await _context.Forms.ToListAsync();

            return allForm;
        }

        public async Task<FormEntity?> GetFormById(Guid formId)
        {
            var form = await _context.Forms.FindAsync(formId);
            return form;
        }

        public async Task<Guid> Create(FormEntity form)
        {
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();

            return form.Id;
        }

        public async Task Delete(Guid id)
        {
            var formsToDelete = _context.Forms.Where(c => c.Id == id);

            foreach (var form in formsToDelete)
                await formsToDelete.ExecuteDeleteAsync();
        }

        public async Task Update(FormEntity form)
        {
            _context.Forms.Update(form);
            await _context.SaveChangesAsync();
        }
    }
}
