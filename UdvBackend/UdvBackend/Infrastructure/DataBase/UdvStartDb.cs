using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=UdvStart;Username=dev;Password=123123");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasMany<Task>().WithOne().HasConstraintName("fk_user_id").HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

    }
}