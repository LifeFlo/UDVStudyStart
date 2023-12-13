namespace UdvBackend.Controllers.NoteController.model;

public class RequestTask
{
    public Guid userId { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public DateTime Date { get; set; }
}