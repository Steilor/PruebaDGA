using ClnArq.Infrastructure.Extensions;
using ClnArq.Application.Extensions;
using ClnArq.Infrastructure.Persistence;
using ClnArq.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using ClnArq.API.Extensions;
namespace ClnArq.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddPresentation();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();

            app.UseCors("AllowLocalhostVue");

            // HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //1-autenticación 2-autorización
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapGroup("api/identity")
                .MapIdentityApi<ApplicationUser>();

            app.MapControllers();

            app.Run();
        }
    }
}
