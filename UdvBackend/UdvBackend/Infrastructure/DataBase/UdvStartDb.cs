using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.DataBase.Entities.Account;

namespace EduControl.DataBase;

public class UdvStartDb : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Role> Roles { get; set; } 
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=UdvStart;Username=dev;Password=123123");
    }
}