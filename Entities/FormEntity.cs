
namespace FormApi.Entities
{
    public class FormEntity
    {
        // Публичный конструктор по умолчанию, который нужен EF Core
        public FormEntity()
        {
        }

        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public virtual List<Guid> PhoneRecords { get; set; } = new List<Guid>();

        public virtual List<Guid> Relatives { get; set; } = new List<Guid>();
    }
}
