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
}
