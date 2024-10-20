using FormApi.Entities;

namespace FormApi.Repositories
{
    public interface IPhoneRecordRepository
    {
        Task<Guid> Create(PhoneRecord phoneRecord);
        Task<PhoneRecord> GetById(Guid phoneRecordId);
    }
}
