using System.Threading.RateLimiting;
using EduControl.DataBase;
using EduControl.MiddleWare;
using EduControl.Repositories;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.OpenApi.Models;
using UdvBackend.Infrastructure.AccountService;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Infrastructure.Repositories.Note;
using UdvBackend.Infrastructure.Repositories.PlanetHistory;
using UdvBackend.Infrastructure.Repositories.PlanetInfo;
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
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "token",
        In = ParameterLocation.Header,
        Description =
            "bearer токен",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<ILinkEmployeesHr, LinkHREmployees>();
builder.Services.AddSingleton<ILInkHrEmpe, LinkHREmployees>(); // todo: как тебе два интерфейса на один класс.
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IPlanetInfoRepository, PlanetInfoRepository>();
builder.Services.AddSingleton<INovelPlanetRepository, NovelPlanetRepository>();
builder.Services.AddScoped<AccountScope>();
builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<UdvStartDb>(); // todo: как временное решение 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
            policy.AllowAnyHeader();
            policy.AllowCredentials();
            policy.AllowAnyMethod();
            policy.SetIsOriginAllowed(hostName => true);
        });
});


var app = builder.Build();

await app.AddBaseRoles();
await app.AddBaseHistory();


app.UseCors(MyAllowSpecificOrigins);

app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/account"), c =>
{
    c.UseMiddleware<MiddleWareCheckTokenHeader>();
    c.UseCors(MyAllowSpecificOrigins);
});

app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/hr"), c =>
{
    c.UseCors(MyAllowSpecificOrigins);
    c.UseMiddleware<MiddleWareCheckTokenHeader>();
    c.UseMiddleware<MiddleWareIsHr>();
});

app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/employee"), c =>
{
    c.UseCors(MyAllowSpecificOrigins);
    c.UseMiddleware<MiddleWareCheckTokenHeader>();
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

app.UseCookiePolicy(new CookiePolicyOptions()
{
    HttpOnly = HttpOnlyPolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Lax
});



app.Run();