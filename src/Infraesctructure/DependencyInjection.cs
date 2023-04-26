using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LangSocials.Infraesctructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraesctructure(this IServiceCollection services)
    {
        services.AddDbContext<LangSocialsDbContext>(cfg =>
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "Test.db",
                Cache = SqliteCacheMode.Shared
            };
            var sqliteConnection = new SqliteConnection(connectionStringBuilder.ToString());
            sqliteConnection.Open();
            cfg.UseSqlite(sqliteConnection);
        });

        return services;
    }
}
