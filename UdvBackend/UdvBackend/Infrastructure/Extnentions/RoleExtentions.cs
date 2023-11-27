using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Infrastructure.Extnentions;

public static class RoleExtensions
{
    public static bool IsHR(this Role role)
        => role.Name == Roles.HR;

    public static bool IsEmployee(this Role role)
        => role.Name == Roles.Employee;
}