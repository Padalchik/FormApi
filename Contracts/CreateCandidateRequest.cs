namespace FormApi.Contracts
{
    public record CreateCandidateRequest(
       string firstName,
       string lastName,
       string middleName);
}
