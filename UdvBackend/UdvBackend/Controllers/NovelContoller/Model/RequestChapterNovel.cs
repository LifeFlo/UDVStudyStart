using UdvBackend.Domen.Entities;

namespace UdvBackend.Controllers.Planets.Model;

public class RequestChapterNovel
{
    public string Dialog { get; set; }
    public string Interlocutor { get; set; }

    public static RequestChapterNovel From(Novel novel)
        => new RequestChapterNovel()
        {
            Dialog = novel.Dialog,
            Interlocutor = novel.Interlocutor
        };
}