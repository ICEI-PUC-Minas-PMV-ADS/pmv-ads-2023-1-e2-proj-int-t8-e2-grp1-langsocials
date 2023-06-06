using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface ILocationRepository
{
    Task Add(Location location, CancellationToken cancellationToken = default);
    IEnumerable<Location> Search(string nameFilter, string? cityFilter = null, string? stateFilter = null);
    Task<bool> AlreadyExists(string nameFilter, string streetFilter, string numberFilter, string postalCodeFilter, CancellationToken cancellationToken = default);
    Task<Location?> Find(int id, CancellationToken cancellationToken);
    void Update(Location location);
}
