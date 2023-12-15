using System.ComponentModel.DataAnnotations;

namespace EduControl.Controllers.Model;

public class RequestGetToken
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}