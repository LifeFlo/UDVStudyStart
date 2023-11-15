using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Infrastructure.Extnentions;

public static class AppExtensions
{
    public static async Task AddBaseRoles(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var roles = services.GetService<IRoleRepository>();
            var accounts = services.GetService<IAccountRepository>();
            await RoleInitializer.InitializeAsync(roles, accounts);
        }
        catch (Exception e)
        {
            var log = services.GetService<ILog>();
            log.Error($"An error occurred while seeding the database. {e}");
        }
    }
}