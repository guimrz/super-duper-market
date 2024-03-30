using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Extensions;
using SuperDuperMarket.Services.Products.Application.Extensions;
using SuperDuperMarket.Services.Products.Repository;
using SuperDuperMarket.Services.Products.Repository.Extensions;

namespace SuperDuperMarket.Services.Products.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddProductsApplication();
            builder.Services.AddProductsRepository(config => config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.DefaultModelsExpandDepth(-1); // Hide schemas models
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Configure database
            await app.MigrateDatabaseAsync<ProductsDbContext>();
            await app.SeedDatabaseAsync();

            app.Run();
        }
    }
}