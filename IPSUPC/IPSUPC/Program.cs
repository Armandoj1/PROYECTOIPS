using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Repositorio;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Servicio;
using IPSUPC.BE.Transversales.Image;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IPSUPC;

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddHealthChecks();
        builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 100_000_000;
        });

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Limits.MaxRequestBodySize = 100_000_000;
        });

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<IPSUPCDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
        builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();
        builder.Services.AddScoped<IUsuarioBLL, UsuarioBLL>();
        builder.Services.AddScoped<IPacientesDAL, PacientesDAL>();
        builder.Services.AddScoped<IPacientesBLL, PacientesBLL>();
        builder.Services.AddScoped<IMedicosDAL, MedicosDAL>();
        builder.Services.AddScoped<IMedicosBLL, MedicosBLL>();
        builder.Services.AddScoped<ICitasMedicasDAL, CitasMedicasDAL>();
        builder.Services.AddScoped<ICitasMedicasBLL, CitasMedicasBLL>();

        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
            });

        builder.Services.AddAuthorization();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "IPSUPC API", Version = "v1" });
        });

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseCors("CorsPolicy");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPSUPC API v1");
            c.RoutePrefix = "swagger";
        });

        app.MapControllers();
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            AllowCachingResponses = false,
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var response = new
                {
                    Status = report.Status.ToString(),
                    Time = DateTime.UtcNow
                };
                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        });

        await app.MigrateDbContext<IPSUPCDbContext>();
        await app.RunAsync();
    }
}