using FormApi.Abstractions;
using FormApi.Entities;

namespace FormApi.Models
{
    public class FormModel : Person
    {
        
        private List<PhoneRecord> _phoneRecords = new List<PhoneRecord>();
        private List<RelativeModel> _relatives       = new List<RelativeModel>();

        public FormModel(Candidate candidate) : base(candidate.FirstName, candidate.LastName, candidate.MiddleName)
        {
            Candidate    = candidate;
        }
        public Candidate Candidate { get; private set; }
        public IReadOnlyList<RelativeModel> Relatives => _relatives.AsReadOnly();
        public IReadOnlyList<PhoneRecord> PhoneRecords => _phoneRecords.AsReadOnly();

        public void AddPhoneRecord(PhoneRecord record)
        {
            _phoneRecords.Add(record);
        }

        public void AddRelative(Models.RelativeModel relative)
        {
            _relatives.Add(relative);
        }
    }
}
