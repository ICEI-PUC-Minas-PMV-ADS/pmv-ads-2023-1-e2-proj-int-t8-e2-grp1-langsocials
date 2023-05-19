using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface ILocationRepository
{
    Task Add(Location location, CancellationToken cancellationToken = default);

    Task<Location?> Find(int id, CancellationToken cancellationToken);
}
