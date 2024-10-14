
namespace FormApi.Entities
{
    public class Form
    {
        // Публичный конструктор по умолчанию, который нужен EF Core
        public Form()
        {
        }

        private Form(Candidate candidate)
        {
            Id = Guid.NewGuid();

            CandidateId = candidate.Id;
            FirstName   = candidate.FirstName;
            LastName    = candidate.LastName;
            MiddleName  = candidate.MiddleName;
        }

        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public static (Form Form, string Error) Create(Candidate candidate)
        {
            var error = string.Empty;
            var form = new Form(candidate);

            return (form, error);
        }
    }
}
