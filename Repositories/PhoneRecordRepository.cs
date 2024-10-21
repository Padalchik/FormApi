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

        public async Task<Guid> Delete(Guid id)
        {
            var phoneRecordToDelete = _context.Forms.Where(c => c.Id == id);

            if (phoneRecordToDelete.Any())
            {
                await phoneRecordToDelete.ExecuteDeleteAsync();
                return id;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<PhoneRecord>> Get()
        {
            var allPhoneRecord = await _context.PhoneRecords.ToListAsync();

            return allPhoneRecord;
        }

        public async Task<PhoneRecord> GetById(Guid phoneRecordId)
        {
            return await _context.PhoneRecords.FirstOrDefaultAsync(pr => pr.Id == phoneRecordId);
        }

        public async Task Update(PhoneRecord phoneRecord)
        {
            _context.PhoneRecords.Update(phoneRecord);
            await _context.SaveChangesAsync();
        }
    }
}
