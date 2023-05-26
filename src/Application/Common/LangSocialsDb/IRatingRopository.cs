using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface IRatingRopository
{
    Task Create(Rating rating, CancellationToken cancellation);
    Task<IEnumerable<Rating>> Find(int LocationId,CancellationToken cancellation);
}
