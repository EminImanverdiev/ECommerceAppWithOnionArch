using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApi.Application.Interfaces.Repositories;
using OnionApi.Persistance.Context;
using OnionApi.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
