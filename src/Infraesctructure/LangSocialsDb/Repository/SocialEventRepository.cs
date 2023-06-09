using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb.Repository;

public class SocialEventRepository : ISocialEventsRepository
{
    private readonly LangSocialsDbContext context;

    public SocialEventRepository(LangSocialsDbContext context)
    {
        this.context = context;
    }

    public Task<SocialEvent?> QueryById(uint id, CancellationToken cancellationToken = default)
    {
        return context.SocialEvents.Include(se => se.Tags).FirstOrDefaultAsync(se => se.Id == id, cancellationToken);
    }

    public Task<List<SocialEvent>> QuerySocialEvents(string? cityFilter = null, string? stateFilter = null, bool orderByPopularity = false, int take = 20, CancellationToken cancellationToken = default)
    {
        IQueryable<Location> locationQuery = context.Locations.Include(l => l.SocialEvents);

        if (cityFilter != default)
            locationQuery = locationQuery.Where(l => l.City == cityFilter);

        if (stateFilter != default)
            locationQuery = locationQuery.Where(l => l.State == stateFilter);

        if (orderByPopularity)
            locationQuery = locationQuery.OrderByDescending(l => l.RatingAvarage);

        var socialEventsProjection = locationQuery.SelectMany(l => l.SocialEvents);

        return socialEventsProjection.ToListAsync(cancellationToken);
    }
}
