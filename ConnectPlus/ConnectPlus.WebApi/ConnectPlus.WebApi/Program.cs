using ConnectPlus.WebApi.DBContextConnect;
using ConnectPlus.WebApi.Interfaces;
using ConnectPlus.WebApi.Models;
using ConnectPlus.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;

//Controller
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext 
builder.Services.AddDbContext<ConnectContext>(options =>options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus;Trusted_Connection=True;"));

//Injeção de dependência
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
