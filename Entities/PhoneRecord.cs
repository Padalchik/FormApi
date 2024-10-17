namespace FormApi.Entities
{
    public class PhoneRecord
    {
        public PhoneRecord()
        {
        }

        private PhoneRecord(Guid formId, string phoneNumber, PhoneType type, string model)
        {
            Id = Guid.NewGuid();
            OwnerId = formId;
            PhoneNumber = phoneNumber;
            Type = type;
            Model = model;
        }
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public PhoneType Type { get; set; }
        public string Model { get; set; } = string.Empty;

        public static (PhoneRecord PhoneRecord, string Error) Create(Guid formId, string phoneNumber, PhoneType type, string model)
        {
            var error = string.Empty;
            var phoneRecord = new PhoneRecord(formId, phoneNumber, type, model);

            return (phoneRecord, error);
        }
    }

    public enum PhoneType
    {
        Mobile,
        Work,
        Home
    }
}
