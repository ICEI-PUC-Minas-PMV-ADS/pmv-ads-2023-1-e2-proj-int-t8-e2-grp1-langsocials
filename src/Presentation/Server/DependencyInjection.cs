using Application.Common.Token;
using LangSocials.Presentation.Server.Services.Token;
using System.Text;
using Application.Common.Services;
using LangSocials.Presentation.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace LangSocials.Presentation.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthScheme(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            c =>
            {
                c.AddSecurityDefinition(
                    "token",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer",
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "token"
                                },
                            },
                            Array.Empty<string>()
                        }
                    }
                );
            }
        );

        return services;
    }

    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        Infraesctructure.DependencyInjection.AddInfraesctructure(builder.Services);
        Application.DependencyInjection.AddApplication(builder.Services);

        builder.Services.AddAuthScheme();

        var key = Encoding.UTF8.GetBytes("savechagneslangsocialskey");

        builder.Services.Configure<TokenServiceOption>(opt => opt.TokenKey = key);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        builder.Services.AddAuthorization();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserInfo, HttpContextUserInfo>();
    }
}
