using Application.Common.Token;
using LangSocials.Presentation.Server.Services.Token;
using System.Text;
using Application.Common.Services;
using LangSocials.Presentation.Server.Services;

namespace LangSocials.Presentation.Server;

public static class DependencyInjection
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        Infraesctructure.LocationSearch.DependencyInjection.AddGooglePlacesAPILocationSearchRepository(builder.Services,
            builder => builder.Configure(opt => { opt.BaseAddress = "https://maps.googleapis.com/maps/api/"; opt.ApiKey = "🐀"; })
        );
        Infraesctructure.DependencyInjection.AddInfraesctructure(builder.Services);
        Application.DependencyInjection.AddApplication(builder.Services);
        
        builder.Services.Configure<TokenServiceOption>(opt => opt.TokenKey = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("LANGSOCIALS__TOKEN_KEY") ?? throw new ArgumentNullException("LANGSOCIALS__TOKEN_KEY")));

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserInfo, HttpContextUserInfo>();
    }
}
