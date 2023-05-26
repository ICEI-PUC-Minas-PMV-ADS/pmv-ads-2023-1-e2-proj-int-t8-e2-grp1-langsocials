using Application.Common.LangSocialsDb;
using LangSocials.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LangSocials.Infraesctructure.LangSocialsDb.Repository;

public class RatingRepository : IRatingRopository
{
    private readonly LangSocialsDbContext context;

    public RatingRepository(LangSocialsDbContext context)
    {
        this.context = context;
    }

    public async Task Create(Rating rating, CancellationToken cancellation)
    {
        await context.AddAsync(rating, cancellation);
    }

    public async Task<IEnumerable<Rating>> Find(int LocationId, CancellationToken cancellation)
    {
        return (await context.Locations.Include(l => l.Ratings).FirstOrDefaultAsync(rt => rt.Id == LocationId, cancellation))?.Ratings ?? Enumerable.Empty<Rating>();
    }
}
