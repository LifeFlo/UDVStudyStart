using EduControl;
using EduControl.DataBase.ModelBd;
using PasswordGenerator;

namespace Tests;

public static class ExtensionAccounts
{
    public static List<Account> AddKiril(this List<Account> accounts)
    {
        var account = new Account()
        {
            Email = "Kiril@udv.group",
            Id = new Guid("6002f657-0439-44e1-9370-3f45d3620a5a"),
            PasswordHash = Hasher.HashPassword("kiril", "Kiril@udv.group", "kiril123"),
            MiddleName = "alex",
            Surname = "Morozov",
            RoleId = Role.Employee,
            Name = "kiril"
        };
        accounts.Add(account);

        return accounts;
    }

    public static List<Account> AddRandom(this List<Account> accounts)
    {
        var account = new Account()
        {
            Email = Faker.Internet.Email(),
            RoleId = Role.Employee,
            Name = Faker.Name.First(),
            MiddleName = Faker.Name.Middle(),
            PasswordHash = "asdfasdgasdf",
            Id = new Guid(),
            Surname = Faker.Name.Last()
        };
        
        accounts.Add(account);

        return accounts;
    }
    public static List<Account> AddWithCustomId(this List<Account> accounts, Guid guid)
    {
        var account = new Account()
        {
            Email = Faker.Internet.Email(),
            RoleId = Role.Employee,
            Name = Faker.Name.First(),
            MiddleName = Faker.Name.Middle(),
            PasswordHash = "asdlkfjas;ldkfj",
            Id = guid,
            Surname = Faker.Name.Last()
        };
        
        accounts.Add(account);

        return accounts;
    }
}