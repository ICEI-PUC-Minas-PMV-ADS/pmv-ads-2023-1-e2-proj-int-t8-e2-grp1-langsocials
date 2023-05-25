using Application.Common.Cryptography;
using Application.Common.MediatrExtensions;
using Application.Common.Services.Files;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UnhandledError>());

        services.AddScoped<ICryptographyService, CryptographyService>();
        services.AddScoped<IFileService, FileService>();

        return services;
    }
}
