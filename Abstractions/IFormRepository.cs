using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IFormRepository
    {
        Task<List<Form>> Get();
        Task<Form> GetFormById(Guid id);
        Task<Guid> Create(Form Form);
        Task<Guid> Delete(Guid id);
        Task Update(Form form);
    }
}
