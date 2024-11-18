namespace FormApi.Contracts
{
    public class CreateCandidateRequest
    {
        public CreateCandidateRequest(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; private set; } 
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
    }
}
