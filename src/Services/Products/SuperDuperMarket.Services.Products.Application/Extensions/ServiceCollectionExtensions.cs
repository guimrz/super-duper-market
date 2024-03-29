using Microsoft.Extensions.DependencyInjection;
using SuperDuperMarket.Services.Products.Application.Mapping;
using System.Reflection;

namespace SuperDuperMarket.Services.Products.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductMapProfile>();
            });

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}