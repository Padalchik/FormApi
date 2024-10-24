using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IPhoneRecordService
    {
        Task AddPhoneRecordToForm(Guid formId, string phoneNumber, PhoneType type, string model);
        Task DeletePhoneRecordFromForm(Guid formId, Guid phoneRecordId);
    }
}
