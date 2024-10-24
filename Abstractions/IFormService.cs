using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IFormService
    {
        Task<List<Form>> GetAllForm();
        Task<Form> GetFormById(Guid id);
        Task<Guid> CreateForm(Guid candidateId);
        Task<Guid> DeleteForm(Guid id);
    }
}
