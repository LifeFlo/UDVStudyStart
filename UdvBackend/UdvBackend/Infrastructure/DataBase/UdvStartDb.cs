using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure;
using Vostok.Logging.Abstractions;
using Task = UdvBackend.Domen.Entities.Task;

namespace EduControl.DataBase;

public class UdvStartDb : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Role> Roles { get; set; } 
    public DbSet<PlanetInfo> PlanetInfos { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<HREmployees> LinkHrEmployees { get; set; }
    public readonly ILog Log;

    public UdvStartDb(ILog log)
    {
        Log = log;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Log.Info(AppSettings.GetHostDataBase());
        optionsBuilder.UseNpgsql($"Host={AppSettings.GetHostDataBase()};Port=5432;Database=verceldb;Username=default;Password=KBfN7eg4qUrW");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
}