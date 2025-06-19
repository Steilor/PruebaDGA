using ClnArq.API.Extensions;
using ClnArq.Application.Extensions;
using ClnArq.Infrastructure.Extensions;
using ClnArq.Infrastructure.Identity;
using ClnArq.Infrastructure.Seeders;
namespace ClnArq.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddPresentation();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();

            //Agregar el Seeder
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IClnArqSeeder>();

             await seeder.Seed();

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
