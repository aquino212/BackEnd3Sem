using Azure.AI.ContentSafety;
using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

using System.Text;

namespace EventPlus.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer
         (builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
        builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
        builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IEventoRepository, EventoRepository>();
        builder.Services.AddScoped<IComentarioEventoRepository, ComentarioEventoRepository>();
        builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();


        //Configuração do Azure Content Safety
        var endopoint = "#";
        var apikey = "#";

        var client = new ContentSafetyClient(new Uri(endopoint), new Azure.AzureKeyCredential(apikey));
        builder.Services.AddSingleton(client); 

        builder.Services.AddEndpointsApiExplorer();

        // O seu Swagger original - intacto!
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Api de Eventos",
                Description = "Aplicação para gerenciamento de eventos",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Arthurbr-YT",
                    Url = new Uri("https://www.youtube.com/@Arthurbr-YT"),
                },
                License = new OpenApiLicense
                {
                    Name = "Licença de Uso",
                    Url = new Uri("https://example.com/license"),
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT:"
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<String>().ToList()
            });
        });

        // Configuração da Autenticação JWT
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        })
        .AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "EventPlus.WebAPI",
                ValidAudience = "EventPlus.WebAPI",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-dev"))
            };
        });

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

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
    }
}