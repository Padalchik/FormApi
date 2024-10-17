using FormApi.Entities;
using FormApi.Repositories;

namespace FormApi.Services
{
    public class PhoneRecordService : IPhoneRecordService
    {
        private readonly IPhoneRecordRepository _phoneRecordRepository;
        private readonly IFormRepository _formRepository;

        public PhoneRecordService(IPhoneRecordRepository phoneRecordRepository, IFormRepository formRepository)
        {
            _phoneRecordRepository = phoneRecordRepository;
            _formRepository = formRepository;
        }

        public async Task AddPhoneRecordToForm(Guid formId, string phoneNumber, PhoneType type, string model)
        {
            var phoneRecord = await CreatePhoneRecord(formId, phoneNumber, type, model);

            var form = await _formRepository.GetFormById(formId);
            if (form == null)
                throw new InvalidOperationException("Анкета не найдена");

            form.AddPhoneRecord(phoneRecord);

            await _formRepository.Update(form);
        }

        private async Task<PhoneRecord> CreatePhoneRecord(Guid formId, string phoneNumber, PhoneType type, string model)
        {
            var createRequest = PhoneRecord.Create(formId, phoneNumber, type, model);

            if (!string.IsNullOrEmpty(createRequest.Error))
                throw new InvalidOperationException(createRequest.Error);

            var phoneRecordId = await _phoneRecordRepository.Create(createRequest.PhoneRecord);

            return await _phoneRecordRepository.GetById(phoneRecordId);
        }
    }
}
