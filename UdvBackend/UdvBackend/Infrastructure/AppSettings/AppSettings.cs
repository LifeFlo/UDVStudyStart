using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace UdvBackend.Infrastructure;

public static class AppSettings
{
    public static string GetHostDataBase()
    {
        var usinghost = Environment.GetEnvironmentVariable(NameVariables.HostDataBase);
        if (usinghost == null)
        {
            throw new Exception("В среде не определён хост для базы данных");
        }
        Console.WriteLine(usinghost);
        return usinghost;
    }
}