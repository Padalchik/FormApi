
using FormApi.Abstractions;

namespace FormApi.Entities
{
    public class FormEntity : Entity
    {
        // Публичный конструктор по умолчанию, который нужен EF Core
        public FormEntity()
        {
        }

        public virtual Candidate Candidate { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public virtual List<PhoneRecord> PhoneRecords { get; set; } = [];
        public virtual List<RelativeEntity> Relatives { get; set; } = [];
    }
}
