using FormApi.Entities;
using FormApi.Models;

namespace FormApi.Abstractions
{
    public interface IRelativeService
    {
        Task<Guid> CreateRelative(Guid formId, Dictionary<string, object> relativeParams);
    }
}
