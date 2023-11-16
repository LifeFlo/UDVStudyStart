using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdvBackend.DataBase.Entities.Account;

[Table("role", Schema = "udv_start")]
public class Role
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }

    public static Role? From(string role)
    {
        return new Role
        {
            Name = role,
            Id = Guid.NewGuid()
        };
    }
}