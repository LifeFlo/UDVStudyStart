namespace UdvBackend.Controllers.NoteController.model;

public class RequestChangeCompleteTask
{
    public Guid TaskId { get; set; }
    public  bool IsComplete { get; set; }
}