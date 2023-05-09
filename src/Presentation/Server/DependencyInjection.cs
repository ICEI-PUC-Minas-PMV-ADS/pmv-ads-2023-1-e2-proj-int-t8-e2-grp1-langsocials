using Application.Common.Services;
using LangSocials.Presentation.Server.Services;

namespace LangSocials.Presentation.Server;

public static class DependencyInjection
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        Infraesctructure.LocationSearch.DependencyInjection.AddGooglePlacesAPILocationSearchRepository(builder.Services,
            builder => builder.Configure(opt => { opt.BaseAddress = "https://maps.googleapis.com/maps/api/"; opt.ApiKey = "🐀SEM CHAVE DE API ATÉ PRA PRODUCAO🐀"; })
        );
        Infraesctructure.DependencyInjection.AddInfraesctructure(builder.Services);
        Application.DependencyInjection.AddApplication(builder.Services);
        builder.Services.AddScoped<IUserInfo, UserId>();
    }
}
