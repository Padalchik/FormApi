using FormApi.Abstractions;
using FormApi.Models;

namespace FormApi.Entities
{
    public class RelativeEntity : Entity
    {
        public RelativeEntity()
        {
        }

        public virtual FormEntity Form { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public RelativeType RelativeType { get; set; }
    }
}
