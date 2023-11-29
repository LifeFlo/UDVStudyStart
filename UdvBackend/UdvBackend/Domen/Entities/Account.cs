using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PasswordGenerator;
using UdvBackend.Controllers.AdminController.Model;
using UdvBackend.DataBase.Entities.Account;

namespace EduControl.DataBase.ModelBd;

[Table("account", Schema = "udv_start")]
public record Account : IEntity<Guid>
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string? Surname { get; set; }
    [Column("middle_name")] public string? MiddleName { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password_hash")] public string PasswordHash { get; set; }
    [Column("role_id")] public Guid RoleId { get; set; }

    public static Account From(RequestNewHr entity, Role role)
        => new()
        {
            Email = entity.Email,
            PasswordHash = Hasher.HashPassword(entity.Name, entity.Email, entity.Password),
            Name = entity.Name,
            Id = Guid.NewGuid(),
            RoleId = role.Id
        };
    
    public static Account From(RequestNewEmployee entity, Role role, string password)
        => new()
        {
            Email = entity.Email,
            PasswordHash = Hasher.HashPassword(entity.Name, entity.Email, password),
            Name = entity.Name,
            Id = Guid.NewGuid(),
            RoleId = role.Id,
            MiddleName = entity.MiddleName,
            Surname = entity.Surname
        };
}