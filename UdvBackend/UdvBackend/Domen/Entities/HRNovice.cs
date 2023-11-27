using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EduControl.DataBase.ModelBd;

namespace UdvBackend.Domen.Entities;

[Table("hr_employee", Schema = "udv_start")]
public class HREmployees
{
    [Column("id")] [Key] [Required] public Guid id { get; set; }
    [Column("hr_id")] [Required]public Guid HRId { get; set; }
    [Column("employee_id")] [Required] public Guid EmployeeId { get; set; }

    public static HREmployees From(Account hr, Account employee)
        => new()
        {
            EmployeeId = employee.Id,
            HRId = hr.Id,
            id = Guid.NewGuid()
        };
}