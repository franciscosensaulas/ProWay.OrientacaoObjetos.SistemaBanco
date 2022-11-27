using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using Proway.Projeto00.API.Filters;
using Proway.Projeto00.API.Middlewares;
using Repository.Database;
using Repository.DependencyInjection;
using Service.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Host.ConfigureLogging(x =>
//{
//    x.ClearProviders();
//    x.AddNLog();
//});


builder.Services
    .AddScoped<AuthenticatedFilter>()
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddProjectSession()
    .AddAutoMapper()
    .AddFluentValidationProjeto()
    .AddSqlServerDataBase(builder.Configuration)
    .AddRespository()
    .AddService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();


using (var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider.GetService<ProjetoContext>();
    contexto.Database.Migrate();
}

app.UseSession();

app.Run();
