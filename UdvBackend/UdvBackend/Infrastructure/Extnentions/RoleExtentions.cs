using EduControl.DataBase.ModelBd;

namespace UdvBackend.Infrastructure.Extnentions;

public static class AccountExtensions
{
    public static bool IsHr(this Account account)
        => account.RoleId == Roles.HR.Id;

    public static bool IsEmployee(this Account account)
        => account.RoleId == Roles.Employee.Id;

    public static bool Exist(this Account? account)
        => account != null;

    public static string? GetRole(this Account account)
    {
        if (account.IsHr()) return Roles.HR.NameRole;
        if (account.IsEmployee()) return Roles.Employee.NameRole;

        return "у ";
    }
}