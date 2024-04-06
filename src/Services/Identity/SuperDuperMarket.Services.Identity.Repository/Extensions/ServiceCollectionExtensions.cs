using Microsoft.Extensions.DependencyInjection;

namespace SuperDuperMarket.Services.Identity.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServiceSeeding(this IServiceCollection services)
        {
            return services;
        }
    }
}