using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdvBackend.Domen.Entities;

[Table("novel", Schema = "udv_start")]
public class Novel
{
    [Key]
    [Column("id", Order = 0)]
    public Guid Id { get; set; }

    [Column("chapter", Order = 1)]
    public int Chapter { get; set; }

    [Column("dialog", Order = 2)]
    public string Dialog { get; set; }

    [Column("interlocutor", Order = 3)]
    public string Interlocutor { get; set; }

    [Column("id_planet_info", Order = 4)]
    public string IdPlanetInfo { get; set; }
}