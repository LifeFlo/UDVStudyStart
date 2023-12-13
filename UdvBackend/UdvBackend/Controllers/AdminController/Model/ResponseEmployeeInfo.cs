using EduControl.DataBase.ModelBd;

namespace UdvBackend.Controllers.NoteController.model;

public class EmployeeInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Surname { get; set; } //todo: заменить на lastName
    public string? MiddleName { get; set; }
    public string Email { get; set; }
    public int CompleteStep { get; set; }
    public int TotalStep { get; set; }

    public static EmployeeInfo From(Account account, int completeStep, int totalStep)
        => new()
        {
            Id = account.Id,
            Name = account.Name,
            Surname = account.Surname,
            MiddleName = account.MiddleName,
            Email = account.Email,
            CompleteStep = completeStep,
            TotalStep = totalStep
        };
}