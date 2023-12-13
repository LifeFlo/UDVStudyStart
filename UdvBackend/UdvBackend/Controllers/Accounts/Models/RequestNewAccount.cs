namespace EduControl.Controllers.Model;

public class RequestNewHr
{
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

