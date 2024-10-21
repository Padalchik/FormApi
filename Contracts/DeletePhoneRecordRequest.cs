using FormApi.Entities;

namespace FormApi.Contracts
{
    public record DeletePhoneRecordRequest(
       Guid FormId,
       Guid PhoneRecordId);
}
