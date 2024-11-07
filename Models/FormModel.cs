using FormApi.Abstractions;
using FormApi.Entities;

namespace FormApi.Models
{
    public class FormModel : Person
    {
        private Candidate _candidate;
        private List<PhoneRecord> _phoneRecords = new List<PhoneRecord>();
        private List<Relative> _relatives       = new List<Relative>();

        public FormModel(Candidate candidate) : base(candidate.FirstName, candidate.LastName, candidate.MiddleName)
        {
            _candidate    = candidate;
        }

        public IReadOnlyList<Relative> Relatives => _relatives.AsReadOnly();
        public IReadOnlyList<PhoneRecord> PhoneRecords => _phoneRecords.AsReadOnly();

        public void AddPhoneRecord(PhoneRecord record)
        {
            _phoneRecords.Add(record);
        }

        public void AddRelative(Models.Relative relative)
        {
            _relatives.Add(relative);
        }
    }
}
