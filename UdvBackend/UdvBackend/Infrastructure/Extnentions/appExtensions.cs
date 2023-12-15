using UdvBackend.Infrastructure.Repositories.PlanetHistory;
using UdvBackend.Infrastructure.Repositories.PlanetInfo;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Infrastructure.Extnentions;

public static class StartDataExtensions // всю эту фигню можно сделать с рефлекцей с сборкой как в tgBot))
{
    public static async Task AddBaseRoles(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var roles = services.GetService<IRoleRepository>();
            var accounts = services.GetService<IAccountRepository>();
            await BaseInitializer.Role.InitializeAsync(roles, accounts);
        }
        catch (Exception e)
        {
            var log = services.GetService<ILog>();
            log.Error($"An error occurred while seeding the database. {e}");
        }
    }

    public static async Task AddBaseHistory(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var planets = services.GetService<IPlanetInfoRepository>();
            var novels = services.GetService<IPlanetNovelRepository>();
            BaseInitializer.Planet.InitializeAsync(planets, novels);
        }
        catch (Exception e)
        {
            var log = services.GetService<ILog>();
            log.Error($"An error occurred while seeding the database. {e}");
        }
    }
}