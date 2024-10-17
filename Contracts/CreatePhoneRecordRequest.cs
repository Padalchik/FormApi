using FormApi.Entities;

namespace FormApi.Contracts
{
    public record CreatePhoneRecordRequest(
       Guid OwnerId,
       string PhoneNumber,
       PhoneType Type,
       string Model);
}
