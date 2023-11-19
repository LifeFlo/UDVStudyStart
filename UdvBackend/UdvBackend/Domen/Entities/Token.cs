using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.DataBase.ModelBd;
using EduControl.DataBase.ModelBd.Entities;

namespace EduControl.Controllers.Model;

[Table("token", Schema = "udv_start")]
public class Token
{
    [Column("value")] [Key] public string Value { get; set; }
    [Column("user_id")] public Guid UsedId { get; set; }
    [Column("create_dt")] public DateTime CreateDt { get; set; }

    public static Token From(string token, Account account)
        => new()
        {
            Value = token,
            CreateDt = DateTime.UtcNow,
            UsedId = account.Id,
        };
}