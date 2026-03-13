using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using System.ComponentModel;
 
namespace EventPlus.WebAPI;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        // 1.Configurar contexto do banco de dados
        builder.Services.AddDbContext<EventContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // 2.Configurar o repositório para injeção de dependência
        builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
        builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
        builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
        builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();

        //Add Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Api de eventos",
                Description = "Aplicação para gerencimento de eventos",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Supernova",
                    Url = new Uri("https://youtu.be/XlL6YhYUaAs?si=4pp-XQdrkJKAVYBz"),
                },
                License = new OpenApiLicense
                {
                    Name = "Youtube",
                    Url = new Uri("https://youtu.be/mKzaUbiFQ68?si=1jd7cF2PlCGo5ANY"),
                },

            });

            //Usando autentificação no Swagger
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT"
            });
            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()

            });
        });


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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}