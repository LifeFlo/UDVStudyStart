using FluentAssertions;
using UdvBackend.Controllers.NoteController.model;
using Task = UdvBackend.Domen.Entities.Task;

namespace Tests;

public static class ExtensionTask
{
    public static void AssertWith(this Task task, RequestTask request)
    {
        task.Desc.Should().Be(request.Desc);
        task.Title.Should().Be(request.Title);
        task.IsComplete.Should().Be(false);
        task.AccountId.Should().Be(request.AccountId);
    }
}