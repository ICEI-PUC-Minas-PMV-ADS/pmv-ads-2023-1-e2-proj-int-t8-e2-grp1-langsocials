using LangSocials.Domain.Entities;

namespace Application.Common.LangSocialsDb;

public interface ISocialEventsRepository
{
    Task<List<SocialEvent>> QuerySocialEvents(
        string? cityFilter = default,
        string? stateFilter = default,
        bool orderByPopularity = false,
        int take = 20,
        CancellationToken cancellationToken = default
    );

    Task<SocialEvent?> QueryById(uint id, CancellationToken cancellationToken = default);
}
