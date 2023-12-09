using System.Threading.RateLimiting;
using EduControl.DataBase;
using EduControl.MiddleWare;
using EduControl.Repositories;
using UdvBackend.Infrastructure.AccountService;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Infrastructure.Repositories.Note;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Console;
using Vostok.Logging.Microsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var log = new ConsoleLog(new ConsoleLogSettings()
{
    ColorsEnabled = true
});
builder.Logging.ClearProviders();
builder.Logging.AddVostok(log);
builder.Services.AddSingleton<ILog>(log);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<ILinkEmployeesHr, LinkHREmployees>();
builder.Services.AddSingleton<ILInkHrEmpe, LinkHREmployees>(); // todo: как тебе такие махинаций
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddScoped<AccountScope>();
builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddDbContext<UdvStartDb>();

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://example.com",
                "http://www.contoso.com");
        });
});

var app = builder.Build();
await app.AddBaseRoles();




app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/account"), c =>
{
    c.UseMiddleware<MiddleWareCheckToken>();
});

app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/hr"), c =>
{
    c.UseMiddleware<MiddleWareCheckToken>();
    c.UseMiddleware<MiddleWareIsAdmin>();
});

app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/employee"), c =>
{
    c.UseMiddleware<MiddleWareCheckToken>();
    c.UseMiddleware<MiddleWareIsEmployee>();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


app.UseCors(_ =>
{
    _.WithOrigins("http://localhost:3000");
    _.AllowAnyOrigin();
    _.AllowAnyHeader();
    _.AllowAnyMethod();
});


app.Run();