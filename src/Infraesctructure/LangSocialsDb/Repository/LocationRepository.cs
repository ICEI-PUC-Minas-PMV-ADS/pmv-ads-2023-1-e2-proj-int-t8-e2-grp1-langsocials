using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb.Repository;

public class LocationRepository : ILocationRepository
{
    private readonly LangSocialsDbContext langSocialsDbContext;

    public LocationRepository(LangSocialsDbContext langSocialsDbContext)
    {
        this.langSocialsDbContext = langSocialsDbContext;
    }
    public async Task Add(Location location, CancellationToken cancellationToken = default)
    {
        await langSocialsDbContext.AddAsync(location, cancellationToken);
    }

    public async Task<Location?> Find(int id, CancellationToken cancellationToken)
    {
        return await langSocialsDbContext.Locations.FirstOrDefaultAsync(lc => lc.Id == id, cancellationToken);
    }

    public Task<bool> AlreadyExists(string nameFilter, string streetFilter, string numberFilter, string postalCodeFilter, CancellationToken cancellationToken = default)
    {
        return langSocialsDbContext.Locations.AnyAsync(l =>
            l.Name == nameFilter &&
            l.Street == streetFilter &&
            l.Number == numberFilter &&
            l.PostalCode == postalCodeFilter, cancellationToken);

    }

    public IEnumerable<Location> Search(string nameFilter, string? cityFilter = null, string? stateFilter = null)
    {
        IQueryable<Location> baseFilter = langSocialsDbContext.Locations;

        if (cityFilter is not null)
            baseFilter = baseFilter.Where(l => l.City == cityFilter);

        if (stateFilter is not null)
            baseFilter = baseFilter.Where(l => l.State == stateFilter);

        return baseFilter.Where(l => l.Name.Contains(nameFilter));
    }

    public void Update(Location location)
    {
        langSocialsDbContext.Update(location);
    }
}
