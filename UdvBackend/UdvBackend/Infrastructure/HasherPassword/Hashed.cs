using System.Security.Cryptography;
using EduControl.DataBase.ModelBd;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace EduControl;

public static class Hasher
{
    private static readonly PasswordHasher<AccountIdentity> HasherPassword = new PasswordHasher<AccountIdentity>();
    
    public static string HashPassword(string name, string email, string password)
    {
        var accountIdentity = new AccountIdentity(name, email);
        return HasherPassword.HashPassword(accountIdentity, password);
    }

    public static PasswordVerificationResult VerifyPassword(Account account, string providePassword)
    {
        var accountIdentity = new AccountIdentity(account.Name, account.Email);
        return HasherPassword.VerifyHashedPassword(accountIdentity,account.PasswordHash, providePassword);
    }
}