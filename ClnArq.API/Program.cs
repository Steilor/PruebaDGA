using ClnArq.Infrastructure.Extensions;
using ClnArq.Application.Extensions;
using ClnArq.Infrastructure.Persistence;
using ClnArq.Infrastructure.Identity;
namespace ClnArq.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {

            }
            );

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhostVue",
                    policy => policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
 

            var app = builder.Build();

            app.UseCors("AllowLocalhostVue");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGroup("api/identity").MapIdentityApi<ApplicationUser>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
