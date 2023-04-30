using Microsoft.Extensions.DependencyInjection;
using Application.Common.Repository.LocationSearch;
using Microsoft.Extensions.Options;

namespace LangSocials.Infraesctructure.LocationSearch;

public static class DependencyInjection
{
    public static void AddGooglePlacesAPILocationSearchRepository(IServiceCollection services, Action<OptionsBuilder<GooglePlacesAPIOptions>> configureAction)
    {
        services
            .AddHttpClient<ILocationSearchRepository, GooglePlacesAPILocationSearchRepository>
            (
                (sp, httpClient) =>
                {
                    var options = sp.GetRequiredService<IOptions<GooglePlacesAPIOptions>>().Value;

                    httpClient.BaseAddress = new Uri(options.BaseAddress);
                }
            )
            .AddHttpMessageHandler<GooglePlacesAPIAuthorizationMessageHandler>();

        services.AddSingleton<GooglePlacesAPIAuthorizationMessageHandler>();

        configureAction(services.AddOptions<GooglePlacesAPIOptions>());
    }
}
