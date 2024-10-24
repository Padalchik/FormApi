using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IRelativeRepository
    {
        Task<List<Relative>> Get();
        Task<Relative> GetRelativeById(Guid id);
        Task<List<Relative>> GetRelativesByOwnerId(Guid id);
    }
}
