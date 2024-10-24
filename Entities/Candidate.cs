namespace FormApi.Entities
{
    public class Candidate
    {
        public Candidate()
        {
            
        }

        private Candidate(string firstName, string lastName, string middleName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public static (Candidate Candidate, string Error) Create(string firstName, string lastName, string middleName = "")
        {
            var error = string.Empty;
            var candidate = new Candidate(firstName, lastName, middleName);

            return (candidate, error);
        }
    }
}
