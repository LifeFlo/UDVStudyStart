using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using FakeItEasy;
using FluentAssertions;
using UdvBackend.Controllers.NoteController;
using UdvBackend.Controllers.NoteController.model;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Infrastructure.Repositories.Note;
using Vostok.Logging.Abstractions;

namespace Tests;

public class TestsHrCicle
{
    private AccountScope _accountScope;
    private ITaskRepository _tasks;
    private ILinkEmployeesHr _linkHrEmployee;
    private ILog _log;

    [SetUp]
    public void Setup()
    {
        _tasks = A.Fake<ITaskRepository>();
        _linkHrEmployee = A.Fake<ILinkEmployeesHr>();
        _log = A.Fake<ILog>();
        _accountScope = new AccountScope() {Account = new Account() {Id = Guid.NewGuid()}};
    }

    [Test]
    public async Task GoodCreateTask()
    {
        var id = Guid.NewGuid();
        
        var request = new RequestTask()
        {
            Date = DateTime.UtcNow,
            Desc = "пойди домой отдохни",
            Title = "у тебя вид как у кринжового чела",
            AccountId = id
        };

        var accounts = new List<Account>().AddKiril().AddWithCustomId(id);
        A.CallTo(() => _linkHrEmployee.GetEmployees(A<Guid>.Ignored))
            .Returns(accounts);
        var taskController = new TaskController(_tasks, _log, _accountScope, _linkHrEmployee);
        var task = await taskController.CreateTask(request);

        
        task.Value!.AssertWith(request);
    }
    
    
    
    
    
    
    
    
}