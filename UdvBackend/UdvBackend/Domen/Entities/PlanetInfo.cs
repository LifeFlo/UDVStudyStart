using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdvBackend.Domen.Entities;

[Table("planet_info", Schema = "udv_start")]
public class PlanetInfo
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("chapters")] public int Parts { get; set; } 
    [Column("title")] public string Title { get; set; }
    [Column("text")] public string Text { get; set; }
}