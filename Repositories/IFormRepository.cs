using FormApi.Entities;

namespace FormApi.Repositories
{
    public interface IFormRepository
    {
        Task<Guid> Create(Form Form);
    }
}
