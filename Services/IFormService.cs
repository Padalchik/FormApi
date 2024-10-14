using FormApi.Entities;

namespace FormApi.Services
{
    public interface IFormService
    {
        Task<Guid> CreateForm(Guid candidateId);
    }
}
