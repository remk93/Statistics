using Microsoft.Extensions.DependencyInjection;

namespace Statistics.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
