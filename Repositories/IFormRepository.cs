using FormApi.Entities;

namespace FormApi.Repositories
{
    public interface IFormRepository
    {
        Task<List<Form>> Get();
        Task<Form> GetFormById(Guid id);
        Task<Guid> Create(Form Form);
        Task<Guid> Delete(Guid id);
    }
}
