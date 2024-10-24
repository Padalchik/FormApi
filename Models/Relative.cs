using FormApi.Abstractions;
using FormApi.Entities;

namespace FormApi.Models
{
    public class Relative : Person
    {
        public Relative(Form form, string firstName, string lastName, string middleName, RelativeType relativeType) : base(firstName, lastName, middleName)
        {
            Form = form;
            RelativeType = relativeType;
        }

        public Form Form { get; set; }
        public RelativeType RelativeType { get; private set; }
    }

    public enum RelativeType
    {
        Mother,
        Father,
        Brother,
        Sister
    }
}
