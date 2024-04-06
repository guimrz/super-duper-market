using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SuperDuperMarket.Core.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Domain;
using SuperDuperMarket.Services.Products.Repository.Seeds;

namespace SuperDuperMarket.Services.Products.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsRepository(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
        {
            services.TryAddScoped<IRepositoryProvider, RepositoryProvider>();
            services.TryAddScoped<IRepository<ProductType>>(serviceProvider => new Repository<ProductType>(serviceProvider.GetRequiredService<ProductsDbContext>()));
            services.TryAddScoped<IRepository<Product>>(serviceProvider => new Repository<Product>(serviceProvider.GetRequiredService<ProductsDbContext>()));
            services.TryAddScoped<IRepository<Brand>>(serviceProvider => new Repository<Brand>(serviceProvider.GetRequiredService<ProductsDbContext>()));
            services.AddDbContext<ProductsDbContext>(optionsAction);

            return services;
        }

        public static IServiceCollection AddProductsServiceSeeding(this IServiceCollection services)
        {
            services.TryAddTransient<ISeedingService, ProductTypeSeed>();

            return services;
        }
    }
}