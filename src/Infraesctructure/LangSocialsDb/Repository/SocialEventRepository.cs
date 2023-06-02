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
        return context.SocialEvents.Include(se => se.Tags).SingleOrDefaultAsync(se => se.Id == id);
    }

    public Task<IEnumerable<SocialEvent>> QuerySocialEvents(string? cityFilter = null, string? stateFilter = null, bool orderByPopularity = false, int take = 20, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
