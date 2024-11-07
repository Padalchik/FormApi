using FormApi.Abstractions;
using FormApi.Entities;
using FormApi.Mappers;
using FormApi.Models;

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
            var form = new FormModel(candidate);

            return await _formRepository.Create(FormMapper.ToEntity(form));
        }

        public async Task<Guid> DeleteForm(Guid id)
        {
            return await _formRepository.Delete(id);
        }

        public async Task<List<FormEntity>> GetAllForm()
        {
            return await _formRepository.Get();
        }

        public async Task<FormEntity> GetFormById(Guid id)
        {
            return await _formRepository.GetFormById(id);
        }
    }
}
