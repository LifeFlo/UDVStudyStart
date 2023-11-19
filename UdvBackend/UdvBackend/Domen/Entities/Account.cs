using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using UdvBackend.DataBase.Entities.Account;

namespace EduControl.DataBase.ModelBd;

[Table("account", Schema = "udv_start")]
public class Account : IEntity<Guid>
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string? Surname { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password_hash")] public string PasswordHash { get; set; }
    [Column("role_id")] public Guid RoleId { get; set; }

    public static Account From(RequestNewAccount entity, Role role)
        => new()
        {
            Email = entity.Email,
            PasswordHash = Hasher.HashPassword(entity.Name, entity.Email, entity.Password),
            Name = entity.Name,
            Id = Guid.NewGuid(),
            RoleId = role.Id
        };

    public bool IsMy(IUserLink entity)
        => entity.UserId == Id;
}