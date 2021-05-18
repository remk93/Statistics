using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Statistics.Core.Behaviours;
using System.Reflection;

namespace Statistics.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
