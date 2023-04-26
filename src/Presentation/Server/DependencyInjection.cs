namespace LangSocials.Presentation.Server;

public static class DependencyInjection
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        Infraesctructure.DependencyInjection.AddInfraesctructure(builder.Services);
    }
}
