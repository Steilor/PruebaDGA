using ClnArq.Infrastructure.Extensions;
using ClnArq.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClnArq.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        // JwtSettings 
        builder.Services.Configure<JwtSettings>(
            builder.Configuration.GetSection("JwtSettings"));

        var jwtSettings = builder.Configuration
        .GetSection("JwtSettings")
        .Get<JwtSettings>()
           ?? throw new InvalidOperationException("Falta configurar Jwt en appsettings.json");



        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

            
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Ingrese 'Bearer {token}'",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securityScheme);

            // 2) Aplicamos globalmente ese esquema
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                [securityScheme] = Array.Empty<string>()
            });

        });

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhostVue",
                policy => policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });


        // JWT
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {

            var cfg = builder.Configuration.GetSection("JwtSettings");
            var key = cfg["Key"]
                ?? throw new InvalidOperationException("JwtSettings:Key no está configurado");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = cfg["Issuer"],
                ValidAudience = cfg["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key))
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = ctx =>
                {
                    Console.WriteLine("Error validando token: " + ctx.Exception.Message);
                    return Task.CompletedTask;
                }
            };
        });

        builder.Services.AddEndpointsApiExplorer();
    }
}
