using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UdvBackend.Controllers.NoteController.model;

namespace UdvBackend.Domen.Entities;

[Table("task", Schema = "udv_start")]
public class Task
{
    [Column("id")] [Key] public Guid Id { get; set; }
    [Column("title")] [Required] public string Title { get; set; }
    [Column("description")] [Required] public string Desc { get; set; }
    [Column("user_id")] [ForeignKey("fk_user_id")][Required] public Guid UserId { get; set; }
    [Column("is_complete")] [Required] public bool IsComplete { get; set; }
    [Column("date")] [Required] public DateTime Date { get; set; }


    public static Task From(RequestTask requestTask)
    {
        return new Task()
        {
            Date = requestTask.Date,
            Desc = requestTask.Desc,
            Title = requestTask.Title,
            Id = Guid.NewGuid(),
            IsComplete = false,
            UserId = requestTask.userId
        };
    }
}