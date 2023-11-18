using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.DataBase.ModelBd.Entities;

namespace UdvBackend.DataBase.Entities.Account;

[Table("role", Schema = "udv_start")]
public class Role: IEntity<Guid>
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }

    public static Role From(string role)
    {
        return new Role
        {
            Name = role,
            Id = Guid.NewGuid()
        };
    }
}