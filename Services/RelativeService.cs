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

        public async Task<Guid> CreateRelative(Guid formId, string firstName, string lastName, string middleName, RelativeType relativeType)
        {
            var form = _formRepository.GetFormById(formId).Result;

            var relative = new Models.Relative(form, firstName, lastName, middleName, relativeType);

            var relativeId = form.AddRelative(relative);

            await _formRepository.Update(form);

            return relativeId;
        }
    }
}
