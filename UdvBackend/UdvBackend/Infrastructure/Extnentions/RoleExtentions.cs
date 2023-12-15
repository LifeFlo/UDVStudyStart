using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Infrastructure.Extnentions;

public static class AccountExtensions
{
    public static bool IsHR(this Account account)
        => account.RoleId == Roles.HR.Id;

    public static bool IsEmployee(this Account account)
        => account.RoleId == Roles.Employee.Id;

    public static bool Exist(this Account? account)
        => account != null;
}