using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;

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
}
