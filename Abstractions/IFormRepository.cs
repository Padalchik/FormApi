using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IFormRepository
    {
        Task<List<FormEntity>> Get();
        Task<FormEntity?> GetFormById(Guid id);
        Task<Guid> Create(FormEntity Form);
        Task Delete(Guid id);
        Task Update(FormEntity form);
    }
}
