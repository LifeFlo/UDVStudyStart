using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Domen.Entities;
using Vostok.Logging.Abstractions;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;

public class LinkHREmployees : ILinkEmployeesHr, ILInkHrEmpe
{
    private readonly UdvStartDb _db;
    private readonly ILog _log;
    public LinkHREmployees(UdvStartDb db, ILog log)
    {
        _db = db;
        _log = log;
    }

    public async Task<List<Account>> GetEmployees(Guid hrId)
    {
        return await _db.Accounts.FromSql($"Select * From udv_start.account WHERE account.id IN (Select employee_id FROM udv_start.hr_employee where hr_employee.hr_id = {hrId})").ToListAsync();
    }

    public async Task Connect(HREmployees hrEmployees)
    {
        await _db.LinkHrEmployees.AddAsync(hrEmployees);
        await _db.SaveChangesAsync();
    }
}