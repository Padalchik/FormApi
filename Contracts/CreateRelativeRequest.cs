using FormApi.Models;

namespace FormApi.Contracts
{
    public record CreateRelativeRequest(
        Guid FormId,
        string FirstName,
        string LastName,
        string MiddleName,
        RelativeType relativeType);
}
