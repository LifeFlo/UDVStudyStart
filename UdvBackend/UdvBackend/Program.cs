using System.Threading.RateLimiting;
using EduControl.DataBase;
using EduControl.MiddleWare;
using EduControl.Repositories;
using UdvBackend.Infrastructure.Extnentions;
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
builder.Services.AddSingleton<ITokenRepository, TokenRepository>(); 
builder.Services.AddScoped<AccountScope>();
builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddSingleton<UdvStartDb>();
var app = builder.Build();

await app.AddBaseRoles();

app.UseCors(_ =>
{
    _.AllowAnyOrigin();
    _.AllowAnyHeader();
});


app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/admin"), c =>
{
    c.UseMiddleware<MiddleWareCheckToken>();
    c.UseMiddleware<MiddleWareIsAdmin>();
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

app.Run();