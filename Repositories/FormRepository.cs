using FormApi.Entities;

namespace FormApi.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDBContext _context;

        public FormRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Guid> Create(Form form)
        {
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();

            return form.Id;
        }
    }
}
