using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Infrastructure.Extnentions;

public static class AccountExtensions
{
   
    public static bool Exist(this Account? account)
        => account != null;
    
    public static bool IsHr(this AccountInfo accountInfo)
        => accountInfo.Roles.Contains(Roles.Hr);

    public static bool IsEmployee(this AccountInfo accountInfo)
        => accountInfo.Roles.Contains(Roles.Employee);
  
}
