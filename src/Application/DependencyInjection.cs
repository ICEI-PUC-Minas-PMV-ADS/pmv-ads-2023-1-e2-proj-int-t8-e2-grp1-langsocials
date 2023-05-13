using Application.Common.Cryptography;
using Application.Common.MediatrExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UnhandledError>());

        services.AddScoped<ICryptographyService, CryptographyService>();

        return services;
    }
}
