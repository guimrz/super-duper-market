using Microsoft.EntityFrameworkCore;
using NSwag;
using SuperDuperMarket.Core.EntityFrameworkCore.Extensions;
using SuperDuperMarket.Services.Products.Application.Extensions;
using SuperDuperMarket.Services.Products.Repository;
using SuperDuperMarket.Services.Products.Repository.Extensions;

namespace SuperDuperMarket.Services.Products.Api.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Configuration
              .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApiDocument(options => 
            {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Products API"
                    };
                };
            });

            builder.Services.AddProductsApplication();
            builder.Services.AddProductsRepository(config => config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder.Build();
        }

        public static async Task<WebApplication> ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi();
                app.UseReDoc(options =>
                {
                    options.DocumentTitle = "Products API Documentation";
                    options.Path = "/docs";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Configure database
            await app.MigrateDatabaseAsync<ProductsDbContext>();
            await app.SeedDatabaseAsync();

            return app;
        }
    }
}
