
namespace FormApi.Abstractions
{
    public abstract class Person
    {
        public Person(string firstName, string lastName, string middleName)
        {
            FirstName  = firstName;
            LastName   = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string MiddleName { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }

        public int Age => CalculateAge();

        public bool SetBirthDate(DateTime birthDate)
        {
            var result = true;

            if ( DateTime.Now > birthDate )
                result = false;

            if ( result )
                BirthDate = birthDate;

            return result;
        }

        private int CalculateAge()
        {
            var age = 0;

            if (BirthDate != DateTime.MinValue)
                age = CalculateFullYearsBetweenDates(BirthDate, DateTime.Now);

            return age;
        }

        private int CalculateFullYearsBetweenDates(DateTime start, DateTime end)
        {
            int years = end.Year - start.Year;

            // Проверяем, прошел ли полный год с учетом месяца и дня
            if (end.Month < start.Month || (end.Month == start.Month && end.Day < start.Day))
            {
                years--;
            }

            return years;
        }
    }

}
