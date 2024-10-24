using FormApi.Abstractions;
using FormApi.Entities;

namespace FormApi.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly ICandidatesService _candidatesService;

        public FormService(
            IFormRepository formRepository,
            ICandidatesService candidatesService
            )
        {
            _formRepository = formRepository;
            _candidatesService = candidatesService;
        }

        public async Task<Guid> CreateForm(Guid candidateId)
        {
            var candidate = await _candidatesService.GetCandidateById( candidateId );
            var createRequest = Form.Create(candidate);

            if (!string.IsNullOrEmpty(createRequest.Error))
                throw new InvalidOperationException();

            return await _formRepository.Create(createRequest.Form);
        }

        public async Task<Guid> DeleteForm(Guid id)
        {
            return await _formRepository.Delete(id);
        }

        public async Task<List<Form>> GetAllForm()
        {
            return await _formRepository.Get();
        }

        public async Task<Form> GetFormById(Guid id)
        {
            return await _formRepository.GetFormById(id);
        }
    }
}
