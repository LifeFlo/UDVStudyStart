    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.Controllers.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using UdvBackend.DataBase.Entities.Account;

namespace EduControl.DataBase.ModelBd;

[Table("account", Schema = "UdvStart")]
public class Account
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("user_name")] public string UserName { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password_hash")] public string PasswordHash { get; set; }
    [Column("role_id")] public Guid RoleId { get; set; }
    
    public static Account From(RequestNewAccount entity, Role role)
        => new()
        {
            Email = entity.Email,
            PasswordHash = Hasher.Password(entity.Password),
            UserName = entity.UserName,
            Id = Guid.NewGuid(),
            RoleId = role.Id
        };

    public bool IsMy(IUserLink entity)
        => entity.UserId == Id;
}