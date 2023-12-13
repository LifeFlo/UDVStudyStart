using System.ComponentModel.DataAnnotations;

namespace UdvBackend.Controllers.NoteController.model;

public class RequestTask
{
    [Required] public Guid AccountId { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Desc { get; set; }
    [Required] public DateTime Date { get; set; }
}