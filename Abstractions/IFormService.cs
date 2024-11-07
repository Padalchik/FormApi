using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IFormService
    {
        Task<List<FormEntity>> GetAllForm();
        Task<FormEntity> GetFormById(Guid id);
        Task<Guid> CreateForm(Guid candidateId);
        Task<Guid> DeleteForm(Guid id);
    }
}
