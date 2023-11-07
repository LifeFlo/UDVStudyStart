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
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=UdvStart;Username=Dev;Password=123123");
    }
}