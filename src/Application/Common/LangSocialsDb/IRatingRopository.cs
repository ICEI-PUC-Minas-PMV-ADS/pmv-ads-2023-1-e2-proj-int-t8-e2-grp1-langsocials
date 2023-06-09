using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface IRatingRopository
{
    Task<IEnumerable<Rating>> Find(int LocationId,CancellationToken cancellation);
}
