namespace FormApi.Contracts
{
    public record CandidateResponse(
        Guid id,
        string firstName,
        string lastName,
        string middleName);
}
