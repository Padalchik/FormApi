using FormApi.Abstractions;
using FormApi.Entities;

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

        public Task DeletePhoneRecordFromForm(Guid formId, Guid phoneRecordId)
        {
            var form = _formRepository.GetFormById(formId).Result;

            var allPhoneRecordId = form.PhoneRecords.Select(pr => pr.Id);
            var searchedphoneRecords = allPhoneRecordId.Where(o => o == phoneRecordId);

            if (searchedphoneRecords.Any())
                searchedphoneRecords.ToList().ForEach(o => _phoneRecordRepository.Delete(o));

            return Task.CompletedTask;
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
