using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionApi.Application.Bases;
using OnionApi.Application.Beheviors;
using OnionApi.Application.Exceptions;
using OnionApi.Application.Features.Products.Rules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnionApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) {
           var assembly=Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddTransient<ProductsRules>();
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBeheviorz<,>));

        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type!=t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
                return services;
        }
    }
}
