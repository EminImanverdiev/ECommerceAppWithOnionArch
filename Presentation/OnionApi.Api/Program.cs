using OnionApi.Persistance;
using OnionApi.Application;
using OnionApi.Infrastructure;
using OnionApi.Mapper;
using OnionApi.Application.Exceptions;

namespace OnionApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var env = builder.Environment;
            builder.Configuration
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistance(builder.Configuration);
            builder.Services.AddCustomMapper();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.ConfigureExceptionHandlingMiddleware();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}