using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.DataBase.ModelBd;
using EduControl.DataBase.ModelBd.Entities;

namespace EduControl.Controllers.Model;

[Table("token", Schema = "udv_start")]
public class TokenInfo
{
    [Column("value")] [Key] public string Value { get; set; }
    [Column("account_id")] public Guid UsedId { get; set; }
    [Column("create_dt")] public DateTime CreateDt { get; set; }
    [Column("ttl")] public TimeSpan Ttl { get; set; }
    
    public static TokenInfo From(string token, Account account)
        => new()
        {
            Value = token,
            CreateDt = DateTime.UtcNow,
            UsedId = account.Id,
            Ttl = TimeSpan.FromHours(12)
        };
}