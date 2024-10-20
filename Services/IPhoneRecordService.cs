using FormApi.Entities;

namespace FormApi.Services
{
    public interface IPhoneRecordService
    {
        Task AddPhoneRecordToForm(Guid formId, string phoneNumber, PhoneType type, string model);
    }
}
