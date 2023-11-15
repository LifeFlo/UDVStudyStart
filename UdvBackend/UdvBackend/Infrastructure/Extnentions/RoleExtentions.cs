using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Infrastructure.Extnentions;

public static class RoleExtensions
{
    public static bool IsAdmin(this Role? role)
        => role.Name == Roles.Admin;
}