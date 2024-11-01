using FormApi.Models;

namespace FormApi.Entities
{
    public class Relative
    {
        public Relative()
        {
        }

        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public RelativeType RelativeType { get; set; }
        public DateTime CreatedDate { get; set; } // Дополнительное поле, которое нужно хранить в БД
    }
}
