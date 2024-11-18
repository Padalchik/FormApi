using FormApi.Abstractions;
using FormApi.Entities;

namespace FormApi.Models
{
    public class RelativeModel : Person
    {
        public static (RelativeModel? RelativeModel, string Error) Create(FormModel form, Dictionary<string, object> relativeParams)
        {
            List<string> errors = [];

            string firstName = string.Empty;
            string lastName = string.Empty;
            string middleName = string.Empty;
            RelativeType relativeType = default;

            if (relativeParams.GetValueOrDefault("FirstName") is not string firstNameParam || firstNameParam == string.Empty)
                errors.Add("Не найден обязательный параметр `FirstName`");
            else
                firstName = firstNameParam;

            if (relativeParams.GetValueOrDefault("LastName") is not string lastNameParam || lastNameParam == string.Empty)
                errors.Add("Не найден обязательный параметр `LastName`");
            else
                lastName = lastNameParam;

            if (relativeParams.GetValueOrDefault("MiddleName") is not string middleNameParam || middleNameParam == string.Empty)
                errors.Add("Не найден обязательный параметр `MiddleName`");
            else
                middleName = middleNameParam;

            if (relativeParams.GetValueOrDefault("RelativeType") is not RelativeType relativeTypeParam)
                errors.Add("Не найден обязательный параметр `RelativeType`");
            else
                relativeType = relativeTypeParam;

            var error = string.Empty;

            if (errors.Any())
            {
                error = String.Join("\n", errors);
                return (null, error);
            }

            var relativeModel = new RelativeModel(form, firstName, lastName, middleName, relativeType);
            form.AddRelative(relativeModel);

            return (relativeModel, error);
        }

        public FormModel Form { get; set; }
        public RelativeType RelativeType { get; private set; }

        private RelativeModel(FormModel form, string firstName, string lastName, string middleName, RelativeType relativeType) : base(firstName, lastName, middleName)
        {
            Form = form;
            RelativeType = relativeType;
        }
    }
    public enum RelativeType
    {
        Mother,
        Father,
        Brother,
        Sister
    }
}
