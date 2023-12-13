using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdvBackend.Domen.Entities;

[Table("planet_info", Schema = "udv_start")]
public class PlanetInfo
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("title")] public Guid Title { get; set; }
    [Column("text")] public Guid Text { get; set; }
}