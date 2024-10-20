using FormApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormApi.Repositories
{
    public class PhoneRecordRepository : IPhoneRecordRepository
    {
        private readonly ApplicationDBContext _context;

        public PhoneRecordRepository(ApplicationDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Guid> Create(PhoneRecord phoneRecord)
        {
            await _context.PhoneRecords.AddAsync(phoneRecord);
            await _context.SaveChangesAsync();

            return phoneRecord.Id;
        }

        public async Task<PhoneRecord> GetById(Guid phoneRecordId)
        {
            return await _context.PhoneRecords.FirstOrDefaultAsync(pr => pr.Id == phoneRecordId);
        }
    }
}
