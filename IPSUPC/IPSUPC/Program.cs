using IPSUPC.BE.Infraestructure.Persintence;
using IPSUPC.BE.Repositorio.Interface;
using IPSUPC.BE.Repositorio;
using IPSUPC.BE.Servicio.Interface;
using IPSUPC.BE.Servicio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// User Secrets solo en desarrollo
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Serialización JSON
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Carga de archivos grandes
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 100_000_000; // 100 MB
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 100_000_000; // 100 MB
});

// DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IPSUPCDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.EnableRetryOnFailure()));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Inyección de dependencias
builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();
builder.Services.AddScoped<IUsuarioBLL, UsuarioBLL>();
builder.Services.AddScoped<IPacientesDAL, PacientesDAL>();
builder.Services.AddScoped<IPacientesBLL, PacientesBLL>();
builder.Services.AddScoped<IMedicosDAL, MedicosDAL>();
builder.Services.AddScoped<IMedicosBLL, MedicosBLL>();



// JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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

// Swagger + JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IPSUPC API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingresa el token JWT con el prefijo Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controladores -> Este es para el horario medico, revisar después
builder.Services.AddControllers();
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
//    });



var app = builder.Build();

// Migraciones automáticas
await app.MigrateDbContext<IPSUPCDbContext>();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (!Directory.Exists("publish"))
{
    Directory.CreateDirectory("publish");
}

using (var scope = app.Services.CreateScope())
{
    var swaggerProvider = scope.ServiceProvider.GetRequiredService<Swashbuckle.AspNetCore.Swagger.ISwaggerProvider>();
    var swagger = swaggerProvider.GetSwagger("v1");

    using var fileStream = File.Create("publish/swagger.json");
    await System.Text.Json.JsonSerializer.SerializeAsync(fileStream, swagger, new System.Text.Json.JsonSerializerOptions
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    });

    Console.WriteLine("✅ Archivo swagger.json generado correctamente en la carpeta publish");
}


await app.RunAsync();
