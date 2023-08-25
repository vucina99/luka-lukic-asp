using Application.Logging;
using DataAccess.DAL;
using Domain;
using Implementation.Logging;
using Implementation.UseCases;
using Microsoft.OpenApi.Models;
using Presentation.PL.Auth;
using Presentation.PL.Extensions;
using Presentation.PL.Middleware.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(settings);

builder.Services.AddJwt(settings);
builder.Services.AddHttpContextAccessor();
builder.Services.AddUseCases();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<IUseCaseLogger, EFUseCaseLogger>();
builder.Services.AddUser();
builder.Services.AddValidators();
builder.Services.AddTransient<FilmContext>();
builder.Services.AddTransient<UseCaseHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
//app.UseRouting();
app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
