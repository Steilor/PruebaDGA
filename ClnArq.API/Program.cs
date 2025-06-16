using ClnArq.Infrastructure.Extensions;
using ClnArq.Application.Extensions;
namespace ClnArq.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // 1) Infrastructure (DbContext + Repositorios)
            builder.Services.AddInfrastructure(builder.Configuration);

            // 2) Application (AutoMapper, validaciones, etc.)
            builder.Services.AddApplication();

            builder.Services.AddControllers();

            // 4) Swagger / OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
