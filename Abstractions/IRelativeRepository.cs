using FormApi.Entities;

namespace FormApi.Abstractions
{
    public interface IRelativeRepository
    {
        Task<Guid> CreateRelative(RelativeEntity relative);
        Task<List<RelativeEntity>> Get();
        Task<RelativeEntity> GetRelativeById(Guid id);
        Task<List<RelativeEntity>> GetRelativesByForm(FormEntity form);
    }
}
