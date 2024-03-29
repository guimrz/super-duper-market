using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsRepository(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
        {
            services.TryAddScoped<IRepository<Product>, ProductsRepository>();
            services.AddDbContext<ProductsDbContext>(optionsAction);

            return services;
        }
    }
}