using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.Repositories.PlanetHistory;
using UdvBackend.Infrastructure.Repositories.PlanetInfo;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure;

public class PlanetWithNovelInitializer
{
    public async Task InitializeAsync(IPlanetInfoRepository planets, INovelPlanetRepository novels)
    {
        if ((await planets.GetAll()).Length != 0) return;

        var guid = Guid.NewGuid();
        var planetFood = CreatePlanet(guid, "шев", 3,
            "оххх, как же много еды нужно есть, что хорошо себя чувствовать!!", "Много есть полезно");
        await planets.Create(planetFood);
        var novelAboutFood = BigNovelAboutFoodComplete(guid);

        foreach (var novel in novelAboutFood)
        {
            await novels.Add(novel);
        }
       
        
    }


    private PlanetInfo CreatePlanet(Guid guid, string nameOctopus, int parts, string text, string title)
        => new()
        {
            Id = guid,
            Name = nameOctopus,
            Chapters = parts,
            Text = "оххх, как же много еды нужно есть, что хорошо себя чувствовать!!",
            Title = "Много есть полезно"
        };

    private Novel CreateNovelChapter(int chapter, Guid guid, string dialog, string interlocutor)
        =>
            new Novel()
            {
                Id = new Guid(),
                Chapter = chapter,
                Dialog = dialog,
                Interlocutor = interlocutor,
                IdPlanetInfo = guid
            };


    private List<Novel> StartNovel() //todo: вынести это потом в extension, будет типо констурктор историй)
    {
        var novelAboutFood = new List<Novel>();
        return novelAboutFood;
    }

    private List<Novel> BigNovelAboutFoodComplete(Guid guid)
    {
        var novelAboutFood = new List<Novel>();

        var chapterOne = CreateNovelChapter(2, guid, "Еда это прекрасно, чем больше ее, чем больше жизни", "Шеф");
        var chapterTwo = CreateNovelChapter(3, guid, "Сходи на 3 этаж найди там мой вкуные шоколадки", "Шеф");

        novelAboutFood.Add(chapterOne);
        novelAboutFood.Add(chapterTwo);
        return novelAboutFood;
    }
}
//todo  : sealed и подобные модификтаоры доступа
/*public static */