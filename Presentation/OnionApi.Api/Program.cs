using OnionApi.Persistance;
using OnionApi.Application;
using OnionApi.Infrastructure;
using OnionApi.Mapper;
using OnionApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            var env = builder.Environment;
            builder.Configuration
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistance(builder.Configuration);
            builder.Services.AddCustomMapper();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            builder.Services.AddSwaggerGen(c =>
            {
            c.SwaggerDoc("v1",new OpenApiInfo{ Title="Onion Arch",Version="v1",Description= "Onion Arch swagger client." });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
             {
                    Name = "Authorization",
                    Type=SecuritySchemeType.ApiKey,
                    Scheme= "Bearer",
                    BearerFormat="JWT",
                    In=ParameterLocation.Header,
                    Description=@"Bearer' yazib bosluq qoydugdan sonra Token'i daxil ede bilersninz \n Meselen"
             });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }

                }) ;
            
            });
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