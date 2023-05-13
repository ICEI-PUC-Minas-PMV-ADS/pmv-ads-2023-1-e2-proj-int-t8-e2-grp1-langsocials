using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface ISocialEventsRepository
{
    Task<IEnumerable<SocialEvent>> QuerySocialEvents(
        (double latitude, double longitude, double maxDistance)? locationFilter = default,
        bool orderByPopularity = false,
        int take = 20,
        CancellationToken cancellationToken = default
    );

}
