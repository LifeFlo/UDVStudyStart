using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Infrastructure.Repositories.BaseInitializer;
using UdvBackend.Repositories;

namespace UdvBackend.Infrastructure;

public static class BaseInitializer
{
    public static RoleInitializers Role => new RoleInitializers();
    public static PlanetWithNovelInitializer Planet => new PlanetWithNovelInitializer();
} 




