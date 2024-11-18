using FormApi.Abstractions;
using FormApi.Entities;
using FormApi.Mappers;
using FormApi.Models;

namespace FormApi.Services
{
    public class RelativeService : IRelativeService
    {
        private readonly IRelativeRepository _relativeRepository;
        private readonly IFormRepository _formRepository;

        public RelativeService(IRelativeRepository relativeRepository, IFormRepository formRepository)
        {
            _relativeRepository = relativeRepository;
            _formRepository = formRepository;
        }

        public async Task<Guid> CreateRelative(Guid formId, Dictionary<string, object> relativeParams)
        {
            if (formId == Guid.Empty)
                return Guid.Empty;

            if (await _formRepository.GetFormById(formId) is not FormEntity formEntity)
                return Guid.Empty;

            var formModel  = FormMapper.ToModel(formEntity);

            var relativeAnswer = RelativeModel.Create(formModel, relativeParams);

            if (string.IsNullOrEmpty(relativeAnswer.Error) == false)
                throw new Exception(relativeAnswer.Error);

            if (relativeAnswer.RelativeModel is not RelativeModel)
                throw new Exception("Не найден `RelativeModel`");

            RelativeEntity relativeEntity = RelativeMapper.ToEntity(relativeAnswer.RelativeModel);
            await _relativeRepository.CreateRelative(relativeEntity);

            return relativeEntity.Id;
        }
    }
}
