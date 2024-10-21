﻿using FormApi.Entities;

namespace FormApi.Repositories
{
    public interface IPhoneRecordRepository
    {
        Task<List<PhoneRecord>> Get();
        Task<PhoneRecord> GetById(Guid phoneRecordId);
        Task<Guid> Create(PhoneRecord phoneRecord);
        Task<Guid> Delete(Guid id);
        Task Update(PhoneRecord phoneRecord);
    }
}
